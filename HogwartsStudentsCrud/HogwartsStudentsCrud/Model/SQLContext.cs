using HogwartsStudentsCrud.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HogwartsStudentsCrud.Model
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
