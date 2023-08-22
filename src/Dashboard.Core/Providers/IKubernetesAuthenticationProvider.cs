using k8s;

namespace Dashboard.Core.Providers;

public interface IKubernetesAuthenticationProvider 
{
    ValueTask<IKubernetes> Authenticate();
}