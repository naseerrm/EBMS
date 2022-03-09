using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class CurrencyMaster
    {
        public CurrencyMaster()
        {
            InvoiceDtls = new HashSet<InvoiceDtl>();
            InvoiceHdrInvoiceCurrencyAutos = new HashSet<InvoiceHdr>();
            InvoiceHdrSecondaryCurrencyAutos = new HashSet<InvoiceHdr>();
        }

        public int CurrencyMasterAutoId { get; set; }
        public string CurrencyId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? DecimalName { get; set; }
        public int? CountryMasterAutoId { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? CurrencyName { get; set; }
        public short? SubDivision { get; set; }
        public short? CurrencyDecimal { get; set; }
        public string? CurrencyStyle { get; set; }
        public Guid? UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual CountryMaster? CountryMasterAuto { get; set; }
        public virtual ICollection<InvoiceDtl> InvoiceDtls { get; set; }
        public virtual ICollection<InvoiceHdr> InvoiceHdrInvoiceCurrencyAutos { get; set; }
        public virtual ICollection<InvoiceHdr> InvoiceHdrSecondaryCurrencyAutos { get; set; }
    }
}
