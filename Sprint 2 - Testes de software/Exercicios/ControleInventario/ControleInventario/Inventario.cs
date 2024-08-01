using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventario
{
    public class Inventario
    {
        public List<Produto> Produtos { get; set; } = [];

        public void AdicionarProduto(Produto novoProduto)
        {
            //Produto produtoBuscado = Produtos.FirstOrDefault(novoProduto);
            //produtoBuscado.Quantidade++;
            if (Produtos.Contains(novoProduto))
                Produtos.FirstOrDefault(novoProduto).Quantidade++;
            else
                Produtos.Add(novoProduto);
        }

        public int? BuscarQuantidadePorNome(string nomeProduto)
        {
            if (Produtos == null)
                return null;

            Produto produtoBuscadoPorNome = Produtos.FirstOrDefault(p => string.Equals(p.Nome, nomeProduto, StringComparison.InvariantCultureIgnoreCase))!;
            return produtoBuscadoPorNome.Quantidade;
        }
    }
}