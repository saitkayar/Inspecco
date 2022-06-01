using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        public IDataResult<List<Company>> GetAll(Expression<Func<Company, bool>> filter = null);
        public IDataResult<List<CompanyDto>> GetByDetail(Expression<Func<CompanyDto, bool>> filter = null);
        public IDataResult<Company> Get(Expression<Func<Company, bool>> filter);
        public IResult Add(Company company);
        public IResult Update(Company company);
        public IResult Delete(Company company);
    }
}
