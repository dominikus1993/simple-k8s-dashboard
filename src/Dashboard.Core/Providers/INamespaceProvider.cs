using k8s;

namespace Dashboard.Core.Providers;

public sealed record KubernetesNamespace(string Name);

public interface INamespaceProvider
{
    IAsyncEnumerable<KubernetesNamespace> GetNamespaces(IKubernetes client, CancellationToken cancellationToken = default);
}