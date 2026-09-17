using DominoPontaDeQuina.Application.Auth.Dtos;
using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Domain.Repositories;

namespace DominoPontaDeQuina.Application.Auth;

/// <summary>Implementa os casos de uso de autenticação JWT.</summary>
public class AuthService(
    IUsuarioRepository usuarioRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtTokenService) : IAuthService
{
    /// <inheritdoc/>
    public async Task<AuthResult> RegistrarAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existente = await usuarioRepository.ObterPorEmailAsync(request.Email, cancellationToken);
        if (existente is not null)
            throw new InvalidOperationException("E-mail já cadastrado.");

        var usuario = new Usuario
        {
            Email = request.Email,
            SenhaHash = passwordHasher.Hash(request.Senha)
        };

        await usuarioRepository.AdicionarAsync(usuario, cancellationToken);

        var token = jwtTokenService.GerarToken(usuario);
        return new AuthResult(token, usuario.Id, usuario.Email);
    }

    /// <inheritdoc/>
    public async Task<AuthResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var usuario = await usuarioRepository.ObterPorEmailAsync(request.Email, cancellationToken)
            ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

        if (!passwordHasher.Verificar(request.Senha, usuario.SenhaHash))
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        var token = jwtTokenService.GerarToken(usuario);
        return new AuthResult(token, usuario.Id, usuario.Email);
    }
}
