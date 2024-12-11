using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.Interfaces;
using EstartandoDevsCore.Messages;
using FluentValidation.Results;
using MediatR;

namespace educae.comunicacao.app.Application.Commands.Atividades;

public class AtividadeCommandHandler : CommandHandler,
    IRequestHandler<AdicionarAtividadeCommand, ValidationResult>, 
    IRequestHandler<EditarAtividadeCommand, ValidationResult>, 
    IRequestHandler<EnviarAtividadeCommand, ValidationResult>, IDisposable
{
    private readonly IAtividadeRepository _atividadeRepository;

    public AtividadeCommandHandler(IAtividadeRepository atividadeRepository)
    {
        _atividadeRepository = atividadeRepository;
    }

    public async Task<ValidationResult> Handle(AdicionarAtividadeCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return ValidationResult;
        
        var novaAtividade = new Atividade(request.Titulo, request.Descricao, request.DataMaximaEntrega, request.Feito);
        
        _atividadeRepository.Adicionar(novaAtividade);
        
        return await PersistirDados(_atividadeRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(EditarAtividadeCommand request, CancellationToken cancellationToken)
    {
        if (!request.EstaValido()) return ValidationResult;

        var atividade = await _atividadeRepository.ObterPorId(request.AtividadeId);

        if (atividade == null)
        {
            AdicionarErro("Atividade não encontrada");
            return ValidationResult;
        }
        
        atividade.Atualizar(request.Titulo, request.Descricao, request.DataMaximaEntrega);
        
        _atividadeRepository.Atualizar(atividade);
        
        return await PersistirDados(_atividadeRepository.UnitOfWork);
    }
    public async Task<ValidationResult> Handle(EnviarAtividadeCommand request, CancellationToken cancellationToken)
    {
        if(!request.EstaValido()) return ValidationResult;
        
        var atividade = await _atividadeRepository.ObterPorId(request.AtividadeId);

        if (atividade == null)
        {
            AdicionarErro("Atividade não encontrada");
            return ValidationResult;
        }
        
        atividade.MarcarFeito();
        atividade.AtribuirEstrelas(request.AvaliacaoAtividade);
        
        _atividadeRepository.Atualizar(atividade);
        
        return await PersistirDados(_atividadeRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _atividadeRepository?.Dispose();
    }

}