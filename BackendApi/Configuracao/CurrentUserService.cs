using BackendApi.Infra.Modelo;
using System.Security.Claims;

namespace BackendApi.Configuracao
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
            TenantId = GetTenantId(Claims);
            IsGlobalTenant = GetIsGlobalTenant(Claims?.FirstOrDefault(x => x.Key.Equals(ApplicationClaimTypes.Tenant)).Value);
           
        }

        public string UserId { get; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsGlobalTenant { get; set; }
 

        private static bool GetIsGlobalTenant(string value)
        {
            return bool.TryParse(value, out bool isGlobalTenantToken) && isGlobalTenantToken;
        }

        private static Guid? GetTenantId(List<KeyValuePair<string, string>> claims)
        {
            var tenantId = claims?.FirstOrDefault(x => x.Key.Equals(ApplicationClaimTypes.Tenant)).Value;
            if (tenantId != null && Guid.TryParse(tenantId, out Guid tenantIdToken))
            {
                return tenantIdToken;
            }
            return null;
        }

        public static class EnumUtils
        {
            public static T? GetValueFromString<T>(string val) where T : struct, Enum
            {
                Enum.TryParse(typeof(T), val, out var obj);
                if (obj != null && obj is T enumerator)
                {
                    return enumerator;
                }
                return null;
            }
        }

        public static class ApplicationClaimTypes
        {
            public const string Tenant = "Tenant";
            public const string IsGlobalTenant = "IsGlobalTenant";
            public const string Permission = "Permission";
            public const string Login = "Login";
            public const string TipoPerfil = "TipoPerfil";
            public const string PerfilDescricao = "PerfilDescricao";
            public const string PerfilId = "PerfilId";
        }
    }
}