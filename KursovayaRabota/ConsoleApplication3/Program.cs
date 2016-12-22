using ConsoleApplication3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HyinyaContext huinya = new HyinyaContext())
            {
                huinya.Students.Add(new Student("second"));

                Student st = huinya.Students.First(i => i.StudentId == 1);
                st.StudentName = "Hui";

                huinya.SaveChanges();
                
            }
        }

    }
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public Student(string name)
        {
            this.Courses = new HashSet<Course>();
            this.StudentName = name;
        }

        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<University> Universities { get; set; }
    }

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

    public class University
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
