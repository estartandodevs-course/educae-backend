using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.domain.ValueObject;
using educae.contas.domain;
using educae.contas.domain.interfaces;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class SolicitacaoFeedbackCommandHandler : CommandHandler,
        IRequestHandler<AnonimoSolicitacaoFeedbackCommand, ValidationResult>,
        IRequestHandler<AtualizarSolicitacaoFeedbackCommand, ValidationResult>,
        IRequestHandler<CriarSolicitacaoFeedbackCommand, ValidationResult>,
        IRequestHandler<FecharSolicitacaoFeedbackCommand, ValidationResult>,
        IRequestHandler<ResponderSolicitacaoFeedbackCommand, ValidationResult>,
        IDisposable
    {
        private readonly ISolicitacaoFeedBackRepository _solicitacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public SolicitacaoFeedbackCommandHandler(ISolicitacaoFeedBackRepository solicitacaoRepository, IUsuarioRepository usuarioRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(AnonimoSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var solicitacao = await _solicitacaoRepository.ObterPorId(request.SolicitacaoId);
            if (solicitacao == null)
            {
                AdicionarErro("Solicitação não encontrada.");
                return ValidationResult;
            }

            if (request.EnvioAnonimo)
                solicitacao.EnviarAnonimamente();
            else
                solicitacao.EnviarComIdentificacao();

            _solicitacaoRepository.Atualizar(solicitacao);

            return await PersistirDados(_solicitacaoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var solicitacao = await _solicitacaoRepository.ObterPorId(request.SolicitacaoId);
            if (solicitacao == null)
            {
                AdicionarErro("Solicitação não encontrada.");
                return ValidationResult;
            }

            solicitacao.AtribuirAssunto(request.Assunto);
            solicitacao.AtribuirConteudo(request.Conteudo);

            _solicitacaoRepository.Atualizar(solicitacao);

            return await PersistirDados(_solicitacaoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CriarSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var educador = await _usuarioRepository.ObterPorId(request.EducadorDestinatarioId);
            if (educador == null)
            {
                AdicionarErro("Educador destinatário não encontrado.");
                return ValidationResult;
            }

            Usuario? aluno = null;
            if (request.AlunoRemetenteId.HasValue)
            {
                aluno = await _usuarioRepository.ObterPorId(request.AlunoRemetenteId.Value);
                if (aluno == null)
                {
                    AdicionarErro("Aluno remetente não encontrado.");
                    return ValidationResult;
                }
            }

            var solicitacao = new SolicitacaoFeedback(
                assunto: request.Assunto,
                conteudo: request.Conteudo,
                educadorDestinatario: educador,
                alunoRementente: aluno,
                envioAnonimo: request.EnvioAnonimo,
                aberta: true
            );

            _solicitacaoRepository.Adicionar(solicitacao);

            return await PersistirDados(_solicitacaoRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(FecharSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var solicitacao = await _solicitacaoRepository.ObterPorId(request.SolicitacaoId);
            if (solicitacao == null)
            {
                AdicionarErro("Solicitação não encontrada.");
                return ValidationResult;
            }

            solicitacao.AdicionarResposta(null);
            _solicitacaoRepository.Atualizar(solicitacao);

            return await PersistirDados(_solicitacaoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ResponderSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var solicitacao = await _solicitacaoRepository.ObterPorId(request.SolicitacaoId);
            if (solicitacao == null)
            {
                AdicionarErro("Solicitação não encontrada.");
                return ValidationResult;
            }

            if (!solicitacao.Aberta)
            {
                AdicionarErro("A solicitação já foi respondida.");
                return ValidationResult;
            }

            solicitacao.AdicionarResposta(new RespostaFeedBack(request.Resposta, DateTime.Now));
            _solicitacaoRepository.Atualizar(solicitacao);

            return await PersistirDados(_solicitacaoRepository.UnitOfWork);
        }
        public void Dispose()
        {
            _solicitacaoRepository.Dispose();
            _usuarioRepository.Dispose();
        }
    }
}