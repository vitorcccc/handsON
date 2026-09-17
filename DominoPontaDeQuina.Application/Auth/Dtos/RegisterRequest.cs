namespace DominoPontaDeQuina.Application.Auth.Dtos;

/// <summary>Dados necessários para registrar um novo usuário.</summary>
/// <param name="Email">E-mail único do usuário.</param>
/// <param name="Senha">Senha em texto puro (será hasheada antes de persistir).</param>
public record RegisterRequest(string Email, string Senha);
