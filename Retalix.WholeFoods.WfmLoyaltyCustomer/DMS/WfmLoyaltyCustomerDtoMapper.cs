using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.WholeFoods.WfmLoyaltyCustomer.DAL.DTO;
using System;
using System.Linq;

namespace Retalix.WholeFoods.WfmLoyaltyCustomer.DMS
{
    public class WfmLoyaltyCustomerDtoMapper : IEntityToDtoMapper
    {
        public INamedObject MovableToDto(IMovable movable)
        {
            var mapping = (WfmLoyaltyCustomerDto)movable;
            return new WfmLoyaltyCustomerDtoDms
            {
                Id = mapping.Id,
                Store = mapping.Store,
                Customer = mapping.Customer,
                Mobile = mapping.Mobile,
                Address = mapping.Address,
                LoyaltyCode = mapping.LoyaltyCode
            };
        }

        public IMovable DtoToMovable(INamedObject dto)
        {
            var mapping = (WfmLoyaltyCustomerDtoDms)dto;
            return new WfmLoyaltyCustomerDto
            {
                Id = mapping.Id,
                Store = mapping.Store,
                Customer = mapping.Customer,
                Mobile = mapping.Mobile,
                Address = mapping.Address,
                LoyaltyCode = mapping.LoyaltyCode
            };
        }

        public Type GetNamedObjectType(string entityName, MappingMetadata mappingMetadata)
        {
            return typeof(WfmLoyaltyCustomerDtoDms);
        }

        public string[] GetEntityNamesForVersion(string entityName, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return new[] { entityName };
        }

        public DtosForVersions[] Map(IMovable[] movables, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return mappingMetadata.TargetNodesVersion.Select(
                targetNodeVersion => new DtosForVersions
                {
                    Dtos =
                        movables.Select(MovableToDto).Where(
                            movableToDto => movableToDto != null).ToArray(),
                    Versions = new[] { targetNodeVersion }
                }).ToArray();
        }

        public IMovable[] MapBack(INamedObject[] dtos, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return dtos.Select(DtoToMovable).Where(movable => movable != null).ToArray();
        }
    }
}
