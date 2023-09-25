using System.ComponentModel;

namespace BackendApi.Dominio.Util
{
    public class Enums
    {
    }


    public enum ModoCruds : short
    {
        [Description("Inserir")]
        Inserir = 1,

        [Description("Alterar")]
        Alterar = 2,

        [Description("Excluir")]
        Excluir = 3
    }
}
