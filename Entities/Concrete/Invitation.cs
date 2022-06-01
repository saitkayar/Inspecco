using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Invitation:IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InviteDate { get; set; } = DateTime.UtcNow;

        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
