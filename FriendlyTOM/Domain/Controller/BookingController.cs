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

using Common.Interfaces;
using DataAccess;
using Domain.Collections;
using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain.Controller
{
    public class BookingController
    {
        #region Public Constructor
        public BookingController(PaymentController paymentController, CustomerController customerController)
        {
            dataAccessFacade = DataAccessFacade.GetInstance();
            bookingCollection = new BookingCollection(dataAccessFacade);
            this.paymentController = paymentController;
            this.customerController = customerController;
        }

        /// <summary>
        /// For testing against a specified DataAccessFacade
        /// </summary>
        /// <param name="dataAccessFacade"></param>
        public BookingController(PaymentController paymentController, CustomerController customerController,
            IDataAccessFacade dataAccessFacade)
        {
            this.dataAccessFacade = dataAccessFacade;
            bookingCollection = new BookingCollection(dataAccessFacade);
            this.paymentController = paymentController;
            this.customerController = customerController;
        }
        #endregion

        #region Public CRUD
        public IBooking CreateBooking(ISupplier supplier, ICustomer customer, string sale, int bookingNumber,
            DateTime StartDate, DateTime EndDate)
        {
            //Calls Bookingcollection class for create
            return bookingCollection.Create((Supplier)supplier, (Customer)customer, sale, bookingNumber, StartDate, 
                EndDate);
        }

        public List<IBooking> ReadAllBookings()
        {
            //Calls Bookingcollection class for readall
            List<IBooking> bookings = new List<IBooking>();
            foreach (Booking booking in bookingCollection.ReadAll())
            {
                bookings.Add(booking);
            }
            return bookings;
        }

        public void UpdateBooking(IBooking booking)
        {
            //Calls Bookingcollection class for update
            bookingCollection.Update((Booking) booking);
        }

        public void DeleteBooking(IBooking booking)
        {
            //Calls Bookingcollection class for delete
            bookingCollection.Delete((Booking) booking);
        }
        #endregion

        public void CalculatePaymentsForBooking(IBooking booking)
        {
            Booking bookingModel = (Booking)booking;
            bookingModel.CalculateAmounts();
            PaymentStrategy paymentStrategy = new PaymentStrategy(customerController);
            paymentStrategy.CreatePayments(bookingModel, paymentController);
        }

        #region Private Properties
        private IDataAccessFacade dataAccessFacade;
        private BookingCollection bookingCollection;
        private PaymentController paymentController;
        private CustomerController customerController;
        #endregion
    }
}