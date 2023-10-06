namespace BackendApi.Dominio.Entidade
{
    public class Global
    {
        public Guid Id_Tenant_Global { get; set; }
        public Guid Id_Usuario { get; set; }

        public Global(Guid idTenant, Guid idUsuario)
        {
            Id_Tenant_Global = idTenant;
            Id_Usuario = idUsuario;
        }
    }
}
