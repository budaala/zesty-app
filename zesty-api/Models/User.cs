namespace zesty_api.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}