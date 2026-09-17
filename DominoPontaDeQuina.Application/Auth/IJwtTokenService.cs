using DominoPontaDeQuina.Domain.Entities;

namespace DominoPontaDeQuina.Application.Auth;

/// <summary>Abstrai a geração de tokens JWT.</summary>
public interface IJwtTokenService
{
    /// <summary>Gera um JWT assinado para o usuário informado.</summary>
    /// <param name="usuario">Usuário autenticado.</param>
    /// <returns>Token JWT em formato compacto.</returns>
    string GerarToken(Usuario usuario);
}
