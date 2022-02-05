using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.DataAccess.EntityFramework;
using Wcf.DataAccess.Abstract;
using Wcf.DataAccess.Concrete.EntityFramework.Context;
using Wcf.Entities.Concrete;

namespace Wcf.DataAccess.Concrete.EntityFramework
{
    public class ProductDAL : EntityRepositoryBase<Product, ApplicationDbContext>, IProductDAL
    {
        public List<Product> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Product>().Include("Category").Where(i => i.Quantity > 0).OrderByDescending(i => i.Quantity).ToList();
            }
        }
        public List<Category> GetCategoryForProduct()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Category>().Include("Products").OrderBy(i => i.Products.Count()).ToList();
            }
        }
    }
}
