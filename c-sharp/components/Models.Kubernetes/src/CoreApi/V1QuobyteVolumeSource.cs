namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1QuobyteVolumeSource : KadenseTemplatedCopiedResource<k8s.Models.V1QuobyteVolumeSource>
    {
        [JsonPropertyName("registry")]
        public string? Registry { get; set; }

        [JsonPropertyName("readOnly")]
        public bool? ReadOnly { get; set; }

        [JsonPropertyName("user")]
        public string? User { get; set; }

        [JsonPropertyName("group")]
        public string? Group { get; set; }

        [JsonPropertyName("tenant")]
        public string? Tenant { get; set; }

        [JsonPropertyName("volume")]
        public string? Volume { get; set; }

        public override k8s.Models.V1QuobyteVolumeSource ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1QuobyteVolumeSource(
                registry: this.GetValue(this.Registry, variables),
                readOnlyProperty: this.ReadOnly,
                user: this.GetValue(this.User, variables),
                group: this.GetValue(this.Group, variables),
                tenant: this.GetValue(this.Tenant, variables),
                volume: this.GetValue(this.Volume, variables)
            );
        }
    }
}