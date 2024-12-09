using educae.core.DomainObjects;
using educae.core.ValueObjects;
using educae.contas.domain.enums;

namespace educae.contas.domain
{
    public class Usuario : Entity, IAgregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public TipoContaEnum TipoDeConta { get; private set; }
        public Matricula? Matricula { get; private set; }
        public Cpf? CPF { get; private set; }

        public Usuario(string nome, string email, string senha, TipoContaEnum tipoDeConta, string? matricula = null, string? cpf = null)
        {
            Nome = nome.Trim();
            Email = email.Trim();
            Senha = senha;
            TipoDeConta = tipoDeConta;

            ValidarDados(tipoDeConta, matricula, cpf);
        }

        private void ValidarDados(TipoContaEnum tipoDeConta, string? matricula, string? cpf)
        {
            if (tipoDeConta == TipoContaEnum.Aluno)
            {
                Matricula = new Matricula(matricula ?? throw new ArgumentException("Matrícula é obrigatória para alunos."));
            }
            else if (tipoDeConta == TipoContaEnum.Professor)
            {
                CPF = new Cpf(cpf ?? throw new ArgumentException("CPF é obrigatório para professores."));
            }
        }
    }
}