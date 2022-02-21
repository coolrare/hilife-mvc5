using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class vwCourseStudentCountRepository : EFRepository<vwCourseStudentCount>, IvwCourseStudentCountRepository
	{

	}

	public  interface IvwCourseStudentCountRepository : IRepository<vwCourseStudentCount>
	{

	}
}