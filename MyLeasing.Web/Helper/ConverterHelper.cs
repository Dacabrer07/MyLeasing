using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helper
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<Contract> ToContractAsync(ContractViewModel model, bool isNew)
        {
            return new Contract
            {
                EndDate = model.EndDate.ToUniversalTime(),
                Id = isNew ? 0 : model.Id,
                IsActive = model.IsActive,
                Lessee = await _dataContext.Lessees.FindAsync(model.LesseeId),
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                Property = await _dataContext.Properties.FindAsync(model.PropertyId),
                Remarks = model.Remarks,
                StartDate = model.StartDate.ToUniversalTime(),              
            };
            
        }

        public ContractViewModel ToContractViewModel(Contract contract)
        {
            return new ContractViewModel
            {
                EndDate = contract.EndDateLocal,
                Id = contract.Id,
                IsActive = contract.IsActive,
                Lessee = contract.Lessee,
                Owner = contract.Owner,
                Price = contract.Price,
                Property = contract.Property,
                Remarks = contract.Remarks,
                StartDate = contract.StartDateLocal,
                OwnerId = contract.Owner.Id,
                LesseeId = contract.Lessee.Id,
                PropertyId = contract.Property.Id,
                Lessees = _combosHelper.GetComboLessees()
            };

        }

        public async Task<Property> ToPropertyAsync(PropertyViewModel model, bool isNew)
        {
            return new Property
            {
                Id = isNew ? 0 : model.Id,
                Address = model.Address,
                Contracts = isNew ? new List<Contract>() : model.Contracts,
                HasParkingLot = model.HasParkingLot,               
                Neighborhood = model.Neighborhood,
                IsAvailable = model.IsAvailable,
                Price = model.Price,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),                
                PropertyImages = isNew ? new List<PropertyImage>() : model.PropertyImages,
                PropertyType = await _dataContext.PropertyTypes.FindAsync(model.PropertyTypeId),
                Remarks = model.Remarks,
                Rooms = model.Rooms,
                SquareMeters = model.SquareMeters,
                Stratum = model.Stratum
            };
        }

        public PropertyViewModel ToPropertyViewModel(Property property)
        {
            return new PropertyViewModel
            {
                Id = property.Id,
                Address = property.Address,
                Contracts = property.Contracts,
                Neighborhood = property.Neighborhood,
                IsAvailable = property.IsAvailable,
                Price = property.Price,
                Owner = property.Owner,
                HasParkingLot = property.HasParkingLot,
                PropertyImages = property.PropertyImages,
                PropertyType = property.PropertyType,
                Remarks = property.Remarks,
                Rooms = property.Rooms,
                SquareMeters = property.SquareMeters,
                Stratum = property.Stratum,
                OwnerId = property.Owner.Id,
                PropertyTypeId = property.PropertyType.Id,
                PropertyTypes = _combosHelper.GetComboPropertyTypes()
            };
            
        }
    }
}
