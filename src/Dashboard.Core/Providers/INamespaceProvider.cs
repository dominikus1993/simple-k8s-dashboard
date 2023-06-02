using k8s;

namespace Dashboard.Core.Providers;

public sealed record Namespace(string Name);

public interface INamespaceProvider
{
    IAsyncEnumerable<Namespace> GetNamespaces(IKubernetes client, CancellationToken cancellationToken = default);
}