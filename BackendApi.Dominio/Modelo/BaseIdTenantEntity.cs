using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Dominio.Modelo
{
    public  abstract class BaseIdTenantEntity
    {
        public Guid Id_Tenant { get; set; }
    }
}

 