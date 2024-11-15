using Bogus; // Thêm thư viện Bogus để dùng Faker
using Demomvc.Data;
using Demomvc.Models.Entities;
namespace Demomvc.Models.Process
{
    public class StudentSeeder
    {
        private readonly ApplicationDbContext _context;

        public StudentSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedStudents(int n)
        {
            var students = GenerateStudents(n); // Đổi tên phương thức
            _context.Student.AddRange(students); // Đảm bảo _context.Student tồn tại và là DbSet<Student>
            _context.SaveChanges();
        }

        private List<Student> GenerateStudents(int n)
        {
            var faker = new Faker<Student>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.DateofBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(e => e.Position, f => f.Name.JobTitle())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.HireDate, f => f.Date.Past(10));

            return faker.Generate(n);
        }
    }
}
