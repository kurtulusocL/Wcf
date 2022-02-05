using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.DataAccess;
using Wcf.Entities.Concrete;

namespace Wcf.DataAccess.Abstract
{
    public interface IProductDAL:IEntityRepository<Product>
    {
        List<Product> GetAllIncluding();
        List<Category> GetCategoryForProduct();
    }
}
