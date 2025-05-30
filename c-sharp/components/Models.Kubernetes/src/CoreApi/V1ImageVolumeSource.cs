namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1ImageVolumeSource: KadenseTemplatedCopiedResource<k8s.Models.V1ImageVolumeSource>
    {
        [JsonPropertyName("pullPolicy")]
        public string? PullPolicy { get; set; }

        [JsonPropertyName("reference")]
        public string? Reference { get; set; }

        public override k8s.Models.V1ImageVolumeSource ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1ImageVolumeSource(
                pullPolicy: this.GetValue(this.PullPolicy, variables),
                reference: this.GetValue(this.Reference, variables)
            );
        }
    }
}