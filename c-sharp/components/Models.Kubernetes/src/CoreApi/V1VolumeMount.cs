namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1VolumeMount : KadenseTemplatedCopiedResource<k8s.Models.V1VolumeMount>
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("mountPath")]
        public string? MountPath { get; set; }

        [JsonPropertyName("readOnly")]
        public bool? ReadOnly { get; set; }

        [JsonPropertyName("mountPropagation")]
        public string? MountPropagation { get; set; }

        [JsonPropertyName("subPath")]
        public string? SubPath { get; set; }

        [JsonPropertyName("subPathExpr")]
        public string? SubPathExpr { get; set; }

        [JsonPropertyName("recursiveReadOnly")]
        public string? RecursiveReadOnly { get; set; }

        public override k8s.Models.V1VolumeMount ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1VolumeMount(
                name: this.GetValue(this.Name, variables),
                mountPath: this.GetValue(this.MountPath, variables),
                readOnlyProperty: this.ReadOnly,
                mountPropagation: this.GetValue(this.MountPropagation, variables),
                subPath: this.GetValue(this.SubPath, variables),
                subPathExpr: this.GetValue(this.SubPathExpr, variables),
                recursiveReadOnly: this.GetValue(this.RecursiveReadOnly, variables)
            );
        }
    }
}