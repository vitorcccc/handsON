using DominoPontaDeQuina.Domain.Entities;

namespace DominoPontaDeQuina.Domain.Repositories;

/// <summary>Define operações de persistência específicas de <see cref="Usuario"/>.</summary>
public interface IUsuarioRepository : IRepository<Usuario>
{
    /// <summary>Obtém um usuário pelo e-mail.</summary>
    /// <param name="email">E-mail a pesquisar.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>O usuário ou <see langword="null"/> se não existir.</returns>
    Task<Usuario?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default);
}
