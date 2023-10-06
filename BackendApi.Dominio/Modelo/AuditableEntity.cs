using BackendApi.Dominio.Entidade;

namespace BackendApi.Dominio.Modelo
{
    public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        public TId Id { get; set; }
    }
}
