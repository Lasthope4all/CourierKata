﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata.Core.Services
{
    public interface IParcelPriceCalculator
    {
        public decimal GetPrice(ParcelSizeType parcelSizeType);
    }
}
