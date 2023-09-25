namespace BackendApi.Dominio.Modelo
{
    public class Resultado<T>
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = "Operação concluída com sucesso";
        public ICollection<T> Modelos { get; set; }

        public Resultado()
        {
            Modelos = new HashSet<T>();
        }

    }
}