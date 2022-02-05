using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Wcf.Business.Abstract;
using Wcf.Core.DataAccess;
using Wcf.Entities.Concrete;

namespace Wcf.Services
{
    [ServiceContract]
    public interface ICategoryService : IServiceBase<Category>
    {
    }
}