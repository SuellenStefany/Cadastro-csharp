namespace Cadastro.Usuarios.Models;

public class Usuario
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Tipo { get; private set; }
    public string Documento { get; private set; }
    public string Cep { get; private set; }
    public string Endereco { get; private set; }
    public string Numero { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Uf { get; private set; }
    
    public bool Ativo { get; private set; }

    public Usuario(
        string nome,string email,string tipo,string documento, 
        string cep, string endereco,string numero, string bairro,
        string cidade, string uf)
    {
        Nome = nome;
        Email = email;
        Tipo = tipo;
        Documento = documento;
        Cep = cep;
        Endereco = endereco;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Uf = uf;
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public void AtualizarDados(
        string nome,string email,string tipo,string documento, 
        string cep, string endereco,string numero, string bairro,
        string cidade, string uf)
    {
        Nome = nome;
        Email = email;
        Tipo = tipo;
        Documento = documento;
        Cep = cep;
        Endereco = endereco;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Uf = uf;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}