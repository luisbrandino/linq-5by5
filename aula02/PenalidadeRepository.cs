using System.Xml.Linq;

namespace aula02
{
    public class PenalidadeRepository
    {
        public List<PenalidadeAplicada> Penalidades { get; private set; }

        public PenalidadeRepository(List<PenalidadeAplicada> penalidades)
        {
            Penalidades = penalidades;
        }

        public List<PenalidadeAplicada> FilterBy(Func<PenalidadeAplicada, bool> filter) => Penalidades.Where(filter).ToList();

        public List<PenalidadeAplicada> FilterByCpfStartingWith(string cpf) => FilterBy(penalidade => penalidade.Cpf.StartsWith(cpf));

        public List<PenalidadeAplicada> FilterByYearOfValidity(string year) => FilterBy(penalidade => penalidade.VigenciaCadastro.Year.ToString() == year);

        public List<PenalidadeAplicada> FilterByCompanyNameContaining(string companyName) => FilterBy(penalidade => penalidade.RazaoSocial.ToLower().Contains(companyName.ToLower()));
    
        public List<PenalidadeAplicada> SortByCompanyName() => Penalidades.OrderBy(penalidade => penalidade.RazaoSocial).ToList();

        public void Print(List<PenalidadeAplicada> penalidades) => penalidades.ForEach(penalidade => Console.WriteLine(penalidade));

        public void Print() => Print(Penalidades);

        public XElement ToXML() => new XElement("Root", from penalidade in Penalidades select
                                                    penalidade.ToXML());

        public int Count() => Penalidades.Count;
    }
}
