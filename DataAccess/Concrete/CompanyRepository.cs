using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CompanyRepository : EfBaseRepository<Company, ProductManagementDbContext>, ICompanyRepository
    {
        public List<Company> GetCompanyDetail(Expression<Func<Company, bool>> filter = null)
        {
            using (var context=new ProductManagementDbContext())
            {
                var result = from c in context.Companies
                             join
 m in context.Customers on c.CustomerId equals m.Id
                             select new Company

                             {CompanyName = c.CompanyName,
                             Customer=c.Customer,
                             
                             };
                return result.ToList();
            }
        }
    }
}
