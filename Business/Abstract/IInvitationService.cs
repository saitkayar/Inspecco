using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IInvitationService
    {
        public IDataResult<List<Invitation>> GetAll(Expression<Func<Invitation, bool>> filter = null);
   
        public IResult AddWithCompany(Invitation ınvitation);
      
    }
}
