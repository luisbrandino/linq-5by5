using MongoDB.Bson.Serialization.Attributes;

namespace aula02
{
    public class PenalidadeDocument
    {
        [BsonElement("razaoSocial")]
        public string RazaoSocial { get; set; }

        [BsonElement("cnpj")]
        public string Cnpj { get; set; }

        [BsonElement("nomeMotorista")]
        public string NomeMotorista { get; set; }

        [BsonElement("cpf")]
        public string Cpf { get; set; }

        [BsonElement("vigenciaDoCadastro")]
        public DateTime VigenciaCadastro { get; set; }

        public PenalidadeDocument(PenalidadeAplicada penalidade)
        {
            RazaoSocial = penalidade.RazaoSocial;
            Cnpj = penalidade.Cnpj;
            NomeMotorista = penalidade.NomeMotorista;
            Cpf = penalidade.Cpf;
            VigenciaCadastro = penalidade.VigenciaCadastro;
        }
    }
}
