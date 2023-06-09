﻿using sqlapp.Models;

namespace sqlapp.Services
{
    public interface IProductService
    {
        //Task<List<Product>> GetProducts();
        List<Product> GetProducts();

        Task<bool> IsBetaFeatureEnabled();
    }
}