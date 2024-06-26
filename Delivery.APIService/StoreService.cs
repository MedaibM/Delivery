﻿using Delivery.APIService.Models;
using Delivery.Repository;
using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.APIService
{
    public class StoreService
    {
        private readonly IConfiguration _configuration;
        public StoreService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void RegisterStore(StoreDetail storeDetails)
        {
            StoreDetailRepositoryDTO storeDetailObject = new StoreDetailRepositoryDTO();
            storeDetailObject.StoreId = Guid.NewGuid();
            storeDetailObject.StoreName = storeDetails.StoreName;
            storeDetailObject.Street = storeDetails.Address.Street;
            storeDetailObject.City = storeDetails.Address.City;
            storeDetailObject.State = storeDetails.Address.State;
            storeDetailObject.ZipCode = storeDetails.Address.ZipCode;
            storeDetailObject.PhoneNumber = storeDetails.PhoneNumber;
            storeDetailObject.RegistrationDate = DateTime.Now;
            storeDetailObject.ActiveStatus = true;

            StoreRepositoryService storeRepositoryService = new StoreRepositoryService(_configuration);
            storeRepositoryService.CreateStore(storeDetailObject);
        }
    }
}
