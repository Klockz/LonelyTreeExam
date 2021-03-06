﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Enums;

namespace Common.Interfaces
{
    public interface IBooking 
    {
        ISupplier Supplier { get; set; }
        ICustomer Customer { get; set; }
        string Note { get; set; }
        string Sale { get; set; }
        int BookingNumber { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        BookingType Type { get; set; }
        decimal IVAExempt { get; set; }
        decimal IVASubject { get; set; }
        decimal Subtotal { get; set; }
        decimal Service { get; set; }
        decimal IVA { get; set; }
        decimal ProductRetention { get; set; }
        decimal SupplierRetention { get; set; }
        decimal TransferAmount { get; set; }
    }
}
