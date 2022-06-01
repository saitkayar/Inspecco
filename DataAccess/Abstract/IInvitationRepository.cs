using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        public void AddWithCompany(Invitation entity);
       
            
    }
   
}
