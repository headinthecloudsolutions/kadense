namespace Kadense.Models.Kubernetes.CoreApi
{
    public class V1PodAntiAffinity
    {
        public List<V1WeightedPodAffinityTerm>? RequiredDuringSchedulingIgnoredDuringExecution { get; set; }
        public List<V1PodAffinityTerm>? PreferredDuringSchedulingIgnoredDuringExecution { get; set; }
    }
}