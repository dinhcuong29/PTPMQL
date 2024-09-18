namespace Demomvc.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public string StudentID{get;set;}
        public string Name{get;set;}
    }
}