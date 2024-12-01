using System;

namespace Solid4
{
    interface IPricable
    {
        void SetPrice(double price);
    }

    interface IDiscountable
    {
        void ApplyDiscount(string discount);
        void ApplyPromocode(string promocode);
    }

    interface IPhysicalProduct
    {
        void SetColor(string color);
        void SetSize(int size);
    }

    class Book : IPricable, IDiscountable
    {
        private double Price { get; set; }
        private string Discount { get; set; }
        private string Promocode { get; set; }

        public void SetPrice(double price)
        {
            Price = price;
            Console.WriteLine($"Price of the book set to: {Price}");
        }

        public void ApplyDiscount(string discount)
        {
            Discount = discount;
            Console.WriteLine($"Discount applied to book: {Discount}");
        }

        public void ApplyPromocode(string promocode)
        {
            Promocode = promocode;
            Console.WriteLine($"Promocode applied to book: {Promocode}");
        }
    }


    class Outerwear : IPricable, IDiscountable, IPhysicalProduct
    {
        private double Price { get; set; }
        private string Discount { get; set; }
        private string Promocode { get; set; }
        private string Color { get; set; }
        private int Size { get; set; }

        public void SetPrice(double price)
        {
            Price = price;
            Console.WriteLine($"Price of the outerwear set to: {Price}");
        }

        public void ApplyDiscount(string discount)
        {
            Discount = discount;
            Console.WriteLine($"Discount applied to outerwear: {Discount}");
        }

        public void ApplyPromocode(string promocode)
        {
            Promocode = promocode;
            Console.WriteLine($"Promocode applied to outerwear: {Promocode}");
        }

        public void SetColor(string color)
        {
            Color = color;
            Console.WriteLine($"Color of the outerwear set to: {Color}");
        }

        public void SetSize(int size)
        {
            Size = size;
            Console.WriteLine($"Size of the outerwear set to: {Size}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.SetPrice(200.0);
            book.ApplyDiscount("10%");
            book.ApplyPromocode("BOOK10");

            Console.WriteLine();

            var outerwear = new Outerwear();
            outerwear.SetPrice(1500.0);
            outerwear.SetColor("blue"); 
            outerwear.SetSize(36); 
            outerwear.ApplyDiscount("20%");
            outerwear.ApplyPromocode("OUTFIT20");

            Console.ReadKey();
        }
    }
}
