using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventario.Test
{
    public class ControleInventarioTest
    {
        public void AdicionarProdutoAoInventario()
        {
            Inventario inventario = new Inventario();
            Produto novoProduto = new("Banana", 5);

            inventario.AdicionarProduto(novoProduto);

            Assert.Contains(novoProduto, inventario.Produtos);
        }
    }
}
