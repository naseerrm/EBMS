using System;
using System.Collections.Generic;

namespace EBMSProject.DatabaseContext
{
    public partial class ContainerType
    {
        public ContainerType()
        {
            InvoiceDtls = new HashSet<InvoiceDtl>();
        }

        public int ContainerTypeAutoId { get; set; }
        public string ContainerTypeId { get; set; } = null!;
        public string ContainerCommonName { get; set; } = null!;
        public string IsoCode { get; set; } = null!;
        public string NewIsoCode { get; set; } = null!;
        public decimal? WeightLimit { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid UniqueId { get; set; }
        public string Ngstatus { get; set; } = null!;

        public virtual ICollection<InvoiceDtl> InvoiceDtls { get; set; }
    }
}
