using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace apiUploadXLS.Models
{
    public class CargoFuncionario
    {
        [JsonProperty("id_empresa")]
        public string IdEmpresa { get; set; }

        [JsonProperty("codigo_rh")]
        public string CodigoRH { get; set; }

        [JsonProperty("codigo_esocial")]
        public int CodigoEsocial { get; set; }

        [JsonProperty("CBO")]
        public string CBO { get; set; }

        [JsonProperty("cargo")]
        public string Cargo { get; set; }

        [JsonProperty("funcao")]
        public string Funcao { get; set; }

        [JsonProperty("descricao_atividades")]
        public string DescricaoAtividades { get; set; }

        [JsonProperty("requisitos_da_funcao")]
        public string RequisitosdaFuncao { get; set; }

        [JsonProperty("recomendacoes")]
        public string Recomendacoes { get; set; }

        [JsonProperty("procedimentos_acidentes")]
        public string ProcedimentosAcidentes { get; set; }

        [JsonProperty("resp_empregado")]
        public string RespEmpregado { get; set; }

        [JsonProperty("observacoes")]
        public string Observacoes { get; set; }

        [JsonProperty("atividades_peric_insalub_especiais")]
        public string AtividadesPericInsalubEspeciais { get; set; }

        [JsonProperty("id_setor")]
        public string IdSetor { get; set; }

        [JsonProperty("setor")]
        public string Setor { get; set; }

    }
}
