using BackendApi.Dominio.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApi.Dominio.Entidade
{
    public class Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? Id_Tenant { get; set; }
       // public virtual Tenant? TenantAuditoria { get; set; }
        public string NomeTabela { get; set; } = string.Empty;
        public string ModoCrud { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public string HistoricoAntes { get; set; } = string.Empty;
        public string HistoricoDepois { get; set; } = string.Empty;

        public Auditoria DadosDoIncluir(Guid idtenant, Guid? idRegistroAtual, string nomeTabela, string jsonData)
        {
            // string jsonData = JsonData(idtenant, idRegistroAtual, nomeTabela);

            Id_Tenant = idtenant;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Inserir.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = jsonData;
            return this;
        }

        public Auditoria DadosDoAlterar(Guid idtenant, Guid? idRegistroAtual, string nomeTabela, string jsonData)
        {
            //string jsonData = JsonData(idtenant, idRegistroAtual, nomeTabela);

            Id_Tenant = idtenant;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Alterar.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = jsonData;
            return this;
        }

        public Auditoria DadosDoExcluir(Guid idtenant, Guid? idRegistroAtual, string nomeTabela, string jsonData)
        {
            //string jsonData = JsonData(idtenant, idRegistroAtual, nomeTabela);

            Id_Tenant = idtenant;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Excluir.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = jsonData;
            return this;
        }

        //private string JsonData(Guid idtenant, Guid? idRegistroAtual, string nomeTabela)
        //{
        //    Auditoria objeto = new Auditoria();
        //    objeto.Id_Tenant = idtenant;
        //    objeto.NomeTabela = nomeTabela;
        //    objeto.ModoCrud = ModoCruds.Inserir.GetDescricao();
        //    objeto.DataCadastro = DateTime.Now;
        //    objeto.HistoricoAntes = "Não tem";
        //    string jsonData = JsonConvert.SerializeObject(objeto);
        //    return jsonData;
        //}

    }
}
