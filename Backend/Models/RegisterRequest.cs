namespace ProjectProsperity.Models;

public record RegisterRequest {
    public string Username { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }
    public string Name { get; init; }

    public string Description => $"username: {Username}; password: {Password}; email {Email}; name: {Name}";
}

public record LoginRequest {
    public string Username { get; init; }
    public string Password { get; init; }
    public string Description => $"username: {Username}; password: {Password}";
}