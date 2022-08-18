using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models.RoomTools
{
    public class Cart

    {
        //List<CartItem> _myCart = new List<CartItem>();
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();
        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID))
            {
                _myCart[cartItem.ID].Quantity += cartItem.Quantity;
                return;

            }
            _myCart.Add(cartItem.ID, cartItem);
        }
    }
}