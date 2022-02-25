using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{
        public IQueryable<Course> 查詢一個非常複雜的課程資料()
        {
            return this.All();
        }

        public Course Find(int id)
        {
            return this.All().FirstOrDefault(p => p.CourseID == id);
        }

        //public override IQueryable<Course> All()
        //{
        //    return base.All().Where(p => p.IsEnabled);
        //}

        public IQueryable<Course> All(bool showAll)
        {
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return All();
            }
        }

        public override void Delete(Course entity)
        {
            entity.IsEnabled = false;
        }
    }

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}