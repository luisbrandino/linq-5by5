using aulalinq;

PersonRepository repository = PersonRepository.Load();

foreach (Person people in repository.FilterByCharAndLength('a', 3))
    Console.WriteLine(people);