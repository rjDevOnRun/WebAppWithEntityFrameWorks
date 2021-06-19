using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    /*
     * - Add EFF Core from Nuget packages
     * - Add ApplicationDbContext Class and inherit from DbContext
     * - Add constructor to base class with this class into options
     * - Add Services for DbContext in services startup class
     * 
     * - Add Microsoft.EntityFramework.Tools Nuget packages
     * - Package Manager commands:
     *  - For creating migrations/updates
     *      "add-migration addPersonTableToDatabase"
     *  - For updating the migrations to database
     *      "update-database"
     */
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions): base(contextOptions)
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}
