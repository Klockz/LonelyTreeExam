﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace DataAccess.Entities
{
    internal class PaymentEntity : AAccountabilityEntity, IPayment
    {
        public DateTime DueDate { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public bool Archived { get; set; }
        public IReadOnlyList<string> Attachments
        {
            get { return _attachments; }
        }

        public PaymentEntity(DateTime dueDate, decimal dueAmount, string responsible, 
            string commissioner) 
            : base(responsible, commissioner)
        {
            _attachments = new List<string>();

            DueDate = dueDate;
            DueAmount = dueAmount;
            PaidDate = new DateTime(1900,01,01);
            PaidAmount = 0m;
            Paid = false;
            Archived = false;
        }

        public void DeleteAttachment(string attachment)
        {
            throw new NotImplementedException();
        }

        public void AddAttachment(string attachment)
        {
            _attachments.Add(attachment);
        }

        private List<string> _attachments;
    }
}
