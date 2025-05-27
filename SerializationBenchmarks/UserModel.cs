using MessagePack;

[MessagePackObject]
public class UserModel
{
    [Key(0)]
    public int Id { get; set; }

    [Key(1)]
    public string Name { get; set; } = "";

    [Key(2)]
    public bool IsActive { get; set; }

    [Key(3)]
    public DateTime CreatedAt { get; set; }
}
