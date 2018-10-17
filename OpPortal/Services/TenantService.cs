using OpPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpPortal.Services
{
    public class TenantService
    {
        DeployService _deploy;

        public TenantService()
        {
            _deploy = new DeployService();
        }

        public void Create(string tenantName)
        {
            if (String.IsNullOrEmpty(tenantName))
                throw new ArgumentNullException(nameof(tenantName));

            _deploy.Create(tenantName, "Definitions/deploy.yaml");
        }

        public IEnumerable<TenantDescription> List()
        {
            return _deploy.ListTenants();
        }
    }
}
