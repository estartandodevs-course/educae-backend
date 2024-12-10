using educae.contas.domain.enums;
using EstartandoDevsCore.ValueObjects;

namespace educae.contas.domain;

public class Educador : Usuario
{
    public Cpf CPF { get; set; }
    
    protected Educador() {}

    public Educador(string nome, Email email, Senha senha, TipoUsuario tipoUsuario, Cpf cpf) 
    {
        AtribuirNome(nome);
        AtribuirEmail(email);
        AtribuirSenha(senha);
        AtribuirTipoUsuario(tipoUsuario);
        CPF = cpf;
    }
    
    public void AtribuirCpf(string cpf) => CPF = new Cpf(cpf);
    
}