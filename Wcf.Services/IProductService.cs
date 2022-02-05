using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Entities.Concrete;

namespace Wcf.Services
{
    [ServiceContract]
    public interface IProductService : IServiceBase<Product>
    {
        List<Category> GetCategoryForProduct();
    }
}
