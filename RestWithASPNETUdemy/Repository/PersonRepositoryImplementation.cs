using RestWithASPNETUdemy.Data.Context;
using RestWithASPNETUdemy.Data.Model;
using RestWithASPNETUdemy.Interfaces.Repository;

namespace RestWithASPNETUdemy.Repository;

public class PersonRepositoryImplementation : IPersonRepository
{
    private MySQLContext _context;
    public PersonRepositoryImplementation(MySQLContext context)
        => _context = context;

    public List<Person> FindAll
        => _context.People.ToList();

    public Person FindByID(int id)
        => _context.People.SingleOrDefault(p => p.Id == id);

    public Person Update(Person person)
    {
        var _person = _context.People.SingleOrDefault(p => p.Id == person.Id);
        if (_person is null)
        {
            return Create(person);
        }
        else
        {
            try
            {
                _context.Entry(_person).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return person;
        }
    }
    
    public Person Create(Person person)
    {
        try
        {
            _context.Add(person);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
        return person;
    }

    public void Delete(int id)
    {
        var _person = _context.People.SingleOrDefault(p => p.Id == id);
        if (_person != null)
        {
            try
            {
                _context.People.Remove(_person);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}