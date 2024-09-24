﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models;


namespace RepositoryPatternWithUOW.EF
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base() { }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Author> Authors { get; set; }

		public DbSet<Book> Books { get; set; }
	}
}
