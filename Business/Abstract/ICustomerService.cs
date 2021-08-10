using Core.Result;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        
        IDataResult <Customer> GetId(int Id);
        IDataResult <Customer> GetUserId(int userID);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetName(string name);



    }
}
