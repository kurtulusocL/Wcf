using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Business.Abstract;
using Wcf.DataAccess.Abstract;
using Wcf.Entities.Concrete;

namespace Wcf.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public void Create(Product entity)
        {
            _productDAL.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDAL.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAllIncluding();
        }

        public Product GetById(int? id)
        {
            return _productDAL.Get(i => i.Id == id);
        }

        public List<Category> GetCategoryForProduct()
        {
            return _productDAL.GetCategoryForProduct();
        }

        public void Update(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}
