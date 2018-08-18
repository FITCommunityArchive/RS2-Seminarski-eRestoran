using eRestoran.PCL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eRestoran.Client.Mobile.Helpers
{
    public static class CartHelper
    {
        public static CartIndexVM cart
        {
            get
            {
                return ApplicationProperties.cart;
            }
            set
            {
                ApplicationProperties.cart = value;
            }
        }
        public static bool AddToCartPice(CartRow cartRow)
        {
            CartExists();
            if (cart.Pica.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                var staraKolicina = cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina;
                cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina = cartRow.Kolicina;
                cart.Pica.SingleOrDefault(x => x.Id == cartRow.Id).TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice -= cartRow.Cijena * staraKolicina;
                //label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }
            else
            {
                CartRow pice = new CartRow();
                pice.Id = cartRow.Id;
                pice.Kolicina = cartRow.Kolicina;
                pice.Naziv = cartRow.Naziv;
                pice.Cijena = cartRow.Cijena;
                pice.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.Pica.Add(pice);
                pice.Kategorija = cartRow.Kategorija;
                pice.StanjeKolicina = cartRow.StanjeKolicina;
                pice.Imageurl = cartRow.Imageurl;
                cart.TotalPrice += pice.TotalRowPrice;
                //label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }

            //SetBtnOdaberiStoVisibility();
            return true;
            //fali dio sa stanjem,da li ima stavke na stanju , treba uraditi poziv prema API
        }
        public static bool AddToCartJelo(CartRow cartRow)
        {
            if (cart.Jela.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                var staraKolicina = cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina;
                cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).Kolicina = cartRow.Kolicina;
                cart.Jela.SingleOrDefault(x => x.Id == cartRow.Id).TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice -= cartRow.Cijena * staraKolicina;
                // label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }
            else
            {
                CartRow jelo = new CartRow();
                jelo.Id = cartRow.Id;
                jelo.Kolicina = cartRow.Kolicina;
                jelo.Naziv = cartRow.Naziv;
                jelo.Kategorija = cartRow.Kategorija;
                jelo.Imageurl = cartRow.Imageurl;
                jelo.Cijena = cartRow.Cijena;
                jelo.StanjeKolicina = 0;
                jelo.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.Jela.Add(jelo);
                cart.TotalPrice += jelo.TotalRowPrice;
                //label4.Text = Math.Round(cart.TotalPrice, 2).ToString() + " KM";
            }

            //SetBtnOdaberiStoVisibility();
            return true;
        }

        public static CartIndexVM GetCartForCheckout()
        {
            var checkoutCart = cart;
            ClearCart();
            return checkoutCart;
        }

        public static int CartRowExists(int? id)
        {
            if (cart.Pica.SingleOrDefault(x => x.Id == id) != null)
            {
                return cart.Pica.SingleOrDefault(x => x.Id == id).Kolicina;
            }
            if (cart.Jela.SingleOrDefault(x => x.Id == id) != null)
            {
                return cart.Jela.SingleOrDefault(x => x.Id == id).Kolicina;
            }
            return 0;
        }

        public static bool CartExists()
        {
            if (cart != null)
            {
                return true;
            }
            else
            {
                cart = new CartIndexVM();
                cart.Jela = new List<CartRow>();
                cart.Pica = new List<CartRow>();
                cart.TotalPrice = 0;
                return false;
            }

        }
        public static List<CartRow> GetCartItems()
        {
            List<CartRow> SveStavkeKorpe = new List<CartRow>();
            SveStavkeKorpe.AddRange(cart.Jela.Where(x => x.Kolicina > 0));
            SveStavkeKorpe.AddRange(cart.Pica.Where(x => x.Kolicina > 0));
            return SveStavkeKorpe;

        }
        public static double GetTotalPrice()
        {
            return cart.TotalPrice;
        }
        public static void ClearCart()
        {
            cart = new CartIndexVM();
            cart.Jela = new List<CartRow>();
            cart.Pica = new List<CartRow>();
            cart.TotalPrice = 0;
            //label4.Text = "0";
        }
    }
}
