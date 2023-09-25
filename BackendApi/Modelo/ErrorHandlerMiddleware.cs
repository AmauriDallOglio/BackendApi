using System.Net;
using System.Text.Json;

namespace BackendApi.Modelo
{
    // middleware personalizado para tratamento de erros.
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        { //que contém informações sobre a solicitação HTTP atual.
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                ////permite que você configure a resposta que será enviada de volta ao cliente.
                var response = context.Response;
                //Define o tipo de conteúdo da resposta como JSON para indicar que a resposta será no formato JSON.
                response.ContentType = "application/json";
                var responseModel = await Result<string>.FailAsync(error.Message);
                //A mensagem de erro é extraída da exceção error e é usada como parte do modelo de resposta.
                switch (error)
                {
                    case ApiException e:
                        // a resposta terá um código de status 400 (BadRequest).
                        responseModel = await Result<string>.FailAsync("erro do 400");
                        responseModel.Data = ((int)HttpStatusCode.InternalServerError).ToString();
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException e:
                        // a resposta terá um código de status 404 (NotFound).
                        responseModel = await Result<string>.FailAsync("erro do 404");
                        responseModel.Data = ((int)HttpStatusCode.InternalServerError).ToString();
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // a resposta terá um código de status 500 (InternalServerError), indicando um erro interno não tratado.
                        responseModel = await Result<string>.FailAsync("erro do 500");
                        responseModel.Data = ((int)HttpStatusCode.InternalServerError).ToString();
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      //  response.HttpContext.Response .Content.ReadAsStringAsync().Result;
                        break;
                }
                //é serializado em formato JSON usando JsonSerializer. Isso transforma o objeto em uma representação JSON que pode ser incluída na resposta.
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
