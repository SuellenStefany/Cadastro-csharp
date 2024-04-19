namespace Cadastro.Usuarios.Requests;

public record AddUsuarioRequest(
    string Nome,string Email,string Tipo,string Documento, 
    string Cep, string Endereco,string Numero, string Bairro,
    string Cidade, string Uf);
