using pethotel_manager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pethotel_manager.Models
{
    public class InvoiceViewModel
    {

        public int i_id { get; set; }
        public int? c_id { get; set; }
        public int? i_status { get; set; }
        public int? i_send { get; set; }
        public Customer cus {
            get {
                Entities en = new Entities();
                Customer item = new Customer();
                item = en.Customer.SingleOrDefault(a => a.c_id == c_id);
                return item;

            }
        }

        public InvoiceViewModel getone(int id)
        {
            Entities en = new Entities();
            var item = en.Invoice.SingleOrDefault(a => a.i_id == id);

            this.i_id = item.i_id;
            this.c_id = item.c_id;
            this.i_status = item.i_status;
            this.i_send = item.i_send;

            return this;
        }
        private void maping(Invoice item)
        {

            this.c_id = item.c_id;
            this.i_id = item.i_id;
            this.i_send = item.i_send;
            this.i_status = item.i_status;


        }

        public List<InvoiceViewModel> getlist()
        {
            Entities en = new Entities();
            List<InvoiceViewModel> list = new List<InvoiceViewModel>();

            foreach (var item in en.Invoice.ToList())
            {

                InvoiceViewModel vm = new InvoiceViewModel();
                vm.maping(item);
                list.Add(vm);

            }
            return list;
        }

        public void create()
        {
            Entities en = new Entities();
            Invoice item = new Invoice();
            item.c_id = this.c_id;
            item.i_send = this.i_send;
            item.i_status = this.i_status;

            en.Invoice.Add(item);
            en.SaveChanges();


        }
        public void update()
        {
            Entities en = new Entities();
            var item = en.Invoice.SingleOrDefault(a => a.i_id == this.i_id);


            item.c_id = this.c_id;
            item.i_send = this.i_send;
            item.i_status = this.i_status;

            en.Entry(item).State = System.Data.Entity.EntityState.Modified;
            en.SaveChanges();


        }

        public List<Invoice_DetailViewModel> Invoice_DetailList {
            get {
                Entities en = new Entities();
                List<Invoice_DetailViewModel> VMlist = new List<Invoice_DetailViewModel>();

                var list = en.Invoice_Detail.Where(a => a.i_id == i_id);

                foreach (var item in list)
                {

                    Invoice_DetailViewModel VM = new Invoice_DetailViewModel();
                    VM.getone(item.id_id);
                    VMlist.Add(VM);
                }
                return VMlist;
            }
        }





    }
}