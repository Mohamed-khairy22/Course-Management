using ITI_task1.Models;

namespace Demo.Repositories
{
    public interface IDeptRepo
    {
         List<Department1> GetAll();
         Department1 GetById(int id);
    }
}
