﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain.Model;
using Common.Enums;

namespace Domain.Collections
{
    internal class PaymentCollection
    {
        #region Internal Methods

        /// <summary>
        /// make a collection of information from readAll.
        /// </summary>
        /// <param name="dataAccessFacade"></param>
        internal PaymentCollection(IDataAccessFacade dataAccessFacade)
        {
            this.dataAccessFacade = dataAccessFacade;

            ReadAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>payments</returns>
         internal List<Payment> ReadAll()
        {
            if (payments == null)
            {
                payments = Payment.ReadAll(dataAccessFacade);
            }

            return payments;
        }

         internal Payment Create(DateTime dueDate, decimal dueAmount, string responsible,
             string commissioner, PaymentType type)
        {
            Payment payment = new Payment(dueDate, dueAmount, responsible, commissioner, type, dataAccessFacade);
            payments.Add(payment);

            return payment;
        }

         public void Update(Payment payment)
         {
             payment.Update();
         }

         internal void Delete(Payment payment)
         {
             payment.Delete();
             payments.Remove(payment);
         }
        #endregion

        #region Private Properties
        private IDataAccessFacade dataAccessFacade;
        private List<Payment> payments;
        #endregion
    }
}
