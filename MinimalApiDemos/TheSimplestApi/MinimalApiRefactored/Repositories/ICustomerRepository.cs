﻿using MinimalApiRefactored.Models;

namespace MinimalApiRefactored.Repositories;

public interface ICustomerRepository
{
     void Create(Customer customer);
     Customer GetById(Guid id);

     List<Customer> GetAll();

     void Update(Customer customer);

     void Delete(Guid id);
}

