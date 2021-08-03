//Christopher Sanderson
//CMS-Window-Systems-Christopher-Sanderson
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using CMS_Window_Systems_Christopher_Sanderson.Models;

namespace CMS_Window_Systems_Christopher_Sanderson.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        //Creating Database Sets to allow the user to be able to 
        public DbSet<Heading> Heading { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<QRTable> QRTable { get; set; }
    }
}
