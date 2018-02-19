using Domain.Infrastructure;
using System.Collections.Generic;

namespace Data.Repo
{
    public interface ICustomerDataRepo<T> where T: class
    {
        IEnumerable<T> GetAll();
        Option<T> GetById(int id);

        //Should be UOW!!
        Result Save(T customerobject);
    }
}
