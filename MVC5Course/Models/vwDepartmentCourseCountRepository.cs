using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class vwDepartmentCourseCountRepository : EFRepository<vwDepartmentCourseCount>, IvwDepartmentCourseCountRepository
	{

	}

	public  interface IvwDepartmentCourseCountRepository : IRepository<vwDepartmentCourseCount>
	{

	}
}