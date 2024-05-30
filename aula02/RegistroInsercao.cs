namespace aula02
{
    public class RegistroInsercao : Model
    {
        public override string Tabela { get; protected set; } = "tb_registro_insercao";

        public override string[] Colunas { get; protected set; } = new string[]
        {
            "descricao",
            "data_insercao",
            "numero_de_registros_inseridos"
        };

        public string Descricao { get; set; }
        public DateTime DataInsercao { get; set; }
        public int NumeroDeRegistrosInseridos { get; set; }

        public void Inserir()
        {
            Descricao = Descricao.Replace("'", "''");
            CommandNonQuery(Command($"insert into {Tabela} (descricao, data_insercao, numero_de_registros_inseridos) values ('{Descricao}', '{DataInsercao}', '{NumeroDeRegistrosInseridos}')"));
        }

    }
}
