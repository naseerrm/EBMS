using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class InvoiceHdr
    {
        public InvoiceHdr()
        {
            InverseRefInvoiceHdrAuto = new HashSet<InvoiceHdr>();
        }

        public int InvoiceHdrAutoId { get; set; }
        public int? RefInvoiceHdrAutoId { get; set; }
        public string? GeneratedId { get; set; }
        public int? RawSeq { get; set; }
        public string? RawPrefix { get; set; }
        public DateTime InvoiceDt { get; set; }
        public int? JobCardTypeMasterAutoId { get; set; }
        public string? JobcardId { get; set; }
        public string? InvoiceStatus { get; set; }
        public string? Type { get; set; }
        public string? InvoiceType { get; set; }
        public int PartyAutoId { get; set; }
        public string? InvoiceTo { get; set; }
        public string? Gstno { get; set; }
        public bool IsInvoiceCancelled { get; set; }
        public bool IsOtherInvoice { get; set; }
        public bool IsBillOfSupply { get; set; }
        public string? PartyGstType { get; set; }
        public string? Rcmtype { get; set; }
        public bool Sezflag { get; set; }
        public string? Lutnumber { get; set; }
        public string? ExternalInvNo { get; set; }
        public DateTime? ExternalInvDate { get; set; }
        public int BaseCurrencyAutoId { get; set; }
        public decimal? BaseCurrencyAmt { get; set; }
        public string? BaseCurrAmtInWords { get; set; }
        public int? SecondaryCurrencyAutoId { get; set; }
        public decimal? SecondaryExchangeRate { get; set; }
        public decimal? ScndCurrencyAmt { get; set; }
        public string? ScndCurrAmtInWords { get; set; }
        public int InvoiceCurrencyAutoId { get; set; }
        public decimal InvoiceExchangeRate { get; set; }
        public decimal? TranCurrencyAmt { get; set; }
        public string? TranCurrAmtInWords { get; set; }
        public string? TaxType { get; set; }
        public bool Isrcmapplicable { get; set; }
        public bool IsLut { get; set; }
        public string? TaxInvoiceType { get; set; }
        public string? GsttaxInvType { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ReasonsForCreditNote { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? LastModifiedNature { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual CurrencyMaster InvoiceCurrencyAuto { get; set; } = null!;
        public virtual InvoiceHdr? RefInvoiceHdrAuto { get; set; }
        public virtual CurrencyMaster? SecondaryCurrencyAuto { get; set; }
        public virtual ICollection<InvoiceHdr> InverseRefInvoiceHdrAuto { get; set; }
    }
}
