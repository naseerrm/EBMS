using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class InvoiceTaxDtl
    {
        public int InvoiceTaxDtlAutoId { get; set; }
        public int InvoiceDtlAutoId { get; set; }
        public string TaxType { get; set; } = null!;
        public int? ChargeMasterAutoId { get; set; }
        public string? Description { get; set; }
        public decimal AppliedTaxRate { get; set; }
        public decimal BaseCurrTaxAmount { get; set; }
        public int TaxTypeAutoId { get; set; }
        public decimal TranCurrTaxAmount { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? LastModifiedNature { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual ChargeMaster? ChargeMasterAuto { get; set; }
        public virtual InvoiceDtl InvoiceDtlAuto { get; set; } = null!;
    }
}
