using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Models
{
    public class RegiterSubject
    {
        public int Id { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Subject Subject { get; set; }
        public int SubjectId { get;set;}

        public RegiterSubject()
        {
        }

        public RegiterSubject(int id, Student student, int studentId, Subject subject, int subjectId)
        {
            Id = id;
            Student = student;
            StudentId = studentId;
            Subject = subject;
            SubjectId = subjectId;
        }
    }
}
