namespace zesty_api.Data.Entities;

public class UserEntity
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public ICollection<CommentEntity> Comments { get; init; } = new List<CommentEntity>();

    public static UserEntity Create(string username, string email, string password)
    {
        return new UserEntity
        {
            Username = username,
            Email = email,
            Password = password
        };
    }
}