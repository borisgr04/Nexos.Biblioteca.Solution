using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Infrastructure.Data.Base
{
    public class DbContextBase : DbContext,IDbContext
    {
        public DbContextBase() 
        {
        }
        public DbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}
