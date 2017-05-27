using CPOSLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CPOSService.Controllers
{
    public class SPController : ApiController
    {
        private CPOSDBEntity db = new CPOSDBEntity();
        public int insertandupdateOrderedProductKOT(Nullable<int> ticketId, string d1, Nullable<decimal> d2, Nullable<int> d3, Nullable<decimal> d4, Nullable<decimal> d5, Nullable<decimal> d6, Nullable<decimal> d7, Nullable<decimal> d8, Nullable<decimal> d9, Nullable<decimal> d10, Nullable<decimal> d11, Nullable<decimal> d12, Nullable<decimal> d13, string d14)
        {
            return db.insertandupdateOrderedProductKOT(ticketId, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14); 
        }
        public int insertandupdateOrderedProductKOTTemp(Nullable<int> ticketId, string d1, Nullable<decimal> d2, Nullable<int> d3, Nullable<decimal> d4, Nullable<decimal> d5, Nullable<decimal> d6, Nullable<decimal> d7, Nullable<decimal> d8, Nullable<decimal> d9, Nullable<decimal> d10, Nullable<decimal> d11, Nullable<decimal> d12, Nullable<decimal> d13, string d14)
        {
            return db.insertandupdateOrderedProductKOTTemp(ticketId, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14);
        }
        public int InsertDailyCustomer(string customerName, Nullable<System.DateTime> customerDOB, string contact, Nullable<int> ticketId)
        {
            return db.InsertDailyCustomer(customerName, customerDOB, contact, ticketId);
        }
        public int SpInsertUpdateGrandTotal(Nullable<decimal> bALANCETOTAL, string d1, Nullable<System.DateTime> d2, string d3, string d4, string d5, string tICKETNO)
        {
            return db.SpInsertUpdateGrandTotal(bALANCETOTAL, d1, d2, d3, d4, d5, tICKETNO);
        }
        public int SpInsertUpdateGrandTotalTemp(Nullable<int> id, Nullable<decimal> bALANCETOTAL, string d1, Nullable<System.DateTime> d2, string d3, string d4, string d5, string tICKETNO)
        {
            return db.SpInsertUpdateGrandTotalTemp(id, bALANCETOTAL, d1, d2, d3, d4, d5, tICKETNO);
        }
    }
}
