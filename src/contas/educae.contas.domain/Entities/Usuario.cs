using educae.contas.domain.enums;
using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.ValueObjects;

namespace educae.contas.domain
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        protected Usuario() { }
        
        public Usuario(string nome, Email email, Senha senha, TipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }
        
        public void AtribuirNome(string nome) => Nome = nome;
        public void AtribuirEmail(Email email) => Email = email;
        public void AtribuirSenha(Senha senha) => Senha = senha;
        public void AtribuirTipoUsuario(TipoUsuario tipo) => TipoUsuario = tipo;
    }
}