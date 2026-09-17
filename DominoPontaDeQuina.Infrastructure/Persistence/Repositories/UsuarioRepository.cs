using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DominoPontaDeQuina.Infrastructure.Persistence.Repositories;

/// <summary>Repositório EF Core para <see cref="Usuario"/>.</summary>
public class UsuarioRepository(DominoDbContext db) : EfRepository<Usuario>(db), IUsuarioRepository
{
    /// <inheritdoc/>
    public async Task<Usuario?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default)
        => await Db.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}
