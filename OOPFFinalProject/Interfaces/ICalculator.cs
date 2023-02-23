using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Interfaces
{
    public interface ICalculator
    {
        Category CalculateCategory(bool horrorFlag, bool fictionFlag, bool romanceFlag, bool kitchenFlag);
        double CalculateDiscount(string AuthorDiscount, string PublisherDiscount);
    }
}
