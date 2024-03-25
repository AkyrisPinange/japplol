﻿using Microsoft.EntityFrameworkCore;

namespace JAppInfos.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
           
        }
    }
  
}