using CostingManagement.Core.Interfaces;
using CostingManagement.Data.DataContext;
using CostingManagement.DTO.Lookup.DiscrepancyStatus;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CostingManagement.Services.Lookup.DiscrepancyStatus
{
    public class DiscrepancyStatusService : IDiscrepancyStatusService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IResponseDTO _response;

        public DiscrepancyStatusService(AppDbContext appDbContext,
            IResponseDTO response)
        {
            _response = response;
            _appDbContext = appDbContext;
        }

        public IResponseDTO SearchDiscrepancyStatuses(DiscrepancyStatusFilterDto filterDto)
        {
            try
            {
                var query = _appDbContext.DiscrepancyStatuses.Where(x => !x.IsDeleted);

                if (filterDto != null)
                {
                    if (!string.IsNullOrEmpty(filterDto.Name))
                    {
                        query = query.Where(x => x.Name.Trim().ToLower().Contains(filterDto.Name.Trim().ToLower()));
                    }
                }

                //Check Sort Property
                if (!string.IsNullOrEmpty(filterDto?.SortProperty))
                {
                    //query = query.OrderBy(
                    //    string.Format("{0} {1}", filterDto.SortProperty, filterDto.IsAscending ? "ASC" : "DESC"));
                }
                else
                {
                    query = query.OrderByDescending(x => x.Id);
                }

                // Pagination
                var total = query.Count();
                if (filterDto.PageIndex.HasValue && filterDto.PageSize.HasValue)
                {
                    query = query.Skip((filterDto.PageIndex.Value - 1) * filterDto.PageSize.Value).Take(filterDto.PageSize.Value);
                }

                _response.IsPassed = true;
                _response.Data = new
                {
                    List = query.ToList(),
                    Total = total,
                };
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
        public async Task<IResponseDTO> CreateDiscrepancyStatus(CreateUpdateDiscrepancyStatusDto options, int userId)
        {
            try
            {
                var packageType = new Data.DbModels.LookupSchema.DiscrepancyStatus
                {
                    Name = options.Name,
                    Description = options.Description
                };

                await _appDbContext.DiscrepancyStatuses.AddAsync(packageType);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "Discrepancy status is created successfully";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
        public async Task<IResponseDTO> UpdateDiscrepancyStatus(int id, CreateUpdateDiscrepancyStatusDto options, int userId)
        {
            try
            {
                var packageType = _appDbContext.DiscrepancyStatuses.FirstOrDefault(x => x.Id == id);
                if (packageType == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid id";
                    return _response;
                }

                packageType.Name = options.Name;
                packageType.Description = options.Description;

                _appDbContext.DiscrepancyStatuses.Update(packageType);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "Discrepancy status is updated successfully";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
        public async Task<IResponseDTO> RemoveDiscrepancyStatus(int id)
        {
            try
            {
                var packageType = _appDbContext.DiscrepancyStatuses.FirstOrDefault(x => x.Id == id);
                if (packageType == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid id";
                    return _response;
                }

                packageType.IsDeleted = true;

                _appDbContext.DiscrepancyStatuses.Update(packageType);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "Discrepancy status is removed successfully";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
    }
}
