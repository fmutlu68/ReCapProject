using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public List<string> ImageList { get; set; }
        public bool IsRentedNow { get; set; }
    }
}
