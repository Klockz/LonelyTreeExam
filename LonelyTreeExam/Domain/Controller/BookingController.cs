﻿using Common.Interfaces;
using DataAccess;
using Domain.Collections;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Controller
{
    public class BookingController
    {
        public BookingController()
        {
            dataAccessFacade = DataAccessFacade.GetInstance();
            bookingCollection = new BookingCollection(dataAccessFacade);
        }

        public List<IBooking> ReadAllBookings()
        {
            List<IBooking> bookings = new List<IBooking>();
            foreach (Booking booking in bookingCollection.ReadAll())
            {
                bookings.Add(booking);
            }
            return bookings;
        }

        public IBooking CreateBooking(IParty responsible, IParty commissioner, string sale, int bookingNumber,
            DateTime StartDate, DateTime EndDate)
        {
            return bookingCollection.Create(responsible, commissioner, sale, bookingNumber, StartDate, EndDate);
        }

        public void UpdateBooking(IBooking booking)
        {
            bookingCollection.Update((Booking) booking);
        }

        public void DeleteBooking(IBooking booking)
        {
            bookingCollection.Delete((Booking) booking);
        }

        #region Private Properties
        private IDataAccessFacade dataAccessFacade;
        private BookingCollection bookingCollection;
        #endregion
    }
}