using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.domain.ValueObject;
using educae.contas.domain;
using educae.contas.domain.interfaces;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;
using Usuario = educae.comunicacao.domain.ValueObject.Usuario;

namespace educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks
{
    public class SolicitacaoFeedbackCommandHandler : CommandHandler,
        IRequestHandler<AtualizarSolicitacaoFeedbackCommand, ValidationResult>,
        IRequestHandler<CriarSolicitacaoFeedbackCommand, ValidationResult>,
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
        public async Task<ValidationResult> Handle(CriarSolicitacaoFeedbackCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var educador = await _usuarioRepository.ObterPorId(request.UsuarioDestinatarioId);
            if (educador == null)
            {
                AdicionarErro("Educador destinatário não encontrado.");
                return ValidationResult;
            }
            
            var solicitacao = new SolicitacaoFeedback(request.Assunto, request.Conteudo, 
                new Usuario(request.UsuarioDestinatarioId, request.NomeUsuarioDestinatario, 
                    request.EmailUsuarioDestinatario, request.FotoUsuarioDestinatario), 
                new Usuario(request?.AlunoRemetenteId, request?.NomeAlunoRemetente, 
                    request?.EmailAlunoRemetente, request?.FotoAlunoRemetente), request.EnvioAnonimo);
            
            _solicitacaoRepository.Adicionar(solicitacao);

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
            _solicitacaoRepository?.Dispose(); 
        }
    }
}