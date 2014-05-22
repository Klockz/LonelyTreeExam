﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Entities;
using DataAccess.Helpers;
using System.Data.SqlClient;
using Common.Enums;
using Common.Interfaces;

namespace DataAccess.Mappers
{
    internal class PaymentRuleMapper : ASQLMapper<PaymentRuleEntity>
    {
        internal SupplierMapper SupplierMapper;
        internal CustomerMapper CustomerMapper;

        internal PaymentRuleMapper(string connectionString)
        {
            this.connectionString = connectionString;
            this.entityMap = new Dictionary<int, PaymentRuleEntity>();
        }

        // WHOOPS! Conversion from interface to entity should be happening in Facade!
        internal PaymentRuleEntity Create(ISupplier supplierEntity, ICustomer customerEntity, BookingType bookingType,
            decimal percentage, int daysOffset, BaseDate baseDate, PaymentType paymentType)
        {
            PaymentRuleEntity paymentRuleEntity = new PaymentRuleEntity(supplierEntity, customerEntity, bookingType,
            percentage, daysOffset, baseDate, paymentType);

            insert(paymentRuleEntity);

            return paymentRuleEntity;
        }

        internal List<PaymentRuleEntity> ReadAll()
        {
            List<PaymentRuleEntity> paymentRules = selectAll();

            // Finalize!!

            return paymentRules;
        }

        internal void Update(PaymentRuleEntity paymentRule)
        {
            update(paymentRule);
        }

        internal void Delete(PaymentRuleEntity paymentRule)
        {
            paymentRule.Deleted = true;
            Update(paymentRule);
        }

        protected override string insertProcedureName
        {
            get { return StoredProcedures.CREATE_PAYMENT_RULE; }
        }

        protected override string selectAllProcedureName
        {
            get { return StoredProcedures.READ_ALL_PAYMENT_RULES; }
        }

        protected override string updateProcedureName
        {
            get { return StoredProcedures.UPDATE_PAYMENT_RULE; }
        }

        protected override PaymentRuleEntity entityFromReader(SqlDataReader reader)
        {
            int supplierId = (int)reader["Supplier"];
            int customerId = (int)reader["Customer"];
            SupplierEntity supplier = SupplierMapper.Read(supplierId);
            CustomerEntity customer = CustomerMapper.Read(customerId);
            BookingType bookingType = (BookingType)Enum.Parse(typeof(BookingType), reader["BookingType"].ToString());
            decimal percentage = (decimal)reader["Percentage"];
            int daysOffset = (int)reader["DaysOffset"];
            BaseDate baseDate = (BaseDate)Enum.Parse(typeof(BaseDate), reader["BaseDate"].ToString());
            PaymentType paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), reader["PaymentType"].ToString());

            PaymentRuleEntity paymentRuleEntity = new PaymentRuleEntity(supplier, customer, bookingType, percentage,
                daysOffset, baseDate, paymentType);

            return paymentRuleEntity;
        }

        protected override void addInsertParameters(PaymentRuleEntity entity, SqlParameterCollection parameters)
        {
            addPaymentRuleParameters(entity, parameters);
        }

        protected override void addUpdateParameters(PaymentRuleEntity entity, SqlParameterCollection parameters)
        {
            addPaymentRuleParameters(entity, parameters);
        }

        private void addPaymentRuleParameters(PaymentRuleEntity entity, SqlParameterCollection parameters)
        {
            SqlParameter parameter = new SqlParameter("@Supplier", ((SupplierEntity)entity.Supplier).Id);
            parameters.Add(parameter);
            parameter = new SqlParameter("@Customer", ((CustomerEntity)entity.Customer).Id);
            parameters.Add(parameter);
            parameter = new SqlParameter("@BookingType", entity.BookingType.ToString());
            parameters.Add(parameter);
            parameter = new SqlParameter("@Percentage", entity.Percentage);
            parameters.Add(parameter);
            parameter = new SqlParameter("@DaysOffset", entity.DaysOffset);
            parameters.Add(parameter);
            parameter = new SqlParameter("@BaseDate", entity.BaseDate.ToString());
            parameters.Add(parameter);
            parameter = new SqlParameter("@PaymentType", entity.PaymentType.ToString());
        }

    }
}