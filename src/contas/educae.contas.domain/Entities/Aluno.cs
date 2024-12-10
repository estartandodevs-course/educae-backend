using educae.contas.domain.enums;
using educae.contas.domain.ValueObject;
using EstartandoDevsCore.ValueObjects;

namespace educae.contas.domain;

public class Aluno : Usuario
{
    public string Matricula { get; set; }
    
    protected Aluno() {}

    public Aluno(string nome, Login login, TipoUsuario tipoUsuario, string matricula)
    {
        AtribuirNome(nome);
        AtribuirLogin(Login);
        AtribuirTipoUsuario(tipoUsuario);
        Matricula = matricula;
    }
    
    public void AtribuirMatricula(string matricula) => Matricula = matricula;
}