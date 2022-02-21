using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{
        public override IQueryable<Course> All()
        {
            return base.All().Where(p => p.IsEnabled);
        }
    }

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}