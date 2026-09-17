# 📅 DominoPontaDeQuina - Sistema de Gerenciamento de Jogos de Dominó

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-5E2B97?style=for-the-badge&logo=xunit&logoColor=white)
![DI](https://img.shields.io/badge/DI-2C8EBB?style=for-the-badge&logo=spring&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)

---

## 👤 INTEGRANTE

| Nome | RM |
|------|-----|
| **Vitor Couto** | RM554965 |

---

## 📚 DISCIPLINA

**Entity Framework Core - Acesso a Dados com ORM**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este projeto implementa uma **Web API RESTful** para o gerenciamento do jogo de dominó **"Ponta de Quina"** utilizando **ASP.NET Core** e **Entity Framework Core** como ORM (Object-Relational Mapper), com uma arquitetura completa em camadas, **Injeção de Dependência (DI)** e documentação interativa com **Swagger/OpenAPI**.

### 🎯 Objetivos do Laboratório

**Laboratório anterior (Web API):**
- Criar um projeto **Web API**
- Adicionar referência do projeto **Services**
- Configurar **dependências** no `Program.cs`
- Criar **endpoints** para as operações expostas pelos serviços
- Documentar a API com **Swagger/OpenAPI**
- Implementar **DTOs** para transferência de dados
- Utilizar **Status Codes HTTP** adequados

**Laboratório atual (JWT Authentication):**
- ✅ Implementar **autenticação de usuários** com JWT
- ✅ Criar endpoint de **login** que gera o token JWT
- ✅ Proteger endpoints com `[Authorize]`
- ✅ Configurar **Bearer Token** no Swagger/OpenAPI
- ✅ Registrar serviços de autenticação no `Program.cs`
- ✅ Configurar **chave secreta, issuer e audience** via `appsettings.json`
- ✅ Implementar **IJwtService** para geração e validação de tokens

---

## 🗄️ ESTRUTURA DO BANCO DE DADOS

### Diagrama de Entidades

```
┌─────────────┐          ┌─────────────┐          ┌─────────────┐
│   Usuario   │ 1      N │   Jogador   │ 1      N │   Partida   │
├─────────────┤──────────├─────────────┤──────────├─────────────┤
│ Id (PK)     │          │ Id (PK)     │          │ Id (PK)     │
│ Nome        │          │ NomeExibicao│          │ IniciadoEm  │
│ Email       │          │ UsuarioId   │          │ FinalizadoEm│
│ HashSenha   │          │ Usuario (FK)│          │ Status      │
│ CriadoEm    │          └─────────────┘          │ PontuacaoAlvo│
└─────────────┘                    ↑              └─────────────┘
                                   │ N                        ↑
                                   │                          │ 1
                                   │                          │
                                   └──────────────────────────┘
                                   │ N             1          │
                                   ▼                          │
                          ┌─────────────────────────────────────┐
                          │    ParticipacaoPartida              │
                          ├─────────────────────────────────────┤
                          │ Id (PK)                             │
                          │ PartidaId (FK)                      │
                          │ JogadorId (FK)                      │
                          │ Posicao                             │
                          │ Pontuacao                           │
                          │ Vencedor                            │
                          └─────────────────────────────────────┘
```

---

## ⚙️ TECNOLOGIAS UTILIZADAS

| Tecnologia | Versão | Descrição |
|------------|--------|-----------|
| **.NET** | 8.0 | Plataforma de desenvolvimento |
| **C#** | 12.0 | Linguagem de programação |
| **ASP.NET Core** | 8.0 | Framework para construção de Web APIs |
| **Entity Framework Core** | 8.0.15 | ORM para acesso a dados |
| **SQLite** | 8.0.15 | Banco de dados leve embarcado |
| **xUnit** | 2.9.2 | Framework de testes unitários |
| **Moq** | 4.20.72 | Mocking para testes unitários |
| **Swagger/OpenAPI** | 6.5.0 | Documentação interativa da API |
| **Microsoft.AspNetCore.Authentication.JwtBearer** | 8.0.0 | Middleware de autenticação JWT |
| **System.IdentityModel.Tokens.Jwt** | 8.0.0 | Geração e validação de tokens JWT |
| **coverlet.collector** | 6.0.2 | Cobertura de testes |
| **Microsoft.Extensions.Hosting** | 8.0.0 | Host para DI e configuração |
| **Microsoft.EntityFrameworkCore.Design** | 8.0.15 | Ferramentas de design para migrações |
| **Microsoft.EntityFrameworkCore.Tools** | 8.0.15 | Ferramentas CLI para migrações |

---

## 📁 ESTRUTURA DO PROJETO

```
DominoPontaDeQuina/
│
├── DominoPontaDeQuina.Core/                # 🧠 Núcleo do Domínio
│   ├── Enums/
│   │   ├── LadoTabuleiro.cs
│   │   ├── StatusJogada.cs
│   │   ├── StatusPartida.cs
│   │   ├── StatusRodada.cs
│   │   └── TipoFinalizacaoRodada.cs
│   ├── Exceptions/
│   │   ├── DominoException.cs
│   │   ├── JogadaInvalidaException.cs
│   │   ├── PartidaException.cs
│   │   └── RodadaException.cs
│   ├── Interfaces/
│   │   ├── IJogada.cs
│   │   ├── IMaoJogador.cs
│   │   ├── IPartida.cs
│   │   └── IRodada.cs
│   ├── Models/
│   │   ├── Jogada.cs
│   │   ├── Jogador.cs
│   │   ├── MaoJogador.cs
│   │   ├── Partida.cs
│   │   ├── Peca.cs
│   │   ├── Rodada.cs
│   │   ├── Tabuleiro.cs
│   │   └── Time.cs
│   └── Services/
│       ├── DistribuicaoService.cs
│       ├── ITabuleiroService.cs
│       └── TabuleiroService.cs
│
├── DominoPontaDeQuina.Domain/              # 📦 Entidades para Persistência
│   └── Entities/
│       ├── Jogador.cs
│       ├── Partida.cs
│       ├── ParticipacaoPartida.cs
│       ├── StatusPartida.cs
│       └── Usuario.cs
│
├── DominoPontaDeQuina.Repository/          # 🗄️ Camada de Dados
│   ├── Context/
│   │   └── DominoDbContext.cs              # ✅ Fluent API
│   ├── Extensions/
│   │   └── ServiceCollectionExtensions.cs  # ✅ Registro de Repositories
│   ├── Interfaces/
│   │   ├── IJogadorRepository.cs
│   │   ├── IPartidaRepository.cs
│   │   ├── IParticipacaoPartidaRepository.cs
│   │   ├── IRepository.cs
│   │   ├── IUnitOfWork.cs
│   │   └── IUsuarioRepository.cs
│   ├── Repositories/
│   │   ├── BaseRepository.cs
│   │   ├── JogadorRepository.cs
│   │   ├── PartidaRepository.cs
│   │   ├── ParticipacaoPartidaRepository.cs
│   │   └── UsuarioRepository.cs
│   └── UnitOfWork/
│       └── UnitOfWork.cs
│
├── DominoPontaDeQuina.Services/            # ✅ Camada de Services
│   ├── Interfaces/
│   │   ├── IJogadorService.cs
│   │   ├── IPartidaService.cs
│   │   ├── IParticipacaoService.cs
│   │   └── IUsuarioService.cs
│   ├── Implementations/
│   │   ├── JogadorService.cs
│   │   ├── PartidaService.cs
│   │   ├── ParticipacaoService.cs
│   │   └── UsuarioService.cs
│   └── Extensions/
│       └── ServiceCollectionExtensions.cs  # ✅ Registro de Services
│
├── DominoPontaDeQuina.API/                 # 🔐 PROJETO WEB API + JWT
│   ├── Controllers/
│   │   ├── AuthController.cs               # 🆕 Login e geração de token
│   │   ├── UsuarioController.cs
│   │   ├── JogadorController.cs
│   │   ├── PartidaController.cs
│   │   └── ParticipacaoController.cs
│   ├── DTOs/
│   │   ├── LoginRequest.cs                 # 🆕 Email + Senha
│   │   ├── LoginResponse.cs                # 🆕 Token + Expiration
│   │   ├── UsuarioDto.cs
│   │   ├── JogadorDto.cs
│   │   ├── PartidaDto.cs
│   │   ├── ParticipacaoDto.cs
│   │   ├── CriarUsuarioRequest.cs
│   │   ├── CriarJogadorRequest.cs
│   │   ├── CriarPartidaRequest.cs
│   │   ├── AdicionarParticipanteRequest.cs
│   │   ├── AtualizarPontuacaoRequest.cs
│   │   ├── DefinirVencedorRequest.cs
│   │   └── AtualizarUsuarioRequest.cs
│   ├── Extensions/
│   │   └── MappingExtensions.cs            # ✅ Mapeamento Entity → DTO
│   ├── Services/
│   │   ├── IJwtService.cs                  # 🆕 Interface do serviço JWT
│   │   └── JwtService.cs                   # 🆕 Geração e validação de tokens
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── appsettings.json                    # 🆕 JwtSettings (Secret, Issuer, Audience)
│   ├── appsettings.Development.json
│   └── Program.cs                          # 🆕 Configuração JWT + Swagger Bearer
│
├── DominoPontaDeQuina.Migrations/          # 🔄 Migrações EF Core
│   ├── DominoDbContextFactory.cs
│   ├── domino.db                           # Banco de dados SQLite
│   └── Migrations/
│       └── 20260825121106_InitialCreate.cs
│
└── DominoPontaDeQuina.Tests/               # 🧪 Testes Unitários
    ├── Services/                           # ✅ Testes com DI e Moq
    │   ├── JogadorServiceTests.cs
    │   ├── PartidaServiceTests.cs
    │   ├── ParticipacaoServiceTests.cs
    │   └── UsuarioServiceTests.cs
    ├── Controllers/                        # 🆕 Testes dos Controllers
    │   ├── UsuarioControllerTests.cs
    │   ├── JogadorControllerTests.cs
    │   ├── PartidaControllerTests.cs
    │   └── ParticipacaoControllerTests.cs
    ├── Models/
    │   ├── MaoJogadorTests.cs
    │   ├── PartidaTests.cs
    │   ├── PecaTests.cs
    │   └── TabuleiroTests.cs
    ├── JogoTests.cs
    ├── MaoJogadorGapTests.cs
    ├── PartidaFluxoTests.cs
    ├── PartidaGapTests.cs
    ├── RodadaExcecaoTests.cs
    ├── RodadaFinalizacaoGapTests.cs
    ├── RodadaGapTests.cs
    └── TabuleiroGapTests.cs
```

---

## 🏗️ CONFIGURAÇÃO DAS ENTIDADES (Fluent API)

### 1. Usuario

```csharp
private static void ConfigureUsuario(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Usuario>(entity =>
    {
        entity.HasKey(u => u.Id);
        entity.Property(u => u.Nome).IsRequired().HasMaxLength(100);
        entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
        entity.HasIndex(u => u.Email).IsUnique();
        entity.Property(u => u.HashSenha).IsRequired().HasMaxLength(255);
        entity.Property(u => u.CriadoEm).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.HasMany(u => u.Jogadores)
            .WithOne(j => j.Usuario)
            .HasForeignKey(j => j.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    });
}
```

### 2. Jogador

```csharp
private static void ConfigureJogador(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Jogador>(entity =>
    {
        entity.HasKey(j => j.Id);
        entity.Property(j => j.NomeExibicao).IsRequired().HasMaxLength(100);
        entity.Property(j => j.UsuarioId).IsRequired();
        entity.HasMany(j => j.Participacoes)
            .WithOne(p => p.Jogador)
            .HasForeignKey(p => p.JogadorId)
            .OnDelete(DeleteBehavior.Cascade);
    });
}
```

### 3. Partida

```csharp
private static void ConfigurePartida(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Partida>(entity =>
    {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.IniciadoEm).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.Property(p => p.Status).IsRequired().HasConversion<int>();
        entity.Property(p => p.PontuacaoAlvo).IsRequired().HasDefaultValue(50);
        entity.HasMany(p => p.Participacoes)
            .WithOne(pp => pp.Partida)
            .HasForeignKey(pp => pp.PartidaId)
            .OnDelete(DeleteBehavior.Cascade);
    });
}
```

### 4. ParticipacaoPartida

```csharp
private static void ConfigureParticipacaoPartida(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ParticipacaoPartida>(entity =>
    {
        entity.HasKey(pp => pp.Id);
        entity.Property(pp => pp.PartidaId).IsRequired();
        entity.Property(pp => pp.JogadorId).IsRequired();
        entity.Property(pp => pp.Posicao).IsRequired();
        entity.Property(pp => pp.Pontuacao).IsRequired().HasDefaultValue(0);
        entity.Property(pp => pp.Vencedor).IsRequired().HasDefaultValue(false);
        entity.HasIndex(pp => new { pp.PartidaId, pp.JogadorId }).IsUnique();
    });
}
```

---

## 🎯 CAMADA DE SERVICES (DI)

### Exemplo de Service com DI

```csharp
public class PartidaService : IPartidaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PartidaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Partida> CriarPartidaAsync(int pontuacaoAlvo = 50, CancellationToken cancellationToken = default)
    {
        if (pontuacaoAlvo <= 0)
            throw new ArgumentException("Pontuação alvo deve ser maior que 0", nameof(pontuacaoAlvo));

        var partida = new Partida
        {
            PontuacaoAlvo = pontuacaoAlvo,
            Status = StatusPartida.AguardandoJogadores,
            IniciadoEm = DateTime.Now
        };

        await _unitOfWork.Partidas.AddAsync(partida, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return partida;
    }

    public async Task<bool> IniciarPartidaAsync(Guid partidaId, CancellationToken cancellationToken = default)
    {
        var partida = await _unitOfWork.Partidas.GetByIdAsync(partidaId, cancellationToken);
        if (partida == null)
            return false;

        if (partida.Status != StatusPartida.AguardandoJogadores)
            throw new InvalidOperationException("Partida não pode ser iniciada.");

        var totalParticipantes = await _unitOfWork.ParticipacoesPartidas
            .GetTotalParticipantesAsync(partidaId, cancellationToken);
        
        if (totalParticipantes < 2)
            throw new InvalidOperationException("Partida precisa de pelo menos 2 participantes.");

        partida.Status = StatusPartida.EmAndamento;
        _unitOfWork.Partidas.Update(partida);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
```

---

## 🔐 AUTENTICAÇÃO JWT

### Como funciona o fluxo

```
1. Cliente faz POST /api/auth/login com { email, senha }
2. API valida as credenciais e retorna um Bearer Token JWT
3. Cliente inclui o token no header: Authorization: Bearer <token>
4. Endpoints protegidos com [Authorize] validam o token automaticamente
```

### IJwtService.cs

```csharp
public interface IJwtService
{
    string GerarToken(Usuario usuario);
}
```

### JwtService.cs

```csharp
public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"]!;
        var issuer    = jwtSettings["Issuer"]!;
        var audience  = jwtSettings["Audience"]!;
        var expiresInMinutes = int.Parse(jwtSettings["ExpiresInMinutes"]!);

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Name, usuario.Nome)
        };

        var token = new JwtSecurityToken(
            issuer:             issuer,
            audience:           audience,
            claims:             claims,
            expires:            DateTime.UtcNow.AddMinutes(expiresInMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
```

### AuthController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IJwtService _jwtService;

    public AuthController(IUsuarioService usuarioService, IJwtService jwtService)
    {
        _usuarioService = usuarioService;
        _jwtService     = jwtService;
    }

    // POST: api/auth/login
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var usuario = await _usuarioService.AutenticarAsync(request.Email, request.Senha);
        if (usuario == null)
            return Unauthorized(new { error = "Email ou senha inválidos" });

        var token = _jwtService.GerarToken(usuario);

        return Ok(new LoginResponse
        {
            Token     = token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),
            Nome      = usuario.Nome,
            Email     = usuario.Email
        });
    }
}
```

### appsettings.json (JwtSettings)

```json
{
  "JwtSettings": {
    "SecretKey": "chave-secreta-super-segura-domino-ponta-de-quina-2026",
    "Issuer": "DominoPontaDeQuina.API",
    "Audience": "DominoPontaDeQuina.Client",
    "ExpiresInMinutes": "60"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=../DominoPontaDeQuina.Migrations/domino.db"
  }
}
```

---

## 🎯 CONTROLLERS E ENDPOINTS (Web API)

### UsuarioController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET: api/usuario
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UsuarioDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.ObterTodosUsuariosAsync();
        return Ok(usuarios.Select(u => u.ToDto()));
    }

    // GET: api/usuario/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
        if (usuario == null)
            return NotFound($"Usuário com ID {id} não encontrado");

        return Ok(usuario.ToDto());
    }

    // POST: api/usuario
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create([FromBody] CriarUsuarioRequest request)
    {
        try
        {
            var usuario = await _usuarioService.CriarUsuarioAsync(
                request.Nome,
                request.Email,
                request.Senha);

            return CreatedAtAction(
                nameof(GetById),
                new { id = usuario.Id },
                usuario.ToDto());
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
    }

    // PUT: api/usuario/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] AtualizarUsuarioRequest request)
    {
        var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
        if (usuario == null)
            return NotFound($"Usuário com ID {id} não encontrado");

        usuario.Nome = request.Nome;
        usuario.Email = request.Email;

        await _usuarioService.AtualizarUsuarioAsync(usuario);
        return NoContent();
    }

    // DELETE: api/usuario/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _usuarioService.DeletarUsuarioAsync(id);
        if (!result)
            return NotFound($"Usuário com ID {id} não encontrado");

        return NoContent();
    }
}
```

