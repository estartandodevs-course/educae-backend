using educae.biblioteca.app.Application.Commands;
using educae.biblioteca.app.Application.Queries;
using educae.biblioteca.app.Application.Queries.Interfaces;
using educae.biblioteca.domain.Interfaces;
using educae.biblioteca.infra.Repositories;
using educae.comunicacao.app.Application;
using educae.comunicacao.app.Application.Commands.Atividades;
using educae.comunicacao.app.Application.Commands.Comunicados;
using educae.comunicacao.app.Application.Commands.Lembretes;
using educae.comunicacao.app.Application.Commands.SolicitacoesFeedbacks;
using educae.comunicacao.app.Application.Queries;
using educae.comunicacao.app.Application.Queries.Interfaces;
using educae.contas.domain.interfaces;
using educae.contas.infra.repositories;
using educae.comunicacao.domain.Interfaces;
using educae.comunicacao.infra.Repositories;
using educae.contas.app.Application.Commands.Alunos;
using educae.contas.app.Application.Commands.Educadores;
using educae.contas.app.Application.Queries;
using educae.contas.app.Application.Queries.Interfaces;
using EstartandoDevsCore.Mediator;
using FluentValidation.Results;
using MediatR;

namespace webapi.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddScoped<IEducadorRepository, EducadorRepository>();

        services.AddScoped<IAtividadeRepository, AtividadeRepository>();
        services.AddScoped<IComunicadoRepository, ComunicadoRepository>();
        services.AddScoped<ISolicitacaoFeedBackRepository, SolicitacaoFeedBackRepository>();
        services.AddScoped<ILembreteRepository, LembreteRepository>();

        services.AddScoped<ICartilhaRepository, CartilhaRepository>();
        
        services.AddScoped<IAlunoQuery, AlunoQuery>();
        services.AddScoped<IEducadorQuery, EducadorQuery>();

        services.AddScoped<IAtividadeQuery, AtividadeQuery>();
        services.AddScoped<IComunicadoQuery, ComunicadoQuery>();
        services.AddScoped<ILembreteQuery, LembreteQuery>();
        services.AddScoped<ISolicitacaoFeedbackQuery, SolicitacaoFeedbackQuery>();

        services.AddScoped<ICartilhaQuery, CartilhaQuery>();

        services.AddScoped<IRequestHandler<CadastrarAlunoCommand, ValidationResult>, AlunoCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarAlunoCommand, ValidationResult>, AlunoCommandHandler>();

        services.AddScoped<IRequestHandler<CadastrarEducadorCommand, ValidationResult>, EducadorCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarEducadorCommand, ValidationResult>, EducadorCommandHandler>();
        
        services.AddScoped<IRequestHandler<AdicionarAtividadeCommand, ValidationResult>, AtividadeCommandHandler>();
        services.AddScoped<IRequestHandler<EditarAtividadeCommand, ValidationResult>, AtividadeCommandHandler>();
        services.AddScoped<IRequestHandler<EnviarAtividadeCommand, ValidationResult>, AtividadeCommandHandler>();
        
        services.AddScoped<IRequestHandler<AdicionarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
        services.AddScoped<IRequestHandler<EditarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
        
        services.AddScoped<IRequestHandler<AdicionarLembreteCommand, ValidationResult>, LembreteCommandHandler>();
        services.AddScoped<IRequestHandler<ConcluirLembreteCommand, ValidationResult>, LembreteCommandHandler>();
        services.AddScoped<IRequestHandler<DesconcluirLembreteCommand, ValidationResult>, LembreteCommandHandler>();

        services.AddScoped<IRequestHandler<CriarSolicitacaoFeedbackCommand, ValidationResult>, SolicitacaoFeedbackCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarSolicitacaoFeedbackCommand, ValidationResult>, SolicitacaoFeedbackCommandHandler>();
        services.AddScoped<IRequestHandler<ResponderSolicitacaoFeedbackCommand, ValidationResult>, SolicitacaoFeedbackCommandHandler>();

        services.AddScoped<IRequestHandler<CadastraCartilhaCommand, ValidationResult>, CartilhaCommandHandler>();
        services.AddScoped<IRequestHandler<EditarCartilhaCommand, ValidationResult>, CartilhaCommandHandler>();

    }
}