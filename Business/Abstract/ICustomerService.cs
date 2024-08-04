using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(int customerId);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);


    }
}
