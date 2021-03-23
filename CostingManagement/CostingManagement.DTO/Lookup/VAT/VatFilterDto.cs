using CostingManagement.Core.Common;

namespace CostingManagement.DTO.Lookup.VAT
{
    public class VatFilterDto : BaseFilterDto
    {
        public decimal? VatPercentage { get; set; }

    }
}
