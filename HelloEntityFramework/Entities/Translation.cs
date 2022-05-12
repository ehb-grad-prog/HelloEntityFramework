namespace HelloEntityFramework.Entities;

public class Translation : Entity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Language { get; set; } = null!;
}
