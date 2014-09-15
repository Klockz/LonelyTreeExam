﻿/*
Copyright 2014 The Friendly TOM Team (see AUTHORS.rst)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Common.Enums;
using Common.Interfaces;
using DataAccess;
using Domain.Collections;
using Domain.Model;
using System.Collections.Generic;

namespace Domain.Controller
{
    public class SupplierController
    {
       #region Public Methods
        public SupplierController()
        {
            dataAccessFacade = DataAccessFacade.GetInstance();
            supplierCollection = new SupplierCollection(dataAccessFacade);
        }

        /// <summary>
        /// For testing against a specified DataAccessFacade
        /// </summary>
        /// <param name="dataAccessFacade"></param>
        public SupplierController(IDataAccessFacade dataAccessFacade)
        {
            this.dataAccessFacade = dataAccessFacade;
            supplierCollection = new SupplierCollection(dataAccessFacade);
        }

        public ISupplier CreateSupplier(string name, string note,
            SupplierType type)
        {
            //Calls the suppliercollection class for create.
            return supplierCollection.Create(name, note, type);
        }

        public List<ISupplier> ReadAllSuppliers()
        {
            //Calls the suppliercollection class for readall 
            List<ISupplier> suppliers = new List<ISupplier>();
            foreach (Supplier supplier in supplierCollection.ReadAll())
            {
                suppliers.Add(supplier);
            }

            return suppliers;
        }
        
        public void UpdateSupplier(ISupplier supplier)
        {
            //Calls the suppliercollection class for update
            supplierCollection.Update((Supplier) supplier);
        }

        public void DeleteSupplier(ISupplier supplier)
        {
            //Calls the suppliercollection class for delete
            supplierCollection.Delete((Supplier) supplier);
        }

        public void AddPaymentRule(ISupplier supplier, ICustomer customer, BookingType bookingType, decimal percentage,
            int daysOffset, BaseDate baseDate, PaymentType paymentType)
        {
            Supplier supp = (Supplier)supplier;
            Customer cust = (Customer)customer;

            supp.AddPaymentRule(cust, bookingType, percentage, daysOffset, baseDate, paymentType);
        }

        public void DeletePaymentRule(IPaymentRule paymentRule)
        {
            PaymentRule payRule = (PaymentRule)paymentRule;
            Supplier supp = (Supplier)payRule.Supplier;

            supp.DeletePaymentRule(payRule);
        }
        #endregion

       #region Private Properties
        private IDataAccessFacade dataAccessFacade;
        private SupplierCollection supplierCollection;
        #endregion
    }
}
