using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class InvoiceDtl
    {
        public InvoiceDtl()
        {
            InverseRefInvoiceDtlAuto = new HashSet<InvoiceDtl>();
            InvoiceTaxDtls = new HashSet<InvoiceTaxDtl>();
        }

        public int InvoiceDtlAutoId { get; set; }
        public int InvoiceHdrAutoId { get; set; }
        public int? RefInvoiceDtlAutoId { get; set; }
        public int ChargeMasterAutoId { get; set; }
        public string? ChargePrintDisName { get; set; }
        public int CurrencyMasterAutoId { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal BaseCurrencyAmt { get; set; }
        public decimal BaseCurrencyTaxableAmt { get; set; }
        public decimal BaseCurrAmountWithTax { get; set; }
        public decimal TranCurrencyAmt { get; set; }
        public decimal TranCurrencyTaxableAmt { get; set; }
        public decimal TranCurrAmountWithTax { get; set; }
        public bool IsFullCredited { get; set; }
        public int? ContainerTypeAutoId { get; set; }
        public string? TaxCode { get; set; }
        public string? Saccode { get; set; }
        public string? Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? LastModifiedNature { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual ChargeMaster ChargeMasterAuto { get; set; } = null!;
        public virtual ContainerType? ContainerTypeAuto { get; set; }
        public virtual CurrencyMaster CurrencyMasterAuto { get; set; } = null!;
        public virtual InvoiceDtl? RefInvoiceDtlAuto { get; set; }
        public virtual ICollection<InvoiceDtl> InverseRefInvoiceDtlAuto { get; set; }
        public virtual ICollection<InvoiceTaxDtl> InvoiceTaxDtls { get; set; }
    }
}
