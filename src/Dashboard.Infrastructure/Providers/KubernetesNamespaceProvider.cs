using System.Runtime.CompilerServices;
using Dashboard.Core.Providers;
using k8s;
using k8s.Models;

namespace Dashboard.Infrastructure.Providers;

internal sealed class KubernetesNamespaceProvider : INamespaceProvider
{
    public async IAsyncEnumerable<Namespace> GetNamespaces(IKubernetes client, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var namespaces = await client.CoreV1.ListNamespaceAsync(cancellationToken: cancellationToken);

        if (namespaces?.Items is not {Count:>0})
        {
            yield break;
        }
        
        foreach (var k8snamespace in namespaces.Items)
        {
            yield return new Namespace(k8snamespace.Namespace());
        }
    }
}