using DominoPontaDeQuina.Application.Auth.Dtos;

namespace DominoPontaDeQuina.Application.Auth;

/// <summary>Casos de uso de autenticação de usuários.</summary>
public interface IAuthService
{
    /// <summary>Registra um novo usuário e retorna o JWT gerado.</summary>
    /// <param name="request">Dados de cadastro.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Resultado da autenticação com o token JWT.</returns>
    /// <exception cref="InvalidOperationException">Lançada quando o e-mail já está cadastrado.</exception>
    Task<AuthResult> RegistrarAsync(RegisterRequest request, CancellationToken cancellationToken = default);

    /// <summary>Autentica um usuário existente e retorna o JWT gerado.</summary>
    /// <param name="request">Credenciais de acesso.</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Resultado da autenticação com o token JWT.</returns>
    /// <exception cref="UnauthorizedAccessException">Lançada quando as credenciais são inválidas.</exception>
    Task<AuthResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
