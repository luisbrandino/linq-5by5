namespace aulalinq
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"Id: {Id}, Nome: {Name}, Telefone: {Telephone}, Idade: {Age}";

    }
}
