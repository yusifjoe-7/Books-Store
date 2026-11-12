namespace BooksStore.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? HashedPassword { get; set; }
    public string Roule { get; set; } = "User";
    public ICollection<RefreshToken> RefreshTokens {get; set;} = new List<RefreshToken> ();
}
