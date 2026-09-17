namespace DominoPontaDeQuina.Application.Auth.Dtos;

/// <summary>Credenciais para autenticação.</summary>
/// <param name="Email">E-mail cadastrado.</param>
/// <param name="Senha">Senha em texto puro.</param>
public record LoginRequest(string Email, string Senha);
