using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate{ get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
    }
}
