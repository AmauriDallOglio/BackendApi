using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Primitives;

namespace BackendApi.Modelo
{
    public class CustomHeaderApiVersionReader : IApiVersionReader
    {
        private readonly string headerName;

        public CustomHeaderApiVersionReader(string headerName)
        {
            this.headerName = headerName;
        }

        public void AddParameters(IApiVersionParameterDescriptionContext context)
        {
 
            context.AddParameter("version", ApiVersionParameterLocation.Query) ;
        }

        public bool Read(HttpRequest request, out string value)
        {
            if (request.Headers.TryGetValue(headerName, out StringValues headerValues))
            {
                value = headerValues.ToString();
                return true;
            }

            value = null;
            return false;
        }

        public string? Read(HttpRequest request)
        {
            // Verifica se o cabeçalho "ExemploHeader" está presente na solicitação.
            if (request.Headers.TryGetValue("ExemploHeader", out var headerValue))
            {
                // Recupera o valor do cabeçalho "ExemploHeader".
                return headerValue.ToString();
            }

            // Caso o cabeçalho não esteja presente ou tenha um valor nulo, retorne nulo.
            return null;
        }
    }
}
