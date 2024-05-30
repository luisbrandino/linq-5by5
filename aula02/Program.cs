using aula02;

PenalidadesFile file = new("C:\\dev\\motoristas-habilitados.json");

List<PenalidadeAplicada>? penalidades = file.Read();

if (penalidades == null)
    Environment.Exit(0);

MongoRepository<PenalidadeDocument> mongoRepository = new("motorista", "penalidade");

PenalidadeRepository repository = new(penalidades);

Menu menu = new(
    "Registros com o número de documento (CPF) iniciando com '237'",
    "Registros com o ano de vigência igual à 2021",
    "Registros que contém 'LTDA' na razão social",
    "Ordenar por razão social",
    "Inserir registros no SQLServer",
    "Gerar arquivos XMLs dos registros",
    "Salvar registros do SQLServer no MongoDB",
    "Sair"
);

int count = repository.Count();

menu.DefinirTitulo($"REGISTROS - Quantidade de linhas: {count}");
menu.LimparAposImpressao(true);

while (true)
{
    switch (menu.Perguntar())
    {
        case 1:
            Console.WriteLine("Registros com o número de documento (CPF) iniciando com '237':");
            repository.Print(repository.FilterByCpfStartingWith("237"));
            break;
        case 2:
            Console.WriteLine("Registros com o ano de vigência igual à 2021:");
            repository.Print(repository.FilterByYearOfValidity("2021"));
            break;
        case 3:
            Console.WriteLine($"Quantidade de empresas que contém 'LTDA' na razão social: {repository.FilterByCompanyNameContaining("LTDA").Count}");
            break;
        case 4:
            Console.WriteLine("Registros ordenados pela razão social");
            repository.Print(repository.SortByCompanyName());
            break;
        case 5:
            PenalidadeAplicada penalidade = new();
            int batchSize = 1000;
            int batches = (int) Math.Floor((double)count / batchSize);

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (int i = 0; i <= batches; i++)
                penalidade.InserirVarios(repository.Penalidades.Skip(i * batchSize).Take(batchSize).ToList());
            watch.Stop();

            Console.WriteLine($"Registros inseridos! Tempo: {watch.ElapsedMilliseconds}");
            break;
        case 6:
            Console.WriteLine(repository.ToXML());
            break;
        case 7:
            List<PenalidadeAplicada> todasPenalidades = new PenalidadeAplicada().BuscarTodos();

            mongoRepository.InsertMany(todasPenalidades.Select(penalidade => new PenalidadeDocument(penalidade)).ToList());

            RegistroInsercao registro = new RegistroInsercao
            {
                Descricao = "Registro penalidade mongodb",
                DataInsercao = DateTime.Now,
                NumeroDeRegistrosInseridos = todasPenalidades.Count
            };

            registro.Inserir();

            Console.WriteLine("Registros inseridos!");
            break;
        case 8:
            Environment.Exit(0);
            break;
    }

    Console.WriteLine("Aperte qualquer tecla para continuar...");
    Console.ReadKey();
}