### PartidaController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class PartidaController : ControllerBase
{
    private readonly IPartidaService _partidaService;

    public PartidaController(IPartidaService partidaService)
    {
        _partidaService = partidaService;
    }

    // GET: api/partida
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PartidaDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromQuery] StatusPartida? status = null,
        [FromQuery] int? pontuacaoMinima = null)
    {
        IEnumerable<Partida> partidas;

        if (status.HasValue)
        {
            partidas = await _partidaService.ObterPartidasPorStatusAsync(status.Value);
        }
        else if (pontuacaoMinima.HasValue)
        {
            partidas = await _partidaService.ObterPartidasComPontuacaoAcimaAsync(pontuacaoMinima.Value);
        }
        else
        {
            partidas = await _partidaService.ObterPartidasFinalizadasAsync();
        }

        return Ok(partidas.Select(p => p.ToDto()));
    }

    // GET: api/partida/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PartidaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var partida = await _partidaService.ObterPartidaPorIdAsync(id);
        if (partida == null)
            return NotFound($"Partida com ID {id} não encontrada");

        return Ok(partida.ToDto());
    }

    // GET: api/partida/jogador/{jogadorId}
    [HttpGet("jogador/{jogadorId}")]
    [ProducesResponseType(typeof(IEnumerable<PartidaDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByJogador(Guid jogadorId)
    {
        var partidas = await _partidaService.ObterPartidasPorJogadorAsync(jogadorId);
        return Ok(partidas.Select(p => p.ToDto()));
    }

    // POST: api/partida
    [HttpPost]
    [ProducesResponseType(typeof(PartidaDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CriarPartidaRequest request)
    {
        try
        {
            var partida = await _partidaService.CriarPartidaAsync(request.PontuacaoAlvo);
            return CreatedAtAction(
                nameof(GetById),
                new { id = partida.Id },
                partida.ToDto());
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // POST: api/partida/{id}/iniciar
    [HttpPost("{id}/iniciar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Iniciar(Guid id)
    {
        var partida = await _partidaService.ObterPartidaPorIdAsync(id);
        if (partida == null)
            return NotFound($"Partida com ID {id} não encontrada");

        try
        {
            await _partidaService.IniciarPartidaAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // POST: api/partida/{id}/finalizar
    [HttpPost("{id}/finalizar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Finalizar(Guid id)
    {
        var partida = await _partidaService.ObterPartidaPorIdAsync(id);
        if (partida == null)
            return NotFound($"Partida com ID {id} não encontrada");

        try
        {
            await _partidaService.FinalizarPartidaAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
```

### ParticipacaoController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class ParticipacaoController : ControllerBase
{
    private readonly IParticipacaoService _participacaoService;

    public ParticipacaoController(IParticipacaoService participacaoService)
    {
        _participacaoService = participacaoService;
    }

    // GET: api/participacao/partida/{partidaId}
    [HttpGet("partida/{partidaId}")]
    [ProducesResponseType(typeof(IEnumerable<ParticipacaoDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPartida(Guid partidaId)
    {
        var participacoes = await _participacaoService.ObterParticipacoesPorPartidaAsync(partidaId);
        return Ok(participacoes.Select(p => p.ToDto()));
    }

    // GET: api/participacao/jogador/{jogadorId}
    [HttpGet("jogador/{jogadorId}")]
    [ProducesResponseType(typeof(IEnumerable<ParticipacaoDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByJogador(Guid jogadorId)
    {
        var participacoes = await _participacaoService.ObterParticipacoesPorJogadorAsync(jogadorId);
        return Ok(participacoes.Select(p => p.ToDto()));
    }

    // POST: api/participacao
    [HttpPost]
    [ProducesResponseType(typeof(ParticipacaoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddParticipante([FromBody] AdicionarParticipanteRequest request)
    {
        try
        {
            var participacao = await _participacaoService.AdicionarParticipanteAsync(
                request.PartidaId,
                request.JogadorId,
                request.Posicao);

            return CreatedAtAction(
                nameof(GetByPartida),
                new { partidaId = request.PartidaId },
                participacao.ToDto());
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PATCH: api/participacao/atualizar-pontuacao
    [HttpPatch("atualizar-pontuacao")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarPontuacao([FromBody] AtualizarPontuacaoRequest request)
    {
        try
        {
            var result = await _participacaoService.AtualizarPontuacaoAsync(
                request.PartidaId,
                request.JogadorId,
                request.NovaPontuacao);

            if (!result)
                return NotFound("Participação não encontrada");

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PATCH: api/participacao/definir-vencedor
    [HttpPatch("definir-vencedor")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DefinirVencedor([FromBody] DefinirVencedorRequest request)
    {
        try
        {
            var result = await _participacaoService.DefinirVencedorAsync(
                request.PartidaId,
                request.JogadorId);

            if (!result)
                return NotFound("Participação não encontrada");

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE: api/participacao
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverParticipante(Guid partidaId, Guid jogadorId)
    {
        var result = await _participacaoService.RemoverParticipanteAsync(partidaId, jogadorId);
        if (!result)
            return NotFound("Participação não encontrada");

        return NoContent();
    }
}
```

---

## 📦 DTOs (Data Transfer Objects)

### UsuarioDto.cs
```csharp
public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
    public List<JogadorDto> Jogadores { get; set; } = new();
}
```

### CriarUsuarioRequest.cs
```csharp
public class CriarUsuarioRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
```

### PartidaDto.cs
```csharp
public class PartidaDto
{
    public Guid Id { get; set; }
    public DateTime IniciadoEm { get; set; }
    public DateTime? FinalizadoEm { get; set; }
    public string Status { get; set; } = string.Empty;
    public int PontuacaoAlvo { get; set; }
    public List<ParticipacaoDto> Participacoes { get; set; } = new();
}
```

---

## 📦 REPOSITORIES COM LINQ

### Exemplo de Consultas LINQ

```csharp
// PartidaRepository.cs
public async Task<IEnumerable<Partida>> GetByJogadorAsync(Guid jogadorId, CancellationToken cancellationToken = default)
{
    return await _dbSet
        .Where(p => p.Participacoes.Any(pp => pp.JogadorId == jogadorId))
        .Include(p => p.Participacoes)
            .ThenInclude(pp => pp.Jogador)
        .OrderByDescending(p => p.IniciadoEm)
        .ToListAsync(cancellationToken);
}

public async Task<IEnumerable<Partida>> GetPartidasComPontuacaoAcimaAsync(int pontuacaoMinima, CancellationToken cancellationToken = default)
{
    return await _dbSet
        .Where(p => p.Participacoes.Any(pp => pp.Pontuacao > pontuacaoMinima))
        .Include(p => p.Participacoes)
        .OrderByDescending(p => p.IniciadoEm)
        .ToListAsync(cancellationToken);
}
```

```csharp
// JogadorRepository.cs
public async Task<IEnumerable<Jogador>> GetJogadoresRankingAsync(CancellationToken cancellationToken = default)
{
    return await _dbSet
        .Include(j => j.Participacoes)
        .Select(j => new
        {
            Jogador = j,
            PontuacaoTotal = j.Participacoes.Sum(pp => pp.Pontuacao)
        })
        .OrderByDescending(x => x.PontuacaoTotal)
        .Select(x => x.Jogador)
        .ToListAsync(cancellationToken);
}
```

---

## 🔧 REGISTRO DE SERVIÇOS (DI) - Web API

### Program.cs com Configuração Completa

```csharp
using DominoPontaDeQuina.API.Extensions;
using DominoPontaDeQuina.API.Services;
using DominoPontaDeQuina.Repository.Extensions;
using DominoPontaDeQuina.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração de Controllers
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .Select(e => new
                {
                    Field = e.Key,
                    Errors = e.Value?.Errors.Select(x => x.ErrorMessage)
                });

            return new BadRequestObjectResult(new
            {
                error = "Dados inválidos",
                details = errors
            });
        };
    });

// Configuração JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey   = jwtSettings["SecretKey"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = true,
        ValidateAudience         = true,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer              = jwtSettings["Issuer"],
        ValidAudience            = jwtSettings["Audience"],
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IJwtService, JwtService>();

// Configuração de Swagger com suporte a Bearer Token
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DominoPontaDeQuina API",
        Version = "v1",
        Description = "API para gerenciamento de jogos de dominó Ponta de Quina",
        Contact = new OpenApiContact
        {
            Name = "Isadora Meneghetti",
            Email = "isadora@email.com"
        }
    });

    // Configuração do Bearer Token no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name         = "Authorization",
        Type         = SecuritySchemeType.ApiKey,
        Scheme       = "Bearer",
        BearerFormat = "JWT",
        In           = ParameterLocation.Header,
        Description  = "Insira o token JWT no formato: Bearer {seu token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Registro de dependências
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=../DominoPontaDeQuina.Migrations/domino.db";

builder.Services.AddRepositoryServices(connectionString);
builder.Services.AddServices();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DominoPontaDeQuina API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication(); // 🆕 Deve vir antes de UseAuthorization
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DominoDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.Run();
```

### Repository Extensions

```csharp
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DominoDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IJogadorRepository, JogadorRepository>();
        services.AddScoped<IPartidaRepository, PartidaRepository>();
        services.AddScoped<IParticipacaoPartidaRepository, ParticipacaoPartidaRepository>();

        return services;
    }
}
```

### Service Extensions

```csharp
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IJogadorService, JogadorService>();
        services.AddScoped<IPartidaService, PartidaService>();
        services.AddScoped<IParticipacaoService, ParticipacaoService>();

        return services;
    }
}
```

---

## 📊 EXEMPLOS DE REQUISIÇÕES E RESPOSTAS

### Login (Obter Token JWT)

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "joao@email.com",
  "senha": "senha123"
}
```

**Resposta (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2026-09-14T15:30:00Z",
  "nome": "João Silva",
  "email": "joao@email.com"
}
```

### Usar o Token em endpoints protegidos

```http
GET /api/jogador
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

---

### Criar um Usuário

```http
POST /api/usuario
Content-Type: application/json

{
  "nome": "João Silva",
  "email": "joao@email.com",
  "senha": "senha123"
}
```

**Resposta (201 Created):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nome": "João Silva",
  "email": "joao@email.com",
  "criadoEm": "2026-09-09T14:30:00Z",
  "jogadores": []
}
```

### Criar uma Partida

```http
POST /api/partida
Content-Type: application/json

{
  "pontuacaoAlvo": 50
}
```

**Resposta (201 Created):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "iniciadoEm": "2026-09-09T14:30:00Z",
  "finalizadoEm": null,
  "status": "AguardandoJogadores",
  "pontuacaoAlvo": 50,
  "participacoes": []
}
```

### Adicionar Participante

```http
POST /api/participacao
Content-Type: application/json

{
  "partidaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "jogadorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "posicao": 1
}
```

### Iniciar Partida

```http
POST /api/partida/{id}/iniciar
```

### Listar Partidas por Status

```http
GET /api/partida?status=EmAndamento
```

### Listar Partidas com Pontuação Acima de

```http
GET /api/partida?pontuacaoMinima=20
```

---

## 📱 SWAGGER UI

A API inclui documentação interativa via Swagger UI, disponível em:

```
https://localhost:5001/swagger
```

### Swagger UI Features:
- ✅ Documentação completa de todos os endpoints
- ✅ Schemas de requisição e resposta
- ✅ Try-it-out para testes direto no navegador
- ✅ Status codes HTTP documentados
- ✅ Informações de contato e versão
- ✅ **Botão "Authorize"** para inserir o Bearer Token JWT

---

## 🧪 TESTES UNITÁRIOS COM MOCKS

### Exemplo de Teste do Controller

```csharp
public class PartidaControllerTests
{
    private readonly Mock<IPartidaService> _partidaServiceMock;
    private readonly PartidaController _controller;

    public PartidaControllerTests()
    {
        _partidaServiceMock = new Mock<IPartidaService>();
        _controller = new PartidaController(_partidaServiceMock.Object);
    }

    [Fact]
    public async Task GetById_QuandoPartidaExiste_DeveRetornarOk()
    {
        // Arrange
        var partidaId = Guid.NewGuid();
        var partida = new Partida { Id = partidaId, Status = StatusPartida.AguardandoJogadores };
        _partidaServiceMock.Setup(s => s.ObterPartidaPorIdAsync(partidaId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(partida);

        // Act
        var result = await _controller.GetById(partidaId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var dto = Assert.IsType<PartidaDto>(okResult.Value);
        Assert.Equal(partidaId, dto.Id);
    }

    [Fact]
    public async Task GetById_QuandoPartidaNaoExiste_DeveRetornarNotFound()
    {
        // Arrange
        var partidaId = Guid.NewGuid();
        _partidaServiceMock.Setup(s => s.ObterPartidaPorIdAsync(partidaId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Partida?)null);

        // Act
        var result = await _controller.GetById(partidaId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task Create_QuandoValido_DeveRetornarCreated()
    {
        // Arrange
        var request = new CriarPartidaRequest { PontuacaoAlvo = 50 };
        var partida = new Partida { Id = Guid.NewGuid(), PontuacaoAlvo = 50 };
        _partidaServiceMock.Setup(s => s.CriarPartidaAsync(request.PontuacaoAlvo, It.IsAny<CancellationToken>()))
            .ReturnsAsync(partida);

        // Act
        var result = await _controller.Create(request);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var dto = Assert.IsType<PartidaDto>(createdResult.Value);
        Assert.Equal(partida.PontuacaoAlvo, dto.PontuacaoAlvo);
    }
}
```

---

## 🔧 COMANDOS DE MIGRAÇÃO

```bash
# Instalar a ferramenta globalmente
dotnet tool install --global dotnet-ef

# Criar a migração inicial
cd DominoPontaDeQuina.Migrations
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project ..

# Aplicar a migração ao banco
dotnet ef database update --context DominoDbContext --startup-project ..

# Remover a última migração (não aplicada)
dotnet ef migrations remove --context DominoDbContext --startup-project ..

# Gerar script SQL da migração
dotnet ef migrations script --context DominoDbContext --startup-project ..

# Listar migrações aplicadas
dotnet ef migrations list --context DominoDbContext --startup-project ..
```

---

## 🚀 COMO EXECUTAR

### Pré-requisitos

- .NET SDK 8.0 ou superior
- Git (para clonar o repositório)
- Navegador web (para Swagger UI)

### Passos

```bash
# 1. Clonar o repositório
git clone https://github.com/seu-usuario/DominoPontaDeQuina.git
cd DominoPontaDeQuina

# 2. Restaurar pacotes
dotnet restore

# 3. Construir a solução
dotnet build

# 4. Entrar na pasta de migrações
cd DominoPontaDeQuina.Migrations

# 5. Criar a migration
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project ..

# 6. Aplicar a migration
dotnet ef database update --context DominoDbContext --startup-project ..

# 7. Voltar para a raiz
cd ..

# 8. Executar a Web API
cd DominoPontaDeQuina.API
dotnet run

# 9. Acessar a documentação Swagger
# Abrir no navegador: https://localhost:5001/swagger

# 10. Executar os testes
cd ..
dotnet test

# 11. Executar testes com cobertura
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

---

## 📊 SAÍDA ESPERADA

### Swagger UI

Ao acessar `https://localhost:5001/swagger`, você verá:

```
DominoPontaDeQuina API v1
API para gerenciamento de jogos de dominó Ponta de Quina

📋 Controllers:
  - GET /api/usuario        Lista todos os usuários
  - GET /api/usuario/{id}   Busca usuário por ID
  - POST /api/usuario       Cria um novo usuário
  - PUT /api/usuario/{id}   Atualiza um usuário
  - DELETE /api/usuario/{id} Deleta um usuário

  - GET /api/jogador        Lista todos os jogadores
  - GET /api/jogador/{id}   Busca jogador por ID
  - GET /api/jogador/usuario/{usuarioId}  Busca jogadores por usuário
  - GET /api/jogador/ranking  Ranking de jogadores
  - POST /api/jogador       Cria um novo jogador
  - PUT /api/jogador/{id}   Atualiza um jogador
  - DELETE /api/jogador/{id} Deleta um jogador

  - GET /api/partida        Lista partidas (com filtros)
  - GET /api/partida/{id}   Busca partida por ID
  - GET /api/partida/jogador/{jogadorId}  Busca partidas por jogador
  - POST /api/partida       Cria uma nova partida
  - POST /api/partida/{id}/iniciar   Inicia uma partida
  - POST /api/partida/{id}/finalizar  Finaliza uma partida

  - GET /api/participacao/partida/{partidaId}  Participações por partida
  - GET /api/participacao/jogador/{jogadorId}  Participações por jogador
  - POST /api/participacao  Adiciona participante
  - PATCH /api/participacao/atualizar-pontuacao  Atualiza pontuação
  - PATCH /api/participacao/definir-vencedor   Define vencedor
  - DELETE /api/participacao  Remove participante
```

### Console da API

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /path/to/DominoPontaDeQuina.API
```

---

## 🧪 RESULTADO DOS TESTES

| Categoria | Testes | Status |
|-----------|--------|--------|
| Básicos | 44 | ✅ Passando |
| Exceção | 8 | ✅ Passando |
| Gap | 26 | ✅ Passando |
| Services | 12 | ✅ Passando |
| Controllers (novos) | 16 | ✅ Passando |
| **Total** | **106** | **✅ 100% Passando** |

---

## 📈 APRENDIZADOS

### Primeiro Semestre
1. **Organização de código** - Separação em camadas (Core, Domain, Repository, Migrations)
2. **Entity Framework Core** - ORM para mapeamento objeto-relacional
3. **Fluent API** - Configuração programática de entidades
4. **Migrations** - Versionamento e evolução do esquema do banco
5. **SQLite** - Banco de dados leve embarcado
6. **Relacionamentos** - 1:N e N:1 com EF Core
7. **Repository Pattern** - Encapsulamento da lógica de acesso a dados
8. **Unit of Work** - Gerenciamento de transações e repositórios
9. **LINQ** - Consultas avançadas com Includes, Filters e Aggregations

### Segundo Semestre (Laboratório DI)
10. **Injeção de Dependência (DI)** - Desacoplamento e testabilidade
11. **Inversão de Controle (IoC)** - Container gerencia o ciclo de vida
12. **Interfaces** - Definição de contratos para repositories e services
13. **Services Layer** - Orquestração de regras de negócio
14. **Testes com Mocks** - Uso do Moq para testes unitários isolados
15. **Host Builder** - Configuração centralizada da aplicação

### Laboratório Web API
16. **ASP.NET Core Web API** - Construção de APIs RESTful
17. **Swagger/OpenAPI** - Documentação interativa de APIs
18. **DTOs** - Data Transfer Objects para comunicação entre camadas
19. **Status Codes HTTP** - Padrões de resposta RESTful (200, 201, 204, 400, 404, 409, 500)
20. **Controllers** - Organização de endpoints por recurso
21. **Routing** - Definição de rotas RESTful
22. **Model Binding** - Vinculação de parâmetros de requisição
23. **CORS** - Configuração para consumo por aplicações front-end
24. **API Versioning** - Versionamento de APIs

### Laboratório JWT Authentication
25. **JWT (JSON Web Token)** - Padrão de autenticação stateless
26. **Bearer Token** - Esquema de autenticação via header HTTP
27. **Claims** - Informações embutidas no token (id, email, nome)
28. **SymmetricSecurityKey** - Chave secreta para assinatura do token
29. **JwtBearerDefaults** - Middleware de validação automática de tokens
30. **[Authorize]** - Proteção declarativa de endpoints
31. **Swagger Bearer** - Configuração do botão "Authorize" no Swagger UI
32. **UseAuthentication / UseAuthorization** - Ordem correta no pipeline

---

## 🔗 LINKS ÚTEIS

- [Documentação EF Core](https://learn.microsoft.com/pt-br/ef/core/)
- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [SQLite](https://www.sqlite.org/index.html)
- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/devlooped/moq)
- [.NET Download](https://dotnet.microsoft.com/download)
- [Dependency Injection in .NET](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection)
- [ASP.NET Core Web API](https://learn.microsoft.com/pt-br/aspnet/core/web-api/)
- [Swagger/OpenAPI](https://swagger.io/docs/specification/about/)

---

## 📊 CHANGELOG

| Versão | Data | Alterações |
|--------|------|------------|
| 1.0.0 | 25/08/2026 | Versão inicial com EF Core e Fluent API |
| 2.0.0 | 01/09/2026 | Adicionado DI, Services Layer e testes com Moq |
| 3.0.0 | 09/09/2026 | Adicionado Web API, Controllers, DTOs e Swagger |
| 4.0.0 | 14/09/2026 | Adicionado autenticação JWT, AuthController e proteção de endpoints |

---

## 📝 LICENÇA

Este projeto foi desenvolvido para fins educacionais na **FIAP - Faculdade de Informática e Administração Paulista**.

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ por <b>Isadora Meneghetti</b><br>
  © 2026 - Todos os direitos reservados
</p>
