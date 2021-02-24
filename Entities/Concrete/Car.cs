using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }

        public int BrandId { get; set; } // Marka

        public int ColorId { get; set; } // Renk

        public string ModelYear { get; set; } // Arabanın Modeli

        public double DailyPrice { get; set; } // Günlük Kiralama Bedeli

        public string Description { get; set; }
    }
}
