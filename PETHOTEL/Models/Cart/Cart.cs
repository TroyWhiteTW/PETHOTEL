using PETHOTEL.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PETHOTEL.Models.Cart
{
    [Serializable] //可序列化
    public class Cart : IEnumerable<CartItem> //購物車類別
    {
        //建構值
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        //儲存所有商品
        private List<CartItem> cartItems;

        /// <summary>
        /// 取得購物車內商品的總數量
        /// </summary>
        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        //取得商品總價
        public Nullable<decimal> TotalAmount
        {
            get
            {
                Nullable<decimal> totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }

        //新增一筆Product，使用ProductId
        public bool AddProducts(int id)
        {
            var findItem = this.cartItems
                            .Where(s => s.Id == id)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Cart.CartItem))
            {   //不存在購物車內，則新增一筆
                using (Entities db = new Entities())
                {
                    
                    var pro = (from s in db.Product
                                   where s.p_id == id
                                   select s).FirstOrDefault();
                    if (pro != default(entity.Product))
                    {
                        this.AddProduct(pro);
                    }
                }
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += 1;
            }
            return true;
        }

        //新增一筆Product，使用Product物件
        private bool AddProduct(Product product)
        {
            //將Product轉為CartItem
            var cartItem = new CartItem()
            {
                Id = product.p_id,
                Name = product.p_name,
                Price = product.p_price,
                DefaultImageURL = product.p_image,
                Quantity = 1
            };

            //加入CartItem至購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        //移除一筆Product，使用ProductId
        public bool RemoveProduct(int id)
        {
            var findItem = this.cartItems
                            .Where(s => s.Id == id)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Cart.CartItem))
            {
                //不存在購物車內，不需做任何動作
            }
            else
            {   //存在購物車內，將商品移除
                this.cartItems.Remove(findItem);
            }
            return true;
        }

        //清空購物車
        public bool ClearCart()
        {
            this.cartItems.Clear();
            return true;
        }

        //將購物車商品轉成OrderDetail的List
        public List<entity.Order> ToOrderDetailList(int orderId)
        {
            var result = new List<Order>();
            foreach (var cartItem in this.cartItems)
            {
                result.Add(new Order()
                {
                    o_pet_name = cartItem.Name,
                    o_pet_price = cartItem.Price,
                  
                    o_id = orderId
                });
            }
            return result;
        }


        #region IEnumerator

        IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        #endregion
    }
}