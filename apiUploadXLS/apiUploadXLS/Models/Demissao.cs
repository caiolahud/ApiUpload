using Newtonsoft.Json;

namespace apiUploadXLS.Models
{
    public class Demissao
    {
        [JsonProperty("id_empresa")]
        public string IdEmpresa { get; set; }
        
        [JsonProperty("id_funcionario")]
        public string IdFuncionario { get; set; }
        
        [JsonProperty("data_demissao")]
        public string DataDemissao { get; set; }
        
        [JsonProperty("motivo")]
        public int Motivo { get; set; }
    }
}
