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
    public class CategoryDAL : EntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDAL
    {
        public List<Category> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<Category>().Include("Products").OrderByDescending(i => i.CreatedDate).ToList();
            }
        }
    }
}
