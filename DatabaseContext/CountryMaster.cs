using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            CurrencyMasters = new HashSet<CurrencyMaster>();
        }

        public int CountryMasterAutoId { get; set; }
        public string CountryId { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string? Iso3code { get; set; }
        public string? CapitalName { get; set; }
        public string? PhonePrefix { get; set; }
        public string? StateLabel { get; set; }
        public bool IsGcc { get; set; }
        public string? TaxType { get; set; }
        public Guid? UniqueId { get; set; }
        public bool IsSaas { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual ICollection<CurrencyMaster> CurrencyMasters { get; set; }
    }
}
