﻿// LB
using System.Collections.Generic;
﻿using Common.Enums;
using Common.Interfaces;
using DataAccess;

namespace Domain.Model
{
    internal class Customer : AParty, ICustomer
    {
        #region Public Properties
        public CustomerType Type
        {
            get { return _customerEntity.Type; }
            set { _customerEntity.Type = value; }
        }
        public string ContactPerson
        {
            get { return _customerEntity.ContactPerson; }
            set { _customerEntity.ContactPerson = value; }
        }
        public string Email
        {
            get { return _customerEntity.Email; }
            set { _customerEntity.Email = value; }
        }
        public string Address
        {
            get { return _customerEntity.Address; }
            set { _customerEntity.Address = value; }
        }
        public string PhoneNo
        {
            get { return _customerEntity.PhoneNo; }
            set { _customerEntity.PhoneNo = value; }
        }
        public string FaxNo
        {
            get { return _customerEntity.FaxNo; }
            set { _customerEntity.FaxNo = value; }
        }
        #endregion

        #region Internal Methods
        internal Customer(ICustomer customerEntity, IDataAccessFacade dataAccessFacade)
        {
            this.dataAccessFacade = dataAccessFacade;
            _customerEntity = customerEntity;
            initializeParty(_customerEntity);
        }

        internal Customer(CustomerType type, string note, string name, IDataAccessFacade dataAccessFacade)
        {
            validateName(name);
            this.dataAccessFacade = dataAccessFacade;
            _customerEntity = dataAccessFacade.CreateCustomer(type, note, name);
            initializeParty(_customerEntity);
        }

        //Reads all entities of customer there is in the DataAccessFacade.
        //Returns them to a list here.
        internal static List<Customer> ReadAll(IDataAccessFacade dataAccessFacade)
        {
            List<ICustomer> customerEntities = dataAccessFacade.ReadAllCustomers();
            List<Customer> customers = new List<Customer>();

            foreach (ICustomer customerEntity in customerEntities)
            {
                Customer customer = new Customer(customerEntity, dataAccessFacade);
                customers.Add(customer);
            }
            return customers;
        }

        //Calls for updating an object of a customer. 
        //Gets a new LastModified date to now. 
        internal void Update()
        {
            dataAccessFacade.UpdateCustomers(_customerEntity);
        }

        //Calls for removing an object in a list of customers.
        internal void Delete()
        {
            dataAccessFacade.DeleteCustomer(_customerEntity);
        }
        #endregion

        #region Private fields
        internal ICustomer _customerEntity;
        private IDataAccessFacade dataAccessFacade;
        #endregion
    }
}
