using Cadastro.Data;
using Microsoft.EntityFrameworkCore;
using Cadastro.Usuarios.Requests;
using Cadastro.Usuarios.Models;
using Cadastro.Usuarios.DataTransferObjects;

namespace Cadastro.Usuarios.Routes;


public static class UsuariosRotas
{
    public static void AddRotasUsuarios(this WebApplication app)
    {

        var rotasUsuarios = app.MapGroup("usuarios"); //adiciona prefixo das rotas

        
        // Para criar se usa o Post
        rotasUsuarios.MapPost("",  
            async(AddUsuarioRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var Existe = await context.Usuarios
                .AnyAsync(usuario => usuario.Documento == request.Documento && usuario.Ativo,ct) ;
            
            if(Existe)
                return Results.Conflict("Usuario já cadastrado");
            
            var novoUsuario = new Usuario(request.Nome,request.Email,request.Tipo,request.Documento, 
                request.Cep, request.Endereco,request.Numero, request.Bairro,
                request.Cidade, request.Uf);
            
            await context.Usuarios.AddAsync(novoUsuario,ct);
            await context.SaveChangesAsync(ct);
            
            var usuarioRetorno = new UsuarioDto(novoUsuario.Id, novoUsuario.Nome,novoUsuario.Documento,novoUsuario.Email);
            
            return Results.Ok(usuarioRetorno);

        });
        //Pesquisar usuario
        rotasUsuarios.MapPost("search", async (SearchUsuarioRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var usuarios = await context.Usuarios
                .Where(usuarios => usuarios.Nome.Contains(request.Nome) && usuarios.Ativo )
                .Select(usuarios => new UsuarioDto(usuarios.Id,usuarios.Nome,usuarios.Documento,usuarios.Email))
                .ToListAsync(ct);
            return usuarios;
        });
        //Retornar todos os usuarios Ativos
        rotasUsuarios.MapGet("",  async (AppDbContext context,CancellationToken ct) =>
            {
                var usuarios = await context.Usuarios
                    .Where(usuario => usuario.Ativo)
                    .Select(usuario => new UsuarioDto(usuario.Id,usuario.Nome,usuario.Documento,usuario.Email))
                    .ToListAsync(ct);
                return usuarios;
            }
        );
        //Retornar usuario para edição
        rotasUsuarios.MapGet("{id:guid}",  async (Guid id,AppDbContext context,CancellationToken ct) =>
            {
                var usuarios = await context.Usuarios
                    .Where(usuario => usuario.Id == id)
                    .ToListAsync(ct);
                return usuarios;
            }
        );
        
        //Atualizar Dados
        rotasUsuarios.MapPut("{id:guid}", 
            async (Guid id,UpdateUsuarioRequest request, AppDbContext context,CancellationToken ct) =>
            {
                var usuario = await context.Usuarios
                    .SingleOrDefaultAsync(usuario => usuario.Id == id,ct);
                
                if(usuario == null)
                    return Results.NotFound();
                
                usuario.AtualizarDados(request.Nome,request.Email,request.Tipo,request.Documento, 
                    request.Cep, request.Endereco,request.Numero, request.Bairro,
                    request.Cidade, request.Uf);
                
                await context.SaveChangesAsync(ct);
                return Results.Ok(new UsuarioDto(usuario.Id,usuario.Nome,usuario.Documento,usuario.Email));
            });
        
        //Deletar
        rotasUsuarios.MapDelete("{id}", async (Guid id, AppDbContext context,CancellationToken ct) =>
        {
            var usuario = await context.Usuarios
                .SingleOrDefaultAsync(usuario => usuario.Id == id,ct);
            
            if(usuario == null)
                return Results.NotFound();
            
            usuario.Desativar();
            await context.SaveChangesAsync(ct);
            return Results.Ok();
        });
    }
}