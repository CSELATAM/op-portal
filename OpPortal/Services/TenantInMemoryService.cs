using OpPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpPortal.Services
{
    public class TenantInMemoryService
    {
        int _tenantId = 1;
        List<TenantDescription> _tenantList = new List<TenantDescription>();

        public TenantInMemoryService()
        {
            Create("Application 01");
            Create("Application 02");
            Create("Application 03");
            Create("Application 04");
            Create("Application 05");
        }

        public void Create(string tenantName)
        {
            if (String.IsNullOrEmpty(tenantName))
                throw new ArgumentNullException(nameof(tenantName));

            _tenantList.Add(new TenantDescription
            {
                Id = "tenant" + (_tenantId++).ToString(),
                Name = tenantName
            });
        }

        public IEnumerable<TenantDescription> List()
        {
            return _tenantList;
        }
    }
}
