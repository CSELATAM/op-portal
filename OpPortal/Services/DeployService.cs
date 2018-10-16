using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;

namespace OpPortal.Services
{
    public class DeployService
    {
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
    }
}
