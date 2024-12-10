using educae.comunicacao.domain.Entities;
using educae.comunicacao.domain.ValueObject;
using educae.contas.infra.data;
using EstartandoDevsCore.Data;
using EstartandoDevsCore.DomainObjects;
using EstartandoDevsCore.Mediator;
using EstartandoDevsCore.Messages;
using EstartandoDevsCore.Ultilities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace educae.comunicacao.infra.Data;

public class ComunicacaoContext : DbContext, IUnitOfWorks
{
    private readonly IMediatorHandler _mediatorHandler;
    
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<Comunicado> Comunicados { get; set; }
    public DbSet<Lembrete> Lembretes { get; set; }
    public DbSet<SolicitacaoFeedback> Solicitacoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RespostaFeedBack> Respostas { get; set; }
    
    public ComunicacaoContext(DbContextOptions<ComunicacaoContext> options, IMediatorHandler mediatorHandler)
        : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComunicacaoContext).Assembly);
    }
    
    public async Task<bool> Commit()
    {
        var cetZone = ZonaDeTempo.ObterZonaDeTempo();

        foreach (var entry in ChangeTracker.Entries()
                     .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataDeCadastro").CurrentValue =
                    TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataDeCadastro").IsModified = false;
                entry.Property("DataDeAlteracao").CurrentValue =
                    TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
            }
        }

        var sucesso = await SaveChangesAsync() > 0;

        if (sucesso) await _mediatorHandler.PublicarEventos(this);

        return sucesso;    
    }
    
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents.Select(async (domainEvent) => {await mediator.PublicarEvento(domainEvent);});

            await Task.WhenAll(tasks);
        }
    }
}