using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VasconezMiguel_Prueba.Models;

    public class VasconezMiguelContext : DbContext
    {
        public VasconezMiguelContext (DbContextOptions<VasconezMiguelContext> options)
            : base(options)
        {
        }

        public DbSet<VasconezMiguel_Prueba.Models.MVasconez> MVasconez { get; set; } = default!;

public DbSet<VasconezMiguel_Prueba.Models.Celular> Celular { get; set; } = default!;
    }
