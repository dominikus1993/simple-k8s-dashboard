namespace Dashboard.Core.Providers;

public sealed record Namespace(string Name);

public interface INamespaceProvider
{
    IAsyncEnumerable<Namespace> GetNamespaces(CancellationToken cancellationToken = default);
}