using k8s;
using Kadense.Models.Kubernetes;
using Kadense.Models.Kubernetes.CoreApi;
using Kadense.Client.Kubernetes;

namespace Kadense.Models.Jupyternetes.Tests {
    public class CustomResourceTestUtils
    {
        public IKubernetes CreateClient()
        {
            KubernetesClientFactory clientFactory = new KubernetesClientFactory();
            return clientFactory.CreateClient();
        }

        public async Task CreateOrUpdateItem<T>(T item)
            where T : KadenseCustomResource
        {
            var client = CreateClient();
            var crFactory = new CustomResourceClientFactory();
            var genericClient = crFactory.Create<T>(client);
            var existingItems = await genericClient.ListNamespacedAsync(item.Metadata.NamespaceProperty);
            var filteredItems = existingItems.Items
                .Where(x => x.Metadata.Name == item.Metadata.Name)
                .ToList();
            if (filteredItems.Count > 0)
            {
                item.Metadata.ResourceVersion = filteredItems.First().Metadata.ResourceVersion;
                await genericClient.ReplaceNamespacedAsync(item);
            }
            else
            {
                var createdItem = await genericClient.CreateNamespacedAsync(item);
            } 
        }
        

        public async Task CreateCrdAsync<T>()
        {
            var client = CreateClient();

            CustomResourceDefinitionFactory crdFactory = new CustomResourceDefinitionFactory();
            var crd = crdFactory.Create<T>();

            //GenericClient genericClient = new GenericClient(client, "apiextensions.k8s.io","v1","customresourcedefinitions");
            //var crds = await genericClient.ListAsync<k8s.Models.V1CustomResourceDefinitionList>();
            var crds = await client.ApiextensionsV1.ListCustomResourceDefinitionAsync();
            var items = crds.Items
                .Where(x => x.Metadata.Name == crd.Metadata.Name)
                .ToList();

            if (items.Count > 0)
            {
                // Delete the CRD
                crd.Metadata.ResourceVersion = items.First().Metadata.ResourceVersion;
                //await genericClient.ReplaceAsync<k8s.Models.V1CustomResourceDefinition>(crd, crd.Metadata.Name);
                await client.ApiextensionsV1.ReplaceCustomResourceDefinitionAsync(crd, crd.Metadata.Name);
            }
            else
            {
                // var createdCrd = await genericClient.CreateAsync<k8s.Models.V1CustomResourceDefinition>(crd);
                await client.ApiextensionsV1.CreateCustomResourceDefinitionAsync(crd);
            }
        }

        public virtual JupyterNotebookInstance CreateInstance(string instanceName = "test-instance", string templateName = "test-template")
        {
            var variables = new Dictionary<string, string>();
            variables.Add("test", "test2");

            return new JupyterNotebookInstance()
            {
                Metadata = new k8s.Models.V1ObjectMeta(){
                    Name = instanceName,
                    NamespaceProperty = "default"
                },
                Spec = new JupyterNotebookInstanceSpec()
                {
                    Template = new NotebookTemplate(){
                        Name = templateName
                    },
                    Variables = variables
                }
            };
        }

        public virtual JupyterNotebookTemplate CreateTemplate(string templateName = "test-template")
        {
            return new JupyterNotebookTemplate()
            {
                Metadata = new k8s.Models.V1ObjectMeta(){
                    Name = templateName,
                    NamespaceProperty = "default"
                },
                Spec = new JupyterNotebookTemplateSpec()
                {
                    Pods = new List<NotebookTemplatePodSpec>(){
                        new NotebookTemplatePodSpec(){
                            Name = "test-pod",
                            Labels = new Dictionary<string, string>()
                            {
                                { "jupyternetes.kadense.io/testProperty" , "{test}-instance" }
                            },
                            Spec = new V1PodSpec()
                            {
                                Containers = new List<V1Container>()
                                {
                                    new V1Container() {
                                        Name = "test-container",
                                        Image = "who-knows" 
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

    }
}