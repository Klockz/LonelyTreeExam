﻿// PI
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Enums;

namespace DataAccess.Entities
{
    internal class PaymentEntity : Entity, IPayment
    {
        #region Public Properties
        public IParty Payee 
        {
            get { return _payee; }
            set { _payee = (APartyEntity)value; }
        }
        public IParty Payer 
        {
            get { return _payer; }
            set { _payer = (APartyEntity)value; }
        }
        public string Note { get; set; }
        public DateTime DueDate { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public bool Archived { get; set; }
        public PaymentType Type { get; set; }
        public string Sale { get; set; }
        public int Booking { get; set; }
        public string Invoice { get; set; }
        public IReadOnlyList<string> Attachments
        {
            get { return _attachments; }
        }
        #endregion

        #region Public Methods
        public PaymentEntity(DateTime dueDate, decimal dueAmount, IParty payer, 
            IParty payee, PaymentType type, string sale, int booking) 
        {
            _attachments = new List<string>();

            Payee = payee;
            Payer = payer;
            Note = "";
            DueDate = dueDate;
            DueAmount = dueAmount;
            PaidDate = new DateTime(1900,01,01);
            PaidAmount = 0m;
            Paid = false;
            Archived = false;
            Type = type;
            Sale = sale;
            Booking = booking;
            Invoice = "";
        }

        public void DeleteAttachment(string attachment)
        {
            _attachments.Remove(attachment);
        }

        public void AddAttachment(string attachment)
        {
            _attachments.Add(attachment);
        }
        #endregion

        private APartyEntity _payer;
        private APartyEntity _payee;
        private List<string> _attachments;
    }
}
