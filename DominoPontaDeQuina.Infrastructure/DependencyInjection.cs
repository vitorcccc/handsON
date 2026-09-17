using DominoPontaDeQuina.Application.Auth;
using DominoPontaDeQuina.Domain.Repositories;
using DominoPontaDeQuina.Infrastructure.Auth;
using DominoPontaDeQuina.Infrastructure.Persistence;
using DominoPontaDeQuina.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DominoPontaDeQuina.Infrastructure;

/// <summary>Registra a persistência e os repositórios no contêiner de DI.</summary>
public static class DependencyInjection
{
    /// <summary>Adiciona o contexto, os repositórios e os serviços de autenticação JWT.</summary>
    /// <param name="services">Contêiner de serviços.</param>
    /// <param name="configureDb">Configuração do provedor e da conexão do banco.</param>
    /// <param name="configuration">Configuração da aplicação (seção "JwtSettings" é lida aqui).</param>
    /// <returns>O contêiner para encadeamento.</returns>
    public static IServiceCollection AddDominoInfrastructure(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> configureDb,
        IConfiguration configuration)
    {
        services.AddDbContext<DominoDbContext>(configureDb);

        services.AddScoped<IPartidaRepository, PartidaRepository>();
        services.AddScoped<IJogadorRepository, JogadorRepository>();
        services.AddScoped<IParticipacaoRepository, ParticipacaoRepository>();
        services.AddScoped<ILanceRepository, LanceRepository>();
        services.AddScoped<IRankingRepository, RankingRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
