﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces
{
    public interface IExampleService
    {
        Task<List<Example>> FindAllAsync();
        Task<Example> FindAsync(int id);
        Task<bool> UpdateAsync(Example example);
        Task<bool> InsertAsync(Example example);
    }
}
