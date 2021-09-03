using Microsoft.EntityFrameworkCore;
using PracticalChallenge.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Data.Contexto
{
    public class PracticalChallengeContexto : DbContext
    {
        public PracticalChallengeContexto(DbContextOptions options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
