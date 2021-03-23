using CostingManagement.Core.Interfaces;
using CostingManagement.Data.DataContext;
using CostingManagement.DTO.Lookup.VAT;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CostingManagement.Services.Lookup.VAT
{
    public class VatService : IVatService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IResponseDTO _response;

        public VatService(AppDbContext appDbContext,
            IResponseDTO response)
        {
            _response = response;
            _appDbContext = appDbContext;
        }

        public IResponseDTO SearchVats(VatFilterDto filterDto)
        {
            try
            {
                var query = _appDbContext.VATs.Where(x => !x.IsDeleted);

                if (filterDto != null)
                {
                    if (filterDto.VatPercentage != null)
                    {
                        query = query.Where(x => x.VatPercentage == filterDto.VatPercentage);
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
        public async Task<IResponseDTO> CreateVat(CreateUpdateVatDto options, int userId)
        {
            try
            {
                var vat = new Data.DbModels.LookupSchema.VAT
                {
                    VatPercentage = options.VatPercentage
                };

                await _appDbContext.VATs.AddAsync(vat);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "VAT is created successfully";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
        public async Task<IResponseDTO> UpdateVat(int id, CreateUpdateVatDto options, int userId)
        {
            try
            {
                var vat = _appDbContext.VATs.FirstOrDefault(x => x.Id == id);
                if (vat == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid id";
                    return _response;
                }

                vat.VatPercentage = options.VatPercentage;

                _appDbContext.VATs.Update(vat);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "VAT is updated successfully";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }
        public async Task<IResponseDTO> RemoveVat(int id)
        {
            try
            {
                var vat = _appDbContext.VATs.FirstOrDefault(x => x.Id == id);
                if (vat == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid id";
                    return _response;
                }

                vat.IsDeleted = true;

                _appDbContext.VATs.Update(vat);

                // save to the database
                var save = await _appDbContext.SaveChangesAsync();
                if (save == 0)
                {
                    _response.IsPassed = false;
                    _response.Message = "Database did not save the object";
                    return _response;
                }

                _response.IsPassed = true;
                _response.Message = "VAT is removed successfully";
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
