using ProductManagerWebApi.Domains;
using ProductManagerWebApi.Infra;
using ProductManagerWebApi.Interfaces;

namespace ProductManagerWebApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly Context _context = new();

        public List<Product> GetAll()
        {
            List<Product> products = [.. _context.Products];

            if (products.Count == 0)
                return null!;

            return products;
        }

        public Product GetProductById(Guid idProduct)
        {
            Product searchedProduct = _context.Products.FirstOrDefault(product => product.IdProduct == idProduct)!;

            if (searchedProduct == null)
                return null!;

            return searchedProduct;
        }

        public bool RegisterProduct(Product newProduct)
        {
            Product searchedProduct = _context.Products
                .AsEnumerable()
                .FirstOrDefault(p => p.Name!.Equals(newProduct.Name, StringComparison.CurrentCultureIgnoreCase), null)!;

            if (searchedProduct != null)
                return false;

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return true;

        }


        public Product Alterar(Guid idProduct, Product newProduct)
        {
            Product searchedProduct = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct)!;

            if (searchedProduct == null)
                return null!;

            if (newProduct.Name != null)
                searchedProduct.Name = newProduct.Name;
            if (newProduct.Price != 0)
                searchedProduct.Price = newProduct.Price;

            _context.SaveChanges();
            return searchedProduct;
        }

        public bool DeleteById(Guid idProduct)
        {
            Product searchedProduct = _context.Products.FirstOrDefault(p => p.IdProduct == idProduct)!;

            if (searchedProduct == null) return false;

            _context.Products.Remove(searchedProduct);
            _context.SaveChanges();
            return true;
        }
    }
}
