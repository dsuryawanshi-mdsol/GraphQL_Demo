using GraphQL;
using GraphQL.Data;
using GraphQL.Interfaces;
using GraphQL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Services
{
    /// <summary>
    /// Product Service Class
    /// </summary>
    public class ProductService : IProduct
    {

        private ProductDbContext productDbContext;
        private IHttpContextAccessor accessor;
        private IDocumentExecuter executer;

        public ProductService(ProductDbContext productDbContext,
            IHttpContextAccessor accessor, IDocumentExecuter executer)
        {
            this.productDbContext = productDbContext;
            this.accessor = accessor;
            this.executer = executer;
        }


        /// <inheritdoc cref="IProduct.AddProduct(Product)"/>
        public Product AddProduct(Product product)
        {
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
            return product;
        }

        /// <inheritdoc cref="IProduct.DeleteProduct(int)" />
        public void DeleteProduct(int id)
        {
            Product product = productDbContext.Products.Find(id);
            productDbContext.Products.Remove(product);

            productDbContext.SaveChanges();
        }

        /// <inheritdoc cref="IProduct.DeleteProduct(int)" />
        public List<Product> GetAllProducts()
        {
            return productDbContext.Products.ToList();
        }

        /// <inheritdoc cref="IProduct.GetProductById(int)" />
        public Product GetProductById(int id)
        {
            return productDbContext.Products.Find(id);
        }

        /// <inheritdoc cref="IProduct.UpdateProduct(int, Product)" />
        public Product UpdateProduct(int id, Product newproduct)
        {
             Product product = productDbContext.Products.Find(id);

            product.Name = newproduct.Name;
            product.Price = newproduct.Price;
            productDbContext.SaveChanges();

            return product;
        }
        /// <inheritdoc cref="IProduct.GetProductByOderId(int)" />
        public List<Product> GetProductByOderId(int id)
        {
            return productDbContext.Products.Where(o => o.OrderId ==id).ToList();
        }
    }
}
