namespace Cadastro.Usuarios.Requests;

public record UpdateUsuarioRequest(
    string Nome,string Email,string Tipo,string Documento, 
    string Cep, string Endereco,string Numero, string Bairro,
    string Cidade, string Uf);
