using ITI_task1.Models;

namespace Demo.Repositories
{
    public interface IInstRepo
    {
         List<Instructor> GetAll();
         Instructor GetById(int id);
         void Insert(Instructor instructor);
         void Update(int id, Instructor newInst);
         void Delete(int id);
    }
}
