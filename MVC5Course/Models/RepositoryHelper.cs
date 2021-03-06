namespace MVC5Course.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static CourseRepository GetCourseRepository()
		{
			var repository = new CourseRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CourseRepository GetCourseRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CourseRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static DepartmentRepository GetDepartmentRepository()
		{
			var repository = new DepartmentRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static DepartmentRepository GetDepartmentRepository(IUnitOfWork unitOfWork)
		{
			var repository = new DepartmentRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static EnrollmentRepository GetEnrollmentRepository()
		{
			var repository = new EnrollmentRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static EnrollmentRepository GetEnrollmentRepository(IUnitOfWork unitOfWork)
		{
			var repository = new EnrollmentRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static OfficeAssignmentRepository GetOfficeAssignmentRepository()
		{
			var repository = new OfficeAssignmentRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static OfficeAssignmentRepository GetOfficeAssignmentRepository(IUnitOfWork unitOfWork)
		{
			var repository = new OfficeAssignmentRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static PersonRepository GetPersonRepository()
		{
			var repository = new PersonRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static PersonRepository GetPersonRepository(IUnitOfWork unitOfWork)
		{
			var repository = new PersonRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static vwCourseStudentCountRepository GetvwCourseStudentCountRepository()
		{
			var repository = new vwCourseStudentCountRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static vwCourseStudentCountRepository GetvwCourseStudentCountRepository(IUnitOfWork unitOfWork)
		{
			var repository = new vwCourseStudentCountRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static vwCourseStudentsRepository GetvwCourseStudentsRepository()
		{
			var repository = new vwCourseStudentsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static vwCourseStudentsRepository GetvwCourseStudentsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new vwCourseStudentsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static vwDepartmentCourseCountRepository GetvwDepartmentCourseCountRepository()
		{
			var repository = new vwDepartmentCourseCountRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static vwDepartmentCourseCountRepository GetvwDepartmentCourseCountRepository(IUnitOfWork unitOfWork)
		{
			var repository = new vwDepartmentCourseCountRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}