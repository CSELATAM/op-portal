using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;
using OpPortal.Models;

namespace OpPortal.Services
{
    public class DeployService
    {
        const string DEFAULT_NAMESPACE = "default";
        private Kubernetes _client;

        public DeployService()
        {
            // default configuration
            var config = new KubernetesClientConfiguration { Host = "http://127.0.0.1:8001" };

            try
            {
                config = KubernetesClientConfiguration.InClusterConfig();
            } 
            catch (k8s.Exceptions.KubeConfigException)
            {
                Console.WriteLine("Running in Localhost mode");
            }

            this._client = new Kubernetes(config);
        }

        public string Create(string filename)
        {
            return CreateDeployment(filename);
        }

        public IEnumerable<TenantDescription> ListTenants()
        {
            var appList = new List<TenantDescription>{
                new TenantDescription { Id = "ten1", Name = "App1" },
                new TenantDescription { Id = "ten2", Name = "App2" },
                new TenantDescription { Id = "ten3", Name = "App3" }
            };

            return appList;
        }

        string CreateDeployment(string filename)
        {
            var yml = Yaml.LoadFromFileAsync<V1Deployment>(filename).Result;

            var ymlResult = _client.CreateNamespacedDeployment(yml, DEFAULT_NAMESPACE);

            return ymlResult.Metadata.ClusterName;
        }

        string CreatePod(string filename)
        {
            var yml = Yaml.LoadFromFileAsync<V1Pod>(filename).Result;

            var ymlResult = _client.CreateNamespacedPod(yml, DEFAULT_NAMESPACE);

            return ymlResult.Metadata.Name;
        }
    }
}
