using Demo.Models;
using ITI_task1.Models;

namespace Demo.Repositories
{
    public class DeptRepo : IDeptRepo
    {
        ITIEntity context ;

        public DeptRepo(ITIEntity context)
        {
            this.context = context;
        }

        public List<Department1> GetAll()
        {
            return context.department1s.ToList(); 
        }
        public Department1 GetById(int id)
        {
            return context.department1s.FirstOrDefault(d => d.Id == id);
        }
    }
}
