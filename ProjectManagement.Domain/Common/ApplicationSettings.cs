namespace ProjectManagement.Domain.Common;

public sealed class ApplicationSettings
{
    public DatabaseSettings DatabaseSettings { get; set; } = new();
    public AzureStorage AzureStorage { get; set; } = new();
}

public sealed class DatabaseSettings
{
    public string? ConnectionString { get; set; }
}

public sealed class AzureStorage
{
    public string? ConnectionString { get; set; }
}