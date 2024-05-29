using Newtonsoft.Json;

namespace aula02
{
    public class MotoristaHabilitado
    {
        [JsonProperty("penalidades_aplicadas")]
        public List<PenalidadeAplicada> Penalidades { get; set; }

    }
}
