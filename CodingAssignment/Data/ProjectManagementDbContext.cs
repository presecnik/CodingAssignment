using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodingAssignment.Models;

namespace CodingAssignment.Data
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext (DbContextOptions<ProjectManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<CodingAssignment.Models.Project> Project { get; set; } = default!;

        public DbSet<CodingAssignment.Models.Task> Task { get; set; }
    }
}
