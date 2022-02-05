using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Wcf.Core.DataAccess;
using Wcf.Entities.Concrete;

namespace Wcf.Services
{
    [ServiceContract]
    public interface IServiceBase<T>
    {
        [OperationContract]
        List<T> GetAll();

        [OperationContract]
        T Get(int? id);

        [OperationContract]
        void Add(T entity);

        [OperationContract]
        void Update(T entity);

        [OperationContract]
        void Delete(T entity);
    }
}