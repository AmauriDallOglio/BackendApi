namespace BackendApi.Dominio.Modelo
{
    public interface IResultado
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
    }

    public interface IResultado<out T> : IResultado
    {
        T Data { get; }
    }
}