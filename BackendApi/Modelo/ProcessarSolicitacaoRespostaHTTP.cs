using System.Net;
using System.Text.Json;

namespace BackendApi.Modelo
{
    public class ProcessarSolicitacaoRespostaHTTP
    {
        private readonly RequestDelegate _next;

        public ProcessarSolicitacaoRespostaHTTP(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        { //que contém informações sobre a solicitação HTTP atual.
            try
            {
                bool isPathContainingV1 = context.Request.Path.Value.Contains("/v1/", StringComparison.OrdinalIgnoreCase);
                if (!isPathContainingV1)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    var errorDetails = new
                    {
                        StatusCode = StatusCodes.Status403Forbidden,
                        Message = "Acesso proibido",
                        AdditionalInfo = "Você não possui permissão para acessar este recurso."
                    };
                    context.Response.Clear();
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";
                    var errorDetailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(errorDetails);
                    await context.Response.WriteAsync(errorDetailsJson);

                    return;
                }

                await _next(context);
            }
            catch (Exception error)
            {
                ////permite que você configure a resposta que será enviada de volta ao cliente.
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = await Result<string>.FailAsync(error.Message);
                switch (error)
                {
                    case ApiException e:
                        responseModel = await Result<string>.FailAsync("Erro 400 / " + error.Message + " / " + responseModel);
                        responseModel.Data = ((int)StatusCodes.Status400BadRequest).ToString();
                        response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        break;

                    case KeyNotFoundException e:
                        responseModel = await Result<string>.FailAsync("Erro 404 / " + error.Message + " / " + responseModel);
                        responseModel.Data = ((int)StatusCodes.Status404NotFound).ToString();
                        response.StatusCode = (int)StatusCodes.Status404NotFound;
                        break;

                    default:
                        responseModel = await Result<string>.FailAsync("Erro 500 / " + error.Message + " / " + responseModel);
                        responseModel.Data = ((int)StatusCodes.Status500InternalServerError).ToString();
                        response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
