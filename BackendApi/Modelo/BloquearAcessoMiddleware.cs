namespace BackendApi.Modelo
{
    public class BloquearAcessoMiddleware
    {
        private readonly RequestDelegate _next;

        public BloquearAcessoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

 

        public async Task InvokeAsync(HttpContext context)
        {

            // Verifique se o cabeçalho "ExemploHeader" está presente na solicitação.
            if (context.Request.Headers.ContainsKey("ExemploHeader"))
            {
                // Recupere o valor do cabeçalho "ExemploHeader" e armazene-o em uma variável.
                string exemploHeaderValue = context.Request.Headers["ExemploHeader"];

                // Coloque o valor no contexto da solicitação para que ele esteja disponível para a aplicação.
                context.Items["ExemploHeaderValue"] = exemploHeaderValue;
            }

            // Verifique se o cabeçalho "ExemploHeader" está presente na solicitação.
            if (!context.Request.Headers.ContainsKey("ExemploHeader"))
            {
                // Se o cabeçalho não estiver presente, retorne um código de status HTTP 403 (Forbidden).
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Acesso proibido. O cabeçalho 'ExemploHeader' é obrigatório.");
                return;
            }

            // Se o cabeçalho estiver presente, continue o pipeline de solicitação.
            await _next(context);
        }
    }
}
