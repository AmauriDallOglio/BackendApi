using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Dominio.Modelo
{
    public abstract class BaseIdEntity
    {
        public Guid Id { get; set; }
 
        //public Guid IdUsuario { get; set; }
    }
}
