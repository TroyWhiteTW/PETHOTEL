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

        public string i_status_string {
            get {
                if (i_status == 1)
                {
                    return "已付款";
                }
                else
                {
                    return "未付款";
                }                
            }
        }

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

        public List<InvoiceViewModelOutPut> InvoiceViewModelOutPutList {

            get {
                List<InvoiceViewModelOutPut> L = new List<InvoiceViewModelOutPut>();
                foreach (var item in Invoice_DetailList)
                {
                    if (L.Where(a => a.p_id == item.porduct.p_id).Count() > 0)
                    {
                        
                        L.SingleOrDefault(a => a.p_id == item.porduct.p_id).count++;

                    }
                    else
                    {
                        InvoiceViewModelOutPut VMOP = new InvoiceViewModelOutPut();
                        VMOP.img = item.porduct.p_image;
                        VMOP.count = 1;
                        VMOP.name = item.porduct.p_name;
                        VMOP.p_id = item.porduct.p_id;
                        VMOP.type = item.porduct.p_type;
                        VMOP.price = item.porduct.p_price;
                        L.Add(VMOP);
                    }
                }
                return L;
            }
        }


        public class InvoiceViewModelOutPut
        {
            public int p_id { get; set; }
            public string img { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public decimal? price { get; set; }
            public decimal? total { get {
                    
                    return count * price;
                } }


            public int? type { get; set; }
            public string type_string {
                get {

                    string S = "";
                    switch (type)
                    {

                        case 0:
                            S = "零食";
                            break;
                        case 1:
                            S = "罐頭";
                            break;
                        case 2:
                            S = "貓砂";
                            break;
                        case 3:
                            S = "貓砂";
                            break;
                        case 4:
                            S = "貓砂";
                            break;
                    }

                    return S;
                }
            }
   
        }




    }
}