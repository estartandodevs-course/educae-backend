using educae.contas.domain;
using educae.contas.domain.enums;
using educae.contas.domain.interfaces;
using educae.contas.domain.ValueObject;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;


namespace educae.contas.app.Application.Commands.Educadores
{
    public class EducadorCommandHandler : CommandHandler,
        IRequestHandler<CadastrarEducadorCommand, ValidationResult>, IDisposable
    {
        private readonly IEducadorRepository _educadorRepository;

        public EducadorCommandHandler(IEducadorRepository educadorRepository)
        {
            _educadorRepository = educadorRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarEducadorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;


            var educadorExistente = await _educadorRepository.ObterPorCpf(request.Cpf);
            if (educadorExistente != null)
            {
                AdicionarErro("Já existe um educador com esse CPF.");
                return ValidationResult;
            }

            var educador = new Educador(
                nome: request.Nome,
                login: new Login(request.Email, request.Senha),
                tipoUsuario: TipoUsuario.Educador,
                cpf: request.Cpf
            );

            _educadorRepository.Adicionar(educador);

            return await PersistirDados(_educadorRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarEducadorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var educador = await _educadorRepository.ObterPorCpf(request.Cpf);
            if (educador == null)
            {
                AdicionarErro("Educador não encontrado.");
                return ValidationResult;
            }

            educador.AtribuirNome(request.Nome);
            educador.AtribuirLogin(new Login(request.Email, request.Senha));
            educador.AtribuirTipoUsuario(request.TipoUsuario);
            educador.AtribuirCpf(request.Cpf);

            _educadorRepository.Atualizar(educador);

            return await PersistirDados(_educadorRepository.UnitOfWork);
        }

        public void Disposable()
        {
            _educadorRepository.Dispose();
        }
    }
}