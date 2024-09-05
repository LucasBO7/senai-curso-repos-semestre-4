using Moq;
using ProductManagerWebApi.Domains;
using ProductManagerWebApi.Interfaces;

namespace ProductManagerUnitTests
{
    public class UnitTest1
    {
        //Teste da funcionalidade de listar todos os produtos
        [Fact]
        public void GetTest()
        {
            //Arrage

            //Lista de produtos
            List<Product> listaDeProdutos = new List<Product>()
            {
                new Product(){ Name = "Luminária R2D2", Price = 159 },
                new Product(){ Name = "Monitor 75hz Full HD AOC", Price = 899 }
            };

            //Cria um objeto de simulação do tipo ProductRepository 
            var mockRepository = new Mock<IProductsRepository>();

            //Act

            //Configura o método "Get" do controller para que quando for acionado retorne a lista "mockada"
            mockRepository.Setup(x => x.GetAll()).Returns(listaDeProdutos);

            List<Product> listaBuscada = mockRepository.Object.GetAll();

            //Assert
            Assert.Equal(2, listaBuscada.Count);
        }

        [Theory]
        [InlineData("f105e1f7-315e-46c4-9c4a-327d63318b4e")]
        public void GetById(Guid idProduto)
        {
            List<Product> listaDeProdutos = new List<Product>()
            {
                new Product(){IdProduct = Guid.Parse("f105e1f7-315e-46c4-9c4a-327d63318b4e"), Name = "Carro ferrari Hotweels",
                    Price = 58}
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetProductById(idProduto)).Returns(listaDeProdutos.FirstOrDefault(p => p.IdProduct == idProduto)!);

            Product produtoBuscado = mockRepository.Object.GetProductById(idProduto);

            Assert.NotNull(produtoBuscado);
        }

        [Fact]
        public void PostTest()
        {
            //Cria o objeto
            Product novoProduto = new Product() { Name = "GGB Plast Jogo Muliformas de Encaixe 36 Peças Colorido", Price = 23 };

            //Cria a lista
            List<Product> listaDeProdutos = new List<Product>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.RegisterProduct(novoProduto)).Callback<Product>(x => listaDeProdutos.Add(novoProduto));

            //Act
            mockRepository.Object.RegisterProduct(novoProduto);

            //Assert
            Assert.Contains(novoProduto, listaDeProdutos);
        }

        [Theory]
        [InlineData("55551e2c-6a67-4b31-a93e-512a24a68cf2")]
        public void DeleteTest(Guid idProduto)
        {
            List<Product> listaDeProdutos = new List<Product>()
            {
                new Product() {IdProduct = Guid.Parse("55551e2c-6a67-4b31-a93e-512a24a68cf2"), Name = "Headfone HP Mono", Price = 50}
            };

            Product produto = listaDeProdutos.FirstOrDefault(p => p.IdProduct == idProduto)!;

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.DeleteById(idProduto)).Callback(() => listaDeProdutos.Remove(produto));

            mockRepository.Object.DeleteById(idProduto);

            Assert.Empty(listaDeProdutos);
        }

        [Theory]
        [InlineData("ad149434-5425-4ae0-aee0-f7c332268ee8")]
        public void PutTest(Guid idProduto)
        {
            List<Product> listaDeProdutos = new List<Product>()
            {
                new Product() {IdProduct = Guid.Parse("ad149434-5425-4ae0-aee0-f7c332268ee8"), Name = "Caixa de som soundbar Redragon", Price = 130}
            };

            Product produtoAtualizado = new Product()
            {
                Name = "Computador HP",
                Price = 23
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Alterar(idProduto, produtoAtualizado)).Callback(() =>
            {
                Product produtoBuscado = listaDeProdutos.FirstOrDefault(p => p.IdProduct == idProduto)!;
                produtoBuscado.Name = produtoAtualizado.Name;
                produtoBuscado.Price = produtoAtualizado.Price;
            });

            mockRepository.Object.Alterar(idProduto, produtoAtualizado);

            Product produto = listaDeProdutos.FirstOrDefault(p => p.IdProduct == idProduto)!;

            Assert.Equal("Computador HP", produto.Name);
            Assert.Equal(23, produto.Price);
        }

    }
}