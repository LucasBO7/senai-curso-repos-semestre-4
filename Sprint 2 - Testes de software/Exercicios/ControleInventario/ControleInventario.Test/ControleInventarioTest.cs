namespace ControleInventario.Test
{
    public class ControleInventarioTest
    {
        [Theory]
        [InlineData("Banana", 3)]
        [InlineData("Manga", 2)]
        [InlineData("Laranja", 1)]
        [InlineData("Melão", 1)]
        [InlineData("Feijão", 2)]
        [InlineData("Macarrão", 4)]
        public static void AdicionarProdutoAoInventario(string nomeProduto, int qntProduto)
        {
            Inventario inventario = new();
            Produto novoProduto = new(nomeProduto, qntProduto);

            inventario.AdicionarProduto(novoProduto);

            Assert.Contains(novoProduto, inventario.Produtos);
        }

        [Fact]
        public static void ObterQuantidadeDoProdutoPorNome()
        {
            Inventario inventario = new()
            {
                Produtos = [
                    new Produto("Banana", 6),
                    new Produto("Manga", 12),
                    new Produto("Laranja", 8),
                    new Produto("Melão", 3)
                ]
            };
            string nomeProdutoABuscar = "Banana";

            int? qntdRetornada = inventario.BuscarQuantidadePorNome(nomeProdutoABuscar);

            Assert.NotNull(qntdRetornada);
        }

    }
}
