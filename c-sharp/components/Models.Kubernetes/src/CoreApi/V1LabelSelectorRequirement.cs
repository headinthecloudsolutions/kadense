namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1LabelSelectorRequirement : KadenseTemplatedCopiedResource<k8s.Models.V1LabelSelectorRequirement>
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("operator")]
        public string? Operator { get; set; }

        [JsonPropertyName("values")]
        public List<string>? Values { get; set; }

        public override k8s.Models.V1LabelSelectorRequirement ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1LabelSelectorRequirement(
                key: this.GetValue(this.Key, variables),
                operatorProperty: this.GetValue(this.Operator, variables),
                values: this.GetValue(this.Values, variables)
            );
        }
    }
}