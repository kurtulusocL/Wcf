using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.DataAccess;
using Wcf.Entities.Concrete;

namespace Wcf.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Category> GetCategoryForProduct();
    }
}
