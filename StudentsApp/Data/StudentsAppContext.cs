using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Models;

namespace StudentsApp.Models
{
    public class StudentsAppContext : DbContext
    {
        public StudentsAppContext (DbContextOptions<StudentsAppContext> options)
            : base(options)
        {
        }

        public DbSet<StudentsApp.Models.Subject> Subject { get; set; }

        public DbSet<StudentsApp.Models.Teacher> Teacher { get; set; }

        public DbSet<StudentsApp.Models.Student> Student { get; set; }

        public DbSet<StudentsApp.Models.RegiterSubject> RegiterSubject { get; set; }
    }
}
