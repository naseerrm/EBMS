using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class ChargeMaster
    {
        public ChargeMaster()
        {
            InvoiceDtls = new HashSet<InvoiceDtl>();
            InvoiceTaxDtls = new HashSet<InvoiceTaxDtl>();
        }

        public int ChargeMasterAutoId { get; set; }
        public string? ChargeCode { get; set; }
        public string ChargeName { get; set; } = null!;
        public int? CurrencyMasterAutoId { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid? UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual ICollection<InvoiceDtl> InvoiceDtls { get; set; }
        public virtual ICollection<InvoiceTaxDtl> InvoiceTaxDtls { get; set; }
    }
}
