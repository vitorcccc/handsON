namespace DominoPontaDeQuina.Application.Auth;

/// <summary>Abstrai operações de hash e verificação de senha.</summary>
public interface IPasswordHasher
{
    /// <summary>Gera o hash de uma senha em texto puro.</summary>
    /// <param name="senha">Senha a ser hasheada.</param>
    /// <returns>Hash da senha.</returns>
    string Hash(string senha);

    /// <summary>Verifica se uma senha em texto puro corresponde ao hash armazenado.</summary>
    /// <param name="senha">Senha em texto puro.</param>
    /// <param name="hash">Hash armazenado.</param>
    /// <returns><see langword="true"/> se a senha for válida.</returns>
    bool Verificar(string senha, string hash);
}
