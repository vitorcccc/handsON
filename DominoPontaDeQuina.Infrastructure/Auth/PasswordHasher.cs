using DominoPontaDeQuina.Application.Auth;

namespace DominoPontaDeQuina.Infrastructure.Auth;

/// <summary>Implementa hash e verificação de senha usando BCrypt.</summary>
public class PasswordHasher : IPasswordHasher
{
    /// <inheritdoc/>
    public string Hash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);

    /// <inheritdoc/>
    public bool Verificar(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);
}
