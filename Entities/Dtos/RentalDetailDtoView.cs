using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RentalDetailDtoView : IDto
    {
        public int RentalId { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }     
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
