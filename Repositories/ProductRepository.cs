using E_Commerce.Contexts;
using E_Commerce.Entities;
using E_Commerce.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        
        public List<Category> GetCategories(int id)
        {
            using var context = new E_CommerceContext();
            return context.Products.Join(context.productCategories, product => product.Id, productcategory
                => productcategory.ProductID, (p, pc) => new
                {
                    product = p,
                    productcategory = pc
                }).Join(context.Categories, x => x.productcategory.CategoryID,
                c => c.Id, (pc, c) => new { product = pc.product, category = c, productcategory = pc.productcategory }).Where
                (x => x.product.Id == id).Select(x => new Category { Name = x.category.Name, Id = x.category.Id, }).ToList();


        }

    }
}
