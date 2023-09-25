using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Infra.Modelo
{
    public interface ITenantObrigatorio
    {
        Guid TenantId { get; set; }
    }
}
