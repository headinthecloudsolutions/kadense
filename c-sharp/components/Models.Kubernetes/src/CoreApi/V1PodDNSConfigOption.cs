
namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1PodDNSConfigOption : KadenseTemplatedCopiedResource<k8s.Models.V1PodDNSConfigOption>
    {
        public string? Name { get; set; }
        public string? Value { get; set; }

        public override k8s.Models.V1PodDNSConfigOption ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1PodDNSConfigOption(
                name: this.GetValue(this.Name, variables),
                value: this.GetValue(this.Value, variables)
            );
        }
    }
}