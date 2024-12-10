using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using MediatR;

namespace educae.contas.app.Application.Commands.Alunos;

public class EditarAlunoCommand : Command
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Telefone { get; set; }

    public EditarAlunoCommand(int id , string nome, string matricula , string telefone)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
    }
}