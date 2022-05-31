using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {

        public int Id { get; set; }
   
        public string CustomerName{ get; set; }
       
    }

}
