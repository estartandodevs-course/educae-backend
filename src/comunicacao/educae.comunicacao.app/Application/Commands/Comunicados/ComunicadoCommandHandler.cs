using FluentValidation.Results;
using MediatR;
using EstartandoDevsCore.Messages;
using educae.comunicacao.app.Application.Commands.Comunicados;
using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;

namespace educae.comunicacao.app.Application
{
    public class ComunicadoCommandHandler : CommandHandler, IRequestHandler<AdicionarComunicadoCommand, ValidationResult>
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
    }
    
}