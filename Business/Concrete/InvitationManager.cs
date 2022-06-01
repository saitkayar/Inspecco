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
    public class InvitationManager : IInvitationService
    {
        private IInvitationRepository _ınvitationRepository;

        public InvitationManager(IInvitationRepository ınvitationRepository)
        {
            _ınvitationRepository = ınvitationRepository;
        }

        public IResult AddWithCompany(Invitation ınvitation)
        {
            _ınvitationRepository.Add(ınvitation);
            return new SuccessResult();
        }

        public IDataResult<List<Invitation>> GetAll(Expression<Func<Invitation, bool>> filter = null)
        {
          var result=  _ınvitationRepository.GetAll(filter);
            return new SuccessDataResult<List<Invitation>>(result,"geçmiş davetiyeler");
        }
    }
}
