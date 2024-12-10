using educae.contas.domain.enums;
using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.ValueObjects;

namespace educae.contas.domain
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Login Login { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, Login login, TipoUsuario tipoUsuario)
        {
            Nome = nome;
            Login = login;
            TipoUsuario = tipoUsuario;
        }

        public void AtribuirNome(string nome) => Nome = nome;
        public void AtribuirLogin(Login login) => Login = login;
        public void AtribuirTipoUsuario(TipoUsuario tipo) => TipoUsuario = tipo;
    }
}