namespace BackendApi.Infra.Modelo
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }

        Guid? TenantId { get; set; }

        bool IsGlobalTenant { get; set; }
 
    }
}
