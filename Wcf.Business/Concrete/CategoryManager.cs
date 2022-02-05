using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wcf.Business.Abstract;
using Wcf.DataAccess.Abstract;
using Wcf.Entities.Concrete;

namespace Wcf.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Create(Category entity)
        {
            _categoryDAL.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDAL.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryDAL.GetAllIncluding();
        }

        public Category GetById(int? id)
        {
            return _categoryDAL.Get(i => i.Id == id);
        }

        public void Update(Category entity)
        {
            _categoryDAL.Update(entity);
        }
    }
}
