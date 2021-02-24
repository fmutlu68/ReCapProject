using Core.Entities;
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

        public decimal DailyPrice { get; set; } // Günlük Kiralama Bedeli

        public string Description { get; set; }

        public override string ToString() => "Araba";
    }
}
