using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InvitationRepository : EfBaseRepository<Invitation, InspeccoDbContext>, IInvitationRepository
    {
        public void AddWithCompany(Invitation entity)
        {
            using (var context = new InspeccoDbContext())
            {
                var result = from ı in context.Invitations
                             join
c in context.Companies on ı.CompanyId equals c.Id
                             join m in context.Customers on ı.CustomerId equals m.Id
                             select new Invitation
                             {
                                 Id = ı.Id,
                                 CompanyId = c.Id,
                                 CustomerId = m.Id,
                             };

                context.Add(result);
                context.SaveChanges();

            }
        }
    }
}
