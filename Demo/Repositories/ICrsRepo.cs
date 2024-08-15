using ITI_task1.Models;

namespace Demo.Repositories
{
    public interface ICrsRepo
    {
         List<Course> GetAll();
         Course GetById(int id);
         void Insert(Course course);
         void Update(int id, Course newCrs);
         void Delete(int id);
         List<Course> crsPerDept(int deptId);
    }
}
