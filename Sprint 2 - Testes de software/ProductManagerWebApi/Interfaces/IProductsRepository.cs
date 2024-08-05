using ProductManagerWebApi.Domains;

namespace ProductManagerWebApi.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Busca todos os Produtos do banco
        /// </summary>
        /// <returns>Lista de objetos do tipo Product</returns>
        List<Product> GetAll();

        /// <summary>
        /// Busca um Produto por Id
        /// </summary>
        /// <param name="idProduct">Id do produto</param>
        /// <returns>Objeto do tipo Produto encontrado</returns>
        Product GetProductById(Guid idProduct);

        /// <summary>
        /// Registra um novo Product no banco de dados
        /// </summary>
        /// <param name="newProduct">Objeto do tipo Product</param>
        bool RegisterProduct(Product newProduct);

        /// <summary>
        /// Altera um Product do banco de dados
        /// </summary>
        /// <param name="idProduct">Id do Product a ser alterado</param>
        /// <param name="newProduct">Objeto Product alterado</param>
        /// <returns></returns>
        Product Alterar(Guid idProduct, Product newProduct);

        /// <summary>
        /// Deleta um Product do banco de dados
        /// </summary>
        /// <param name="idProducy">Id do produto a deletark</param>
        bool DeleteById(Guid idProducy);
    }
}
