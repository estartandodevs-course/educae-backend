using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.ValueObjects;
using MediatR;


namespace educae.contas.app.Application.Commands.Educador;

public class EditarEducadorCommand : Command
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Telefone { get; set; }

    public EditarEducadorCommand (int id , string nome, string matricula , string telefone)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
    }
}