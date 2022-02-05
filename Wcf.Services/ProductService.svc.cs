using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Wcf.DataAccess.Concrete.EntityFramework;
using Wcf.Entities.Concrete;

namespace Wcf.Services
{
    public class ProductService : IProductService
    {
        ProductDAL productDAL = new ProductDAL();
        CategoryDAL categoryDAL = new CategoryDAL();

        public void Add(Product entity)
        {
            productDAL.Add(entity);
        }

        public void Delete(Product entity)
        {
            productDAL.Delete(entity);
        }

        public Product Get(int? id)
        {
            return productDAL.Get(i => i.Id == id);
        }

        public List<Product> GetAll()
        {
            return productDAL.GetAllIncluding().Select(i => new Product
            {
                Name = i.Name,
                Price = i.Price,
                Quantity = i.Quantity,
                Id = i.Id,
                CategoryId = i.CategoryId
            }).ToList();
        }

        public List<Category> GetCategoryForProduct()
        {
            return categoryDAL.GetAllIncluding().Select(i => new Category
            {
                Name = i.Name,
                CreatedDate = i.CreatedDate,
                Id = i.Id
            }).ToList();
        }

        public void Update(Product entity)
        {
            productDAL.Update(entity);
        }
    }
}
