using Newtonsoft.Json;
using System.Xml.Linq;

namespace aula02
{
    public class PenalidadeAplicada : Model
    {
        public override string Tabela { get; protected set; } = "tb_penalidade";
        public override string[] Colunas { get; protected set; } = new string[]
        {
            "cnpj",
            "cpf",
            "razao_social",
            "nome_motorista",
            "data_vigencia"
        };

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
        
        [JsonProperty("nome_motorista")]
        public string NomeMotorista { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigenciaCadastro { get; set; }


        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "cnpj", Cnpj },
                { "cpf", Cpf },
                { "razao_social", RazaoSocial.Replace("'", "''") },
                { "nome_motorista", NomeMotorista.Replace("'", "''") },
                { "data_vigencia", VigenciaCadastro.ToString("MM/dd/yyyy") },
            };
        }

        public void InserirVarios(List<PenalidadeAplicada> penalidades)
        {
            List<Dictionary<string, object>> penalidadesToDictionary = new();

            penalidades.ForEach(penalidade => penalidadesToDictionary.Add(penalidade.ToDictionary()));

            InserirVarios(penalidadesToDictionary);
        }

        public XElement ToXML() => new XElement("Penalidade",
            new XElement("RazaoSocial", RazaoSocial),
            new XElement("CNPJ", Cnpj),
            new XElement("NomeMotorista", NomeMotorista),
            new XElement("CPF", Cpf),
            new XElement("DataVigencia", VigenciaCadastro));

        public override string ToString()
        {
            return $"Razão social: {RazaoSocial} CNPJ: {Cnpj} Nome do motorista: {NomeMotorista} CPF: {Cpf} Vigência do cadastro: {VigenciaCadastro.ToString("dd/MM/yyyy")}";
        }
    }
}
