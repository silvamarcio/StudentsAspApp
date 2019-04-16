using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

        public Teacher()
        {
        }

        public Teacher(int id, string name, Subject subject, int subjectId)
        {
            Id = id;
            Name = name;
            Subject = subject;
            SubjectId = subjectId;
        }
    }
}
