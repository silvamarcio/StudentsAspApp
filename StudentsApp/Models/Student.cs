using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public Student()
        {
        }

        public Student(int id, int registration, string name)
        {
            Id = id;
            Registration = registration;
            Name = name;
        }

        public void addSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public void removeSubject(Subject subject)
        {
            Subjects.Remove(subject);
        }
    }
}
