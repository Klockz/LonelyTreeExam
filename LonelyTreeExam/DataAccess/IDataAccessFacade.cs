﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Enums;

namespace DataAccess
{
   public interface IDataAccessFacade
   {
        IPayment CreatePayment(DateTime dueDate, decimal dueAmount, string responsible,
            string commissioner, PaymentType type, string sale, int booking);
        List<IPayment> ReadAllPayments();
        void UpdatePayment(IPayment payment);
        void DeletePayment(IPayment payment);

       ISupplier CreateSupplier();
       List<ISupplier> ReadAllSuppliers();
       void UpdateSupplier(ISupplier supplier);
       void DeleteSupplier(ISupplier supplier);

       ICustomer CreateCustomer();
       List<ICustomer> ReadAllCustomers();
       void UpdateCustomers(ICustomer customer);
       void DeleteCustomer(ICustomer customer);
   }
}

