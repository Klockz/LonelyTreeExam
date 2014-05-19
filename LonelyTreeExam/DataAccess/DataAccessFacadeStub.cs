﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Common.Enums;

namespace DataAccess
{
    public class DataAccessFacadeStub : IDataAccessFacade
    {
        List<IPayment> payments;
        #region Payment Stuff

        public DataAccessFacadeStub()
        {
            payments = new List<IPayment>();
            customers = new List<ICustomer>();
        }

        public IPayment CreatePayment(DateTime dueDate, decimal dueAmount, string responsible, string commissioner, 
            PaymentType type, string sale, int booking)
        {
            PaymentEntity entity = new PaymentEntity(dueDate, dueAmount, responsible, commissioner, type, sale, booking);
            payments.Add(entity);

            return entity;
        }

        public List<IPayment> ReadAllPayments()
        {
            return payments;
        }

        public void UpdatePayment(IPayment payment)
        {
            PaymentEntity entity = (PaymentEntity)payment;

            entity.LastModified = DateTime.Now;
        }

        public void DeletePayment(IPayment payment)
        {
            PaymentEntity entity = (PaymentEntity)payment;

            entity.Deleted = true;
        }
        #endregion

        #region Supplier Stuff
        List<ISupplier> supplierList = new List<ISupplier>();

        public ISupplier CreateSupplier(string paymentinfo, string name, string note, SupplierType type)
        {
            SupplierEntity entity = new SupplierEntity(paymentinfo, type, note, name);
            supplierList.Add(entity);

            return entity;
        }

        public List<ISupplier> ReadAllSuppliers()
        {
            return supplierList;
        }

        public void UpdateSupplier(ISupplier supplier)
        {
            SupplierEntity entity = (SupplierEntity) supplier;
            entity.LastModified = DateTime.Now;
        }

        public void DeleteSupplier(ISupplier supplier)
        {
            SupplierEntity entity = (SupplierEntity) supplier;
            entity.Deleted = true;
        }
        #endregion

        #region Customer Stuff

        private List<ICustomer> customers;

        public ICustomer CreateCustomer(CustomerType type, string note, string name)
        {
            CustomerEntity entity = new CustomerEntity(type, note, name);
            customers.Add(entity);
            return entity;
        }

        public List<ICustomer> ReadAllCustomers()
        {
            return customers;
        }

        public void UpdateCustomers(ICustomer customer)
        {
            CustomerEntity entity = (CustomerEntity) customer;
            entity.LastModified = DateTime.Now;
        }

        public void DeleteCustomer(ICustomer customer)
        {
            CustomerEntity entity = (CustomerEntity) customer;
            entity.Deleted = true;
        }
        #endregion
        
    }
}
