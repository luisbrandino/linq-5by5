using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace aula02
{
    public class PenalidadesFile
    {
        public string Path { get; private set; }

        public PenalidadesFile(string path) 
        {
            Path = path;
        }

        public List<PenalidadeAplicada>? Read()
        {
            StreamReader reader = new(Path);

            return JsonConvert.DeserializeObject<MotoristaHabilitado>(reader.ReadToEnd(), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" })?.Penalidades;
        }
    }
}
