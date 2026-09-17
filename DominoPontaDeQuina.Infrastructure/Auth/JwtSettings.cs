namespace DominoPontaDeQuina.Infrastructure.Auth;

/// <summary>Configurações necessárias para geração e validação de tokens JWT.</summary>
public class JwtSettings
{
    /// <summary>Chave secreta usada para assinar o token (mínimo 32 caracteres).</summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>Emissor do token (iss).</summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>Audiência do token (aud).</summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>Tempo de expiração em minutos. Padrão: 60.</summary>
    public int ExpiracaoMinutos { get; set; } = 60;
}
