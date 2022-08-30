using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Produto
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);

            // Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cadastro).WithOne(p => p.Pedido);

            // ItemPedido
            modelBuilder.Entity<ItemPedido>()
                .HasKey(ip => ip.Id);
            modelBuilder.Entity<ItemPedido>()
                .HasOne(ip => ip.Pedido);
            modelBuilder.Entity<ItemPedido>()
                .HasOne(ip => ip.Produto);

            // Cadastro
            modelBuilder.Entity<Cadastro>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>()
                .HasOne(c => c.Pedido);
        }
    }
}
