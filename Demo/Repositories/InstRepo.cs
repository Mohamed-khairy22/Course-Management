using Demo.Models;
using ITI_task1.Models;

namespace Demo.Repositories
{
    //CRUD
    public class InstRepo:IInstRepo
    {
        ITIEntity context;

        public InstRepo(ITIEntity context )
        {
            this.context = context;
        }
        public List<Instructor> GetAll()
        {            
            return context.instructors.ToList();
        }
        public Instructor GetById(int id)
        {
            return context.instructors.FirstOrDefault(i=>i.Id==id);
        }
        public void Insert(Instructor instructor)
        {
            context.instructors.Add(instructor);
            context.SaveChanges();
        }
        public void Update(int id ,Instructor newInst)
        {
            Instructor oldInst= GetById(id);
            oldInst.Name = newInst.Name;
            oldInst.crsId = newInst.crsId;
            oldInst.deptId = newInst.deptId;
            oldInst.Image = newInst.Image;
            oldInst.Salary = newInst.Salary;
            oldInst.Address = newInst.Address;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.instructors.Remove(GetById(id));
        }
    }

}
