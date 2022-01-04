using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Interfaces.Repository;

public interface IPersonRepository : IBaseRepository<Person>
{
    Person Disable(int id);
    IEnumerable<Person> findByName(string firstName, string lastName);
}