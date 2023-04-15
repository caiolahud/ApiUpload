using System.ComponentModel.DataAnnotations;

namespace apiUploadXLS.Models
{
    public class CargoFuncionario
    {
        [Key]
        public string Id_empresa { get; set; }
        public string Codigo_rh { get; set; }
        public string Codigo_esocial { get; set; }
        public string CBO { get; set; }
        public string Cargo { get; set; }
        public string Funcao { get; set; }
        public string Descricao_atividades { get; set; }
        public string Requisitos_da_funcao { get; set; }
        public string Recomendacoes { get; set; }
        public string Procedimentos_acidentes { get; set; }
        public string Resp_empregado { get; set; }
        public string Observacoes { get; set; }
        public string Atividades_peric_insalub_especiais { get; set; }
        public string Id_setor { get; set; }
        public string Setor { get; set; }

    }
}
