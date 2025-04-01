
namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1PersistentVolumeClaimVolumeSource : KadenseTemplatedCopiedResource<k8s.Models.V1PersistentVolumeClaimVolumeSource>
    {
        public string? ClaimName { get; set; }
        public bool? ReadOnly { get; set; }

        public override k8s.Models.V1PersistentVolumeClaimVolumeSource ToOriginal(Dictionary<string, string> variables)
        {
            return new k8s.Models.V1PersistentVolumeClaimVolumeSource(
                claimName: this.GetValue(this.ClaimName, variables),
                readOnlyProperty: this.ReadOnly
            );
        }
    }
}