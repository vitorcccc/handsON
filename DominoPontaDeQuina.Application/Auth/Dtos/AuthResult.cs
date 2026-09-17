namespace DominoPontaDeQuina.Application.Auth.Dtos;

/// <summary>Resultado de uma operação de autenticação bem-sucedida.</summary>
/// <param name="Token">JWT gerado para o usuário autenticado.</param>
/// <param name="UsuarioId">Identificador do usuário autenticado.</param>
/// <param name="Email">E-mail do usuário autenticado.</param>
public record AuthResult(string Token, Guid UsuarioId, string Email);
