using Demo.Models;
using ITI_task1.Models;

namespace Demo.Repositories
{
    public class CrsRepo : ICrsRepo
    {
        ITIEntity context;

        public CrsRepo(ITIEntity context)
        {
            this.context = context;
        }

        public List<Course> GetAll()
        {
            return context.courses.ToList();
        }
        public Course GetById(int id)
        {
            return context.courses.FirstOrDefault(i => i.Id == id);
        }
        public void Insert(Course course)
        {
            context.courses.Add(course);
            context.SaveChanges();
        }
        public void Update(int id, Course newCrs)
        {
            Course oldInst = GetById(id);
            oldInst.Name = newCrs.Name;
            oldInst.deptId = newCrs.deptId;
            oldInst.Degree = newCrs.Degree;
            oldInst.minDegree = newCrs.minDegree;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.courses.Remove(GetById(id));
        }
        public List<Course> crsPerDept(int deptId)
        {
            return context.courses.Where(i => i.deptId == deptId).ToList();
        }
    }
}
