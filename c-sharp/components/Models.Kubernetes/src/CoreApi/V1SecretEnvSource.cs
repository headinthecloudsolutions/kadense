
namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1SecretEnvSource : KadenseTemplatedCopiedResource<k8s.Models.V1SecretEnvSource>
    {
        public string? Name { get; set; }
        public bool? Optional { get; set; }

        public override k8s.Models.V1SecretEnvSource ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1SecretEnvSource(
                name: this.GetValue(this.Name, variables),
                optional: this.Optional
            );
        }
    }
}