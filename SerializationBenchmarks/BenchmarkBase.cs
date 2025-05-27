public abstract class BenchmarkBase
{
    protected readonly UserModel _user = new()
    {
        Id = 1,
        Name = "Alice",
        IsActive = true,
        CreatedAt = DateTime.UtcNow
    };
}
