using OOPFFinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Objects
{
    public class Calculator : ICalculator
    {
        public Category CalculateCategory(bool horrorFlag, bool fictionFlag, bool romanceFlag, bool kitchenFlag)
        {
            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            if (horrorFlag)
            {
                first = 2;
            }
            if (fictionFlag)
            {
                second = 4;
            }
            if (romanceFlag)
            {
                third = 8;
            }
            if (kitchenFlag)
            {
                fourth = 16;
            }
            int sum = first + second + third + fourth;
            Category Categories = (Category)sum;
            return Categories;
        }

        public double CalculateDiscount(string AuthorDiscount, string PublisherDiscount)
        {
            try
            {
                double discountAuthor = double.Parse(AuthorDiscount);
                double discountPublisher = double.Parse(PublisherDiscount);
                double finalMax = Math.Max(discountAuthor, discountPublisher);
                return finalMax;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
