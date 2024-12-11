using FluentValidation.Results;
using MediatR;
using EstartandoDevsCore.Messages;
using educae.comunicacao.app.Application.Commands.Comunicados;

namespace educae.comunicacao.app.Application
{
    public class ComunicadoCommandHandler : CommandHandler, IRequestHandler<AdicionarComunicadoCommand, ValidationResult>
    {
        private readonly IComunicadoRepository _comunicadoRepository;

        public ComunicadoCommandHandler(IComunicadoRepository comunicadoRepository)
        {
            _comunicadoRepository = comunicadoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarComunicadoCommand command, CancellationToken cancellationToken)
        {
           
            if (!command.EstaValido())
            {
                return command.ValidationResult;
            }

           
            var comunicado = new Comunicado
            {
                Id = Guid.NewGuid(),
                Assunto = command.Assunto,
                Conteudo = command.Conteudo,
                UsuarioId = command.UsuarioId,
                CriadoEm = DateTime.UtcNow
            };

            
            await _comunicadoRepository.AdicionarAsync(comunicado);

            
            return new ValidationResult();
        }
    }

  
    public interface IComunicadoRepository
    {
        Task AdicionarAsync(Comunicado comunicado);
    }

    public class Comunicado
    {
        public Guid Id { get; set; }
        public required string Assunto { get; set; }
        public required string Conteudo { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}