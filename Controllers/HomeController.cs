using EBMSProject.DatabaseContext;
using EBMSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace EBMSProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GGEODEvalContext _Db;

        public HomeController(ILogger<HomeController> logger, GGEODEvalContext db)
        {
            _logger = logger;
            _Db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// submit controller file
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public JsonResult SubmitDate(string FromDate,string ToDate)
        {
            List<InvoiceTableViewModel> invoiceDetailsList = new List<InvoiceTableViewModel>();
            List<string> chargesNamelist = new List<string>();
            var fromDate = DateTime.ParseExact(FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            List<InvoiceHdr> data = _Db.InvoiceHdrs.Where(x => x.InvoiceDt >= fromDate.Date && x.InvoiceDt <= toDate.Date).Select(x => x).ToList();
            int sno = 0;
            foreach (var item in data)
            {
                sno++;
                InvoiceTableViewModel invoiceTableViewModel = new InvoiceTableViewModel();
                invoiceTableViewModel.SNo = sno;
                invoiceTableViewModel.InvoiceNumber = item.InvoiceHdrAutoId;
                invoiceTableViewModel.InvoiceDate = item.InvoiceDt.ToString("dd/MM/yyyy");
                invoiceTableViewModel.CustomerName = item.InvoiceTo;
                var invoiceDTl = _Db.InvoiceDtls.Where(x => x.InvoiceHdrAutoId == item.InvoiceHdrAutoId).Select(x => x).ToList();

                List<decimal> charges = invoiceDTl.Select(x => x.BaseCurrencyAmt).ToList();
                List<string> chargesname = invoiceDTl.Select(x => x.ChargePrintDisName).ToList();
                if (chargesname.Count > 0)
                {
                    chargesNamelist.AddRange(chargesname);
                }
                if (charges.Count > 0)
                {
                    invoiceTableViewModel.ChargersList = ConstructDic(invoiceDTl);
                }
                invoiceTableViewModel.TotalAmount = invoiceDTl.Select(x => x.BaseCurrencyAmt).Sum();
                invoiceDetailsList.Add(invoiceTableViewModel);
            }
            chargesNamelist = chargesNamelist.Distinct().ToList();

            foreach (var item in invoiceDetailsList)
            {
                foreach (var charge in item.ChargersList)
                {
                    charge.chargePosition = (5 + chargesNamelist.FindIndex(x => x == charge.chargePosition)).ToString();
                }
            }
            var structure = new
            {
                invoiceTableViewModels = invoiceDetailsList,
                chargesnameList = chargesNamelist
            };
            return Json(structure);
        }

        private List<chargeposition> ConstructDic(List<InvoiceDtl> invoiceDtls)
        {
            List<chargeposition> keyValuePairs = new List<chargeposition>();
            foreach (InvoiceDtl item in invoiceDtls)
            {
                keyValuePairs.Add(new chargeposition
                {
                    chargePosition = item.ChargePrintDisName,
                    chargeValue = item.BaseCurrencyAmt
                });
            }
            return keyValuePairs;
        }

        public class chargeposition
        {
            public string chargePosition { get; set; }
            public decimal chargeValue { get; set; }
        }

        public class InvoiceTableViewModel
        {
            public InvoiceTableViewModel()
            {
                ChargersList = new List<chargeposition>();
            }
            public int SNo { get; set; }
            public int InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string CustomerName { get; set; }
            public List<chargeposition> ChargersList { get; set; }
            public decimal TotalAmount { get; set; }
            public int ChargesCount { get; set; }
        }
    }
}