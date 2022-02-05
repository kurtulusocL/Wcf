using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.DataAccess;
using Wcf.Entities.Concrete;

namespace Wcf.DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        List<Category> GetAllIncluding();       
    }
}
