using FluentValidation.Results;
using MediatR;
using EstartandoDevsCore.Messages;
using educae.comunicacao.app.Application.Commands.Comunicados;
using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application
{
    public class ComunicadoCommandHandler : CommandHandler, 
        IRequestHandler<AdicionarComunicadoCommand, ValidationResult>,
        IRequestHandler<EditarComunicadoCommand, ValidationResult>,
        IDisposable
    {
        private readonly IComunicadoRepository _comunicadoRepository;

        public ComunicadoCommandHandler(IComunicadoRepository comunicadoRepository)
        {
            _comunicadoRepository = comunicadoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if(!request.EstaValido()) return request.ValidationResult;
            
            var novoComunicado = new Comunicado(request.Titulo, request.Descricao, request.Imagem, request.DataExpiracao);
            
            _comunicadoRepository.Adicionar(novoComunicado);

            return await PersistirDados(_comunicadoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarComunicadoCommand request, CancellationToken cancellationToken)
        {
            if(!request.EstaValido()) return request.ValidationResult;

            var comunicado = await _comunicadoRepository.ObterPorId(request.AtividadeId);

            if (comunicado == null)
            {
                AdicionarErro("Comunicado não encontrado");
                return ValidationResult;
            }
            
            comunicado.AtribuirTitulo(request.Titulo);
            comunicado.AtribuirDescricao(request.Descricao);
            comunicado.AtribuirImagem(request.Imagem);
            comunicado.AtribuirDataExpiracao(request.DataExpiracao);
            
            _comunicadoRepository.Atualizar(comunicado);
            
            return await PersistirDados(_comunicadoRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _comunicadoRepository?.Dispose();
        }
    }
    
}