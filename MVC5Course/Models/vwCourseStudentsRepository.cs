using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class vwCourseStudentsRepository : EFRepository<vwCourseStudents>, IvwCourseStudentsRepository
	{

	}

	public  interface IvwCourseStudentsRepository : IRepository<vwCourseStudents>
	{

	}
}