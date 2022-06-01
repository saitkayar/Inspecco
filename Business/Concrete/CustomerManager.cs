using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IResult Add(Customer customer)
        {

            _customerRepository.Add(customer);
            return new SuccessResult("yeni kişi eklendi");
           
          
        }

        public IResult Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
            return new SuccessResult(" kişi silindi");
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
          
            return new SuccessDataResult<Customer>(_customerRepository.Get(filter), "kişi getirildi");
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {

            return new SuccessDataResult<List<Customer>>(_customerRepository.GetAll(filter), "kişiler getirildi");
        }

        public IResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResult(" kişi güncellendi");
        }
    }
}
