using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Wcf.DataAccess.Concrete.EntityFramework;
using Wcf.Entities.Concrete;

namespace Wcf.Services
{
    public class CategoryService : ICategoryService
    {
        CategoryDAL category = new CategoryDAL();

        public void Add(Category entity)
        {
            category.Add(entity);
        }

        public void Delete(Category entity)
        {
            category.Delete(entity);
        }

        public Category Get(int? id)
        {
            return category.Get(i => i.Id == id);
        }

        public List<Category> GetAll()
        {
            return category.GetAllIncluding().Select(i => new Category
            {
                Name = i.Name,
                CreatedDate = i.CreatedDate,
                //Products = i.Products.Count(),
                Id = i.Id
            }).ToList();
        }

        public void Update(Category entity)
        {
            category.Update(entity);
        }
    }
}
