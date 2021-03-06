﻿// TB
using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using DataAccess;

namespace Domain.Model
{
    internal class Booking : IBooking
    {
        #region Public Properties
        public ISupplier Supplier
        {
            get { return _supplier; }
            set 
            {
                validateSupplier(value);
                _supplier = (Supplier)value;
                _bookingEntity.Supplier = _supplier._supplierEntity;
            }
        }
        public ICustomer Customer
        {
            get { return _customer; }
            set 
            {
                validateCustomer(value);
                _customer = (Customer)value;
                _bookingEntity.Customer = _customer._customerEntity;
            }
        }
        public string Note
        {
            get { return _bookingEntity.Note; }
            set { _bookingEntity.Note = value; }
        }
        public string Sale
        {
            get { return _bookingEntity.Sale; }
            set 
            {
                validateSale(value);
                _bookingEntity.Sale = value; 
            }
        }
        public int BookingNumber
        {
            get { return _bookingEntity.BookingNumber; }
            set { _bookingEntity.BookingNumber = value; }
        }
        public DateTime StartDate
        {
            get { return _bookingEntity.StartDate; }
            set { _bookingEntity.StartDate = value; }
        }
        public DateTime EndDate
        {
            get { return _bookingEntity.EndDate; }
            set 
            {
                validateEndDate(StartDate, value);
                _bookingEntity.EndDate = value; 
            }
        }
        public BookingType Type
        {
            get { return _bookingEntity.Type; }
            set { _bookingEntity.Type = value; }
        }
        public decimal IVAExempt
        {
            get { return _bookingEntity.IVAExempt; }
            set 
            {
                validateNotNegative("IVAExempt", value);
                _bookingEntity.IVAExempt = value; 
            }
        }
        public decimal IVASubject
        {
            get { return _bookingEntity.IVASubject; }
            set 
            { 
                validateNotNegative("IVASubject", value);
                _bookingEntity.IVASubject = value; 
            }
        }
        public decimal Subtotal
        {
            get { return _bookingEntity.Subtotal; }
            set 
            { 
                validateNotNegative("Subtotal", value);
                _bookingEntity.Subtotal = value; 
            }
        }
        public decimal Service
        {
            get { return _bookingEntity.Service; }
            set 
            { 
                validateNotNegative("Service", value);
                _bookingEntity.Service = value; 
            }
        }
        public decimal IVA
        {
            get { return _bookingEntity.IVA; }
            set 
            { 
                validateNotNegative("IVA", value);
                _bookingEntity.IVA = value; 
            }
        }
        public decimal ProductRetention
        {
            get { return _bookingEntity.ProductRetention; }
            set 
            {
                validatePercentage("ProductRetention", value);
                _bookingEntity.ProductRetention = value; 
            }
        }

        public decimal SupplierRetention
        {
            get { return _bookingEntity.SupplierRetention; }
            set
            {
                validatePercentage("SupplierRetention", value);
                _bookingEntity.SupplierRetention = value;
            }
        }
        public decimal TransferAmount
        {
            get { return _bookingEntity.TransferAmount; }
            set 
            { 
                validateNotNegative("TransferAmount", value);
                _bookingEntity.TransferAmount = value; 
            }
        }
        #endregion

        #region Internal Constructor
        internal Booking(IBooking bookingEntity, IDataAccessFacade dataAccessFacade)
        {
            this.dataAccessFacade = dataAccessFacade;
            _bookingEntity = bookingEntity;

            // Create Models of supplier and customer
            _supplier = new Supplier(dataAccessFacade, _bookingEntity.Supplier);
            _customer = new Customer(_bookingEntity.Customer, dataAccessFacade);
        }

        internal Booking(Supplier supplier, Customer customer, string sale, int bookingNumber, DateTime startDate, 
            DateTime endDate, IDataAccessFacade dataAccessFacade)
        {
            validateSale(sale);
            validateEndDate(startDate, endDate);

            // Get entities for DataAccess
            ISupplier supplierEntity = supplier._supplierEntity;
            ICustomer customerEntity = customer._customerEntity;

            this.dataAccessFacade = dataAccessFacade;
            _bookingEntity = dataAccessFacade.CreateBooking(supplierEntity, customerEntity, sale, bookingNumber, 
                startDate, endDate);

            _supplier = supplier;
            _customer = customer;
        }
        #endregion

        #region Internal CRUD
        internal static List<Booking> ReadAll(IDataAccessFacade dataAccessFacade)
        {
            //Calls readall bookings and adds them to a list
            List<IBooking> bookingEntities = dataAccessFacade.ReadAllBookings();
            List<Booking> bookings = new List<Booking>();

            foreach (IBooking bookingEntity in bookingEntities)
            {
                Booking booking = new Booking(bookingEntity, dataAccessFacade);
                bookings.Add(booking);
            }
            return bookings;
        }

        internal void Update()
        {
            //Calls dataAccessFacade update method for updating a booking
            dataAccessFacade.UpdateBooking(_bookingEntity);
        }

        internal void Delete()
        {
            //Calls dataAccessFacade delete method for removing a booking from the list
            dataAccessFacade.DeleteBooking(_bookingEntity);
        }
        #endregion

        internal void CalculateAmounts()
        {
            Subtotal = IVAExempt + IVASubject;
            IVA = IVASubject * 0.12m;
            TransferAmount = Subtotal - (Subtotal * ProductRetention/100) + Service + IVA - (IVA * SupplierRetention/100);

            Update();
        }

        #region Private fields
        private IBooking _bookingEntity;
        private IDataAccessFacade dataAccessFacade;
        private Customer _customer;
        private Supplier _supplier;
        #endregion

        #region Validation
        private void validateSupplier(ISupplier value)
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException("Supplier", "Supplier was not found");
            }
        }

        private void validateCustomer(ICustomer value)
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException("Customer", "Customer was not found");
            }
        }
        private void validateSale(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException("Sale", "may not be empty");
            }
        }
        private void validateEndDate(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentOutOfRangeException("EndDate", "must be later than StartDate");
            }
        }
        private void validatePercentage(string paramName, decimal value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(paramName, "must be between 0 and 100");
            }
        }
        private void validateNotNegative(string paramName, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "must be greater than 0");
            }
        }
        #endregion
    }
}
