﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPOSLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CPOSDBEntity : DbContext
    {
        public CPOSDBEntity()
            : base("name=CPOSDBEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activation> Activations { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<EmailSetting> EmailSettings { get; set; }
        public virtual DbSet<EmployeeRegistration> EmployeeRegistrations { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<GridGrouping> GridGroupings { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Kitchen> Kitchens { get; set; }
        public virtual DbSet<LedgerBook> LedgerBooks { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberLedger> MemberLedgers { get; set; }
        public virtual DbSet<NotesMaster> NotesMasters { get; set; }
        public virtual DbSet<OtherSetting> OtherSettings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PosGrouping> PosGroupings { get; set; }
        public virtual DbSet<PosGrouping1> PosGrouping1 { get; set; }
        public virtual DbSet<PosPrinterSetting> PosPrinterSettings { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_OpeningStock> Product_OpeningStock { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Purchase_Join> Purchase_Join { get; set; }
        public virtual DbSet<R_Table> R_Table { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Recipe_Join> Recipe_Join { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<RestaurantPOS_BillingInfoEB> RestaurantPOS_BillingInfoEB { get; set; }
        public virtual DbSet<RestaurantPOS_BillingInfoHD> RestaurantPOS_BillingInfoHD { get; set; }
        public virtual DbSet<RestaurantPOS_BillingInfoKOT> RestaurantPOS_BillingInfoKOT { get; set; }
        public virtual DbSet<RestaurantPOS_BillingInfoTA> RestaurantPOS_BillingInfoTA { get; set; }
        public virtual DbSet<RestaurantPOS_OrderedProductBillEB> RestaurantPOS_OrderedProductBillEB { get; set; }
        public virtual DbSet<RestaurantPOS_OrderedProductBillHD> RestaurantPOS_OrderedProductBillHD { get; set; }
        public virtual DbSet<RestaurantPOS_OrderedProductBillKOT> RestaurantPOS_OrderedProductBillKOT { get; set; }
        public virtual DbSet<RestaurantPOS_OrderedProductBillTA> RestaurantPOS_OrderedProductBillTA { get; set; }
        public virtual DbSet<RestaurantPOS_OrderedProductKOT> RestaurantPOS_OrderedProductKOT { get; set; }
        public virtual DbSet<RestaurantPOS_OrderInfoKOT> RestaurantPOS_OrderInfoKOT { get; set; }
        public virtual DbSet<SMSSetting> SMSSettings { get; set; }
        public virtual DbSet<Stock_Store> Stock_Store { get; set; }
        public virtual DbSet<Stock_Store_Join> Stock_Store_Join { get; set; }
        public virtual DbSet<StockTransfer> StockTransfers { get; set; }
        public virtual DbSet<StockTransfer_Join> StockTransfer_Join { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierLedgerBook> SupplierLedgerBooks { get; set; }
        public virtual DbSet<Temp_Stock> Temp_Stock { get; set; }
        public virtual DbSet<Temp_Stock_RM> Temp_Stock_RM { get; set; }
        public virtual DbSet<Temp_Stock_Store> Temp_Stock_Store { get; set; }
        public virtual DbSet<TempRestaurantPOS_OrderedProductKOT> TempRestaurantPOS_OrderedProductKOT { get; set; }
        public virtual DbSet<TempRestaurantPOS_OrderInfoKOT> TempRestaurantPOS_OrderInfoKOT { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Voucher_OtherDetails> Voucher_OtherDetails { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }
        public virtual DbSet<WorkPeriodEnd> WorkPeriodEnds { get; set; }
        public virtual DbSet<WorkPeriodStart> WorkPeriodStarts { get; set; }
    
        public virtual int insertandupdateOrderedProductKOT(Nullable<int> ticketId, string d1, Nullable<decimal> d2, Nullable<int> d3, Nullable<decimal> d4, Nullable<decimal> d5, Nullable<decimal> d6, Nullable<decimal> d7, Nullable<decimal> d8, Nullable<decimal> d9, Nullable<decimal> d10, Nullable<decimal> d11, Nullable<decimal> d12, Nullable<decimal> d13, string d14)
        {
            var ticketIdParameter = ticketId.HasValue ?
                new ObjectParameter("ticketId", ticketId) :
                new ObjectParameter("ticketId", typeof(int));
    
            var d1Parameter = d1 != null ?
                new ObjectParameter("d1", d1) :
                new ObjectParameter("d1", typeof(string));
    
            var d2Parameter = d2.HasValue ?
                new ObjectParameter("d2", d2) :
                new ObjectParameter("d2", typeof(decimal));
    
            var d3Parameter = d3.HasValue ?
                new ObjectParameter("d3", d3) :
                new ObjectParameter("d3", typeof(int));
    
            var d4Parameter = d4.HasValue ?
                new ObjectParameter("d4", d4) :
                new ObjectParameter("d4", typeof(decimal));
    
            var d5Parameter = d5.HasValue ?
                new ObjectParameter("d5", d5) :
                new ObjectParameter("d5", typeof(decimal));
    
            var d6Parameter = d6.HasValue ?
                new ObjectParameter("d6", d6) :
                new ObjectParameter("d6", typeof(decimal));
    
            var d7Parameter = d7.HasValue ?
                new ObjectParameter("d7", d7) :
                new ObjectParameter("d7", typeof(decimal));
    
            var d8Parameter = d8.HasValue ?
                new ObjectParameter("d8", d8) :
                new ObjectParameter("d8", typeof(decimal));
    
            var d9Parameter = d9.HasValue ?
                new ObjectParameter("d9", d9) :
                new ObjectParameter("d9", typeof(decimal));
    
            var d10Parameter = d10.HasValue ?
                new ObjectParameter("d10", d10) :
                new ObjectParameter("d10", typeof(decimal));
    
            var d11Parameter = d11.HasValue ?
                new ObjectParameter("d11", d11) :
                new ObjectParameter("d11", typeof(decimal));
    
            var d12Parameter = d12.HasValue ?
                new ObjectParameter("d12", d12) :
                new ObjectParameter("d12", typeof(decimal));
    
            var d13Parameter = d13.HasValue ?
                new ObjectParameter("d13", d13) :
                new ObjectParameter("d13", typeof(decimal));
    
            var d14Parameter = d14 != null ?
                new ObjectParameter("d14", d14) :
                new ObjectParameter("d14", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertandupdateOrderedProductKOT", ticketIdParameter, d1Parameter, d2Parameter, d3Parameter, d4Parameter, d5Parameter, d6Parameter, d7Parameter, d8Parameter, d9Parameter, d10Parameter, d11Parameter, d12Parameter, d13Parameter, d14Parameter);
        }
    
        public virtual int insertandupdateOrderedProductKOTTemp(Nullable<int> ticketId, string d1, Nullable<decimal> d2, Nullable<int> d3, Nullable<decimal> d4, Nullable<decimal> d5, Nullable<decimal> d6, Nullable<decimal> d7, Nullable<decimal> d8, Nullable<decimal> d9, Nullable<decimal> d10, Nullable<decimal> d11, Nullable<decimal> d12, Nullable<decimal> d13, string d14)
        {
            var ticketIdParameter = ticketId.HasValue ?
                new ObjectParameter("ticketId", ticketId) :
                new ObjectParameter("ticketId", typeof(int));
    
            var d1Parameter = d1 != null ?
                new ObjectParameter("d1", d1) :
                new ObjectParameter("d1", typeof(string));
    
            var d2Parameter = d2.HasValue ?
                new ObjectParameter("d2", d2) :
                new ObjectParameter("d2", typeof(decimal));
    
            var d3Parameter = d3.HasValue ?
                new ObjectParameter("d3", d3) :
                new ObjectParameter("d3", typeof(int));
    
            var d4Parameter = d4.HasValue ?
                new ObjectParameter("d4", d4) :
                new ObjectParameter("d4", typeof(decimal));
    
            var d5Parameter = d5.HasValue ?
                new ObjectParameter("d5", d5) :
                new ObjectParameter("d5", typeof(decimal));
    
            var d6Parameter = d6.HasValue ?
                new ObjectParameter("d6", d6) :
                new ObjectParameter("d6", typeof(decimal));
    
            var d7Parameter = d7.HasValue ?
                new ObjectParameter("d7", d7) :
                new ObjectParameter("d7", typeof(decimal));
    
            var d8Parameter = d8.HasValue ?
                new ObjectParameter("d8", d8) :
                new ObjectParameter("d8", typeof(decimal));
    
            var d9Parameter = d9.HasValue ?
                new ObjectParameter("d9", d9) :
                new ObjectParameter("d9", typeof(decimal));
    
            var d10Parameter = d10.HasValue ?
                new ObjectParameter("d10", d10) :
                new ObjectParameter("d10", typeof(decimal));
    
            var d11Parameter = d11.HasValue ?
                new ObjectParameter("d11", d11) :
                new ObjectParameter("d11", typeof(decimal));
    
            var d12Parameter = d12.HasValue ?
                new ObjectParameter("d12", d12) :
                new ObjectParameter("d12", typeof(decimal));
    
            var d13Parameter = d13.HasValue ?
                new ObjectParameter("d13", d13) :
                new ObjectParameter("d13", typeof(decimal));
    
            var d14Parameter = d14 != null ?
                new ObjectParameter("d14", d14) :
                new ObjectParameter("d14", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertandupdateOrderedProductKOTTemp", ticketIdParameter, d1Parameter, d2Parameter, d3Parameter, d4Parameter, d5Parameter, d6Parameter, d7Parameter, d8Parameter, d9Parameter, d10Parameter, d11Parameter, d12Parameter, d13Parameter, d14Parameter);
        }
    
        public virtual int InsertDailyCustomer(string customerName, Nullable<System.DateTime> customerDOB, string contact, Nullable<int> ticketId)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var customerDOBParameter = customerDOB.HasValue ?
                new ObjectParameter("CustomerDOB", customerDOB) :
                new ObjectParameter("CustomerDOB", typeof(System.DateTime));
    
            var contactParameter = contact != null ?
                new ObjectParameter("Contact", contact) :
                new ObjectParameter("Contact", typeof(string));
    
            var ticketIdParameter = ticketId.HasValue ?
                new ObjectParameter("TicketId", ticketId) :
                new ObjectParameter("TicketId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertDailyCustomer", customerNameParameter, customerDOBParameter, contactParameter, ticketIdParameter);
        }
    
        public virtual int SpInsertUpdateGrandTotal(Nullable<decimal> bALANCETOTAL, string d1, Nullable<System.DateTime> d2, string d3, string d4, string d5, string tICKETNO)
        {
            var bALANCETOTALParameter = bALANCETOTAL.HasValue ?
                new ObjectParameter("BALANCETOTAL", bALANCETOTAL) :
                new ObjectParameter("BALANCETOTAL", typeof(decimal));
    
            var d1Parameter = d1 != null ?
                new ObjectParameter("d1", d1) :
                new ObjectParameter("d1", typeof(string));
    
            var d2Parameter = d2.HasValue ?
                new ObjectParameter("d2", d2) :
                new ObjectParameter("d2", typeof(System.DateTime));
    
            var d3Parameter = d3 != null ?
                new ObjectParameter("d3", d3) :
                new ObjectParameter("d3", typeof(string));
    
            var d4Parameter = d4 != null ?
                new ObjectParameter("d4", d4) :
                new ObjectParameter("d4", typeof(string));
    
            var d5Parameter = d5 != null ?
                new ObjectParameter("d5", d5) :
                new ObjectParameter("d5", typeof(string));
    
            var tICKETNOParameter = tICKETNO != null ?
                new ObjectParameter("TICKETNO", tICKETNO) :
                new ObjectParameter("TICKETNO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertUpdateGrandTotal", bALANCETOTALParameter, d1Parameter, d2Parameter, d3Parameter, d4Parameter, d5Parameter, tICKETNOParameter);
        }
    
        public virtual int SpInsertUpdateGrandTotalTemp(Nullable<int> id, Nullable<decimal> bALANCETOTAL, string d1, Nullable<System.DateTime> d2, string d3, string d4, string d5, string tICKETNO)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var bALANCETOTALParameter = bALANCETOTAL.HasValue ?
                new ObjectParameter("BALANCETOTAL", bALANCETOTAL) :
                new ObjectParameter("BALANCETOTAL", typeof(decimal));
    
            var d1Parameter = d1 != null ?
                new ObjectParameter("d1", d1) :
                new ObjectParameter("d1", typeof(string));
    
            var d2Parameter = d2.HasValue ?
                new ObjectParameter("d2", d2) :
                new ObjectParameter("d2", typeof(System.DateTime));
    
            var d3Parameter = d3 != null ?
                new ObjectParameter("d3", d3) :
                new ObjectParameter("d3", typeof(string));
    
            var d4Parameter = d4 != null ?
                new ObjectParameter("d4", d4) :
                new ObjectParameter("d4", typeof(string));
    
            var d5Parameter = d5 != null ?
                new ObjectParameter("d5", d5) :
                new ObjectParameter("d5", typeof(string));
    
            var tICKETNOParameter = tICKETNO != null ?
                new ObjectParameter("TICKETNO", tICKETNO) :
                new ObjectParameter("TICKETNO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertUpdateGrandTotalTemp", idParameter, bALANCETOTALParameter, d1Parameter, d2Parameter, d3Parameter, d4Parameter, d5Parameter, tICKETNOParameter);
        }
    }
}
