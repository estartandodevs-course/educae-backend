using educae.biblioteca.app.Models;
using educae.biblioteca.domain.Entities;
using educae.biblioteca.domain.Interfaces;
using educae.biblioteca.domain.ValueObject;
using EstartandoDevsCore.Messages;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace educae.biblioteca.app.Application.Commands;

public class CartilhaCommandHandler : CommandHandler,
    IRequestHandler<CadastraCartilhaCommand, ValidationResult>,
    IRequestHandler<EditarCartilhaCommand, ValidationResult>, IDisposable
{

    private readonly ICartilhaRepository _cartilhaRepository;

    public CartilhaCommandHandler(ICartilhaRepository cartilhaRepository)
    {
        _cartilhaRepository = cartilhaRepository;
    }


    public async Task<ValidationResult> Handle(CadastraCartilhaCommand request, CancellationToken cancellationToken)
    {
        if(!request.EstaValido()) return request.ValidationResult;

        var novaCartilha = new Cartilha(request.Titulo, request.Resumo, request.Descricao, new Url(request.Url), request.Autor);
        
        foreach (var anexoModel in request.Anexos)
        {
            var anexo = new Anexo(anexoModel.NomeArquivo, anexoModel.NomeOriginal);
            novaCartilha.AdicionarAnexo(anexo);
        }
        
        _cartilhaRepository.Adicionar(novaCartilha);

        return await PersistirDados(_cartilhaRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(EditarCartilhaCommand request, CancellationToken cancellationToken)
    {
        if(!request.EstaValido()) return request.ValidationResult;

        var cartilha = await _cartilhaRepository.ObterPorId(request.CartilhaId);

        if (cartilha == null)
        {
            AdicionarErro("Cartilha não encontrada");
            return ValidationResult;
        }
        
        cartilha.Atualizar(request.Titulo, request.Resumo, request.Descricao, new Url(request.Url), request.Autor);

        cartilha.LimparAnexos();
        
        foreach (var anexoModel in request.Anexos)
        {
            var anexo = new Anexo(anexoModel.NomeArquivo, anexoModel.NomeOriginal);
            cartilha.AdicionarAnexo(anexo);
        }
        
        _cartilhaRepository.Atualizar(cartilha);
        
        return await PersistirDados(_cartilhaRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _cartilhaRepository?.Dispose();
    }
}