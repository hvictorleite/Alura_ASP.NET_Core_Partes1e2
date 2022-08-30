using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaBD()
        {
            contexto.Database.Migrate();
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            produtoRepository.SaveProdutos(livros);
        }
    }
}
