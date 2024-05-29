namespace aulalinq
{
    class PersonRepository
    {
        public List<Person> People { get; private set; }

        public PersonRepository() { }

        public PersonRepository(List<Person> people)
        {
            People = people;
        }

        public void Print()
        {
            foreach (Person person in People)
                Console.WriteLine(person);
        }

        public List<Person> FilterByAgeLinq(int age) => People.Where(person => person.Age >= age).ToList();

        public List<Person> FilterByAge(int age) => People.FindAll(person => person.Age >= age);

        public List<Person> FilterByName(string name) => FilterBy(person => person.Name.StartsWith(name));

        public List<Person> FilterByRicardo() => FilterByName("Ricardo");

        public List<Person> SortByName() => People.OrderBy(person => person.Name).ToList();

        public List<Person> SortByNameDesc() => People.OrderByDescending(person => person.Name).ToList();

        public List<Person> FilterByCharAndLength(char character, int length) => FilterBy(person => person.Name.ToLower().Contains(character) && person.Name.Length > length);

        public List<Person> FilterBy(Func<Person, bool> filter) => People.Where(filter).ToList();

        public List<Person> GetAdults() => FilterByAge(18);

        public static PersonRepository Load()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { Id = 1, Name = "Ricardo Ramos", Age = 98, Telephone = "11990001111" });
            people.Add(new Person() { Id = 2, Name = "Ricardo Remos", Age = 78, Telephone = "11990001112" });
            people.Add(new Person() { Id = 3, Name = "Ricardo Rumos", Age = 92, Telephone = "11990001113" });
            people.Add(new Person() { Id = 4, Name = "Ricardo Ranhos", Age = 95, Telephone = "11990001114" });
            people.Add(new Person() { Id = 5, Name = "Ricardo Romos", Age = 93, Telephone = "11990001115" });
            people.Add(new Person() { Id = 6, Name = "Ricardo Vomos", Age = 88, Telephone = "11990001116" });
            people.Add(new Person() { Id = 7, Name = "Ricardo Vamos", Age = 91, Telephone = "11990001117" });
            people.Add(new Person() { Id = 8, Name = "Maria Ricardo", Age = 55, Telephone = "11990001119" });
            people.Add(new Person() { Id = 9, Name = "Big Richard Ricardo", Age = 55, Telephone = "11990001119" });
            people.Add(new Person() { Id = 10, Name = "Ricordo Remos", Age = 55, Telephone = "11990001119" });
            people.Add(new Person() { Id = 11, Name = "bdef", Age = 55, Telephone = "11990001119" });

            return new(people);
        }
    }
}
