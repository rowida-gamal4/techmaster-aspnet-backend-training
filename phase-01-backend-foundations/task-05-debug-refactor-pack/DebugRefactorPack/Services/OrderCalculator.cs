using DebugRefactorPack.Models;

namespace DebugRefactorPack.Services
{
    public class OrderCalculator
    {
        private const decimal SilverDiscountRate = 0.05M;
        private const decimal GoldDiscountRate = 0.10m;
        private const decimal VipDiscountRate = 0.15m;
        private const decimal TaxRate = 0.14m;
        private const decimal ShippingCost = 50;
        private const decimal FreeShippingLimit = 1000;
        public decimal CalculateSubtotal(decimal price, int quantity)
        {
            decimal total = price * quantity;
            return total;
        }

        public decimal CalculateDiscount(CustomerType customerType, decimal total)
        {
            decimal discount = 0;
            if (customerType == CustomerType.Regular)
            {
                discount = 0;
            }
            else if (customerType == CustomerType.Silver)
            {
                discount = total * SilverDiscountRate;
            }
            else if (customerType == CustomerType.Gold)
            {
                discount = total * GoldDiscountRate;
            }
            else if (customerType == CustomerType.VIP)
            {
                discount = total * VipDiscountRate;
            }
            return discount;
        }

        public decimal CalculateAfterDiscount(decimal subtotal, decimal discount)
        {
            return subtotal - discount;
        }

        public decimal CalculateTax(decimal afterDiscount)
        {
            decimal tax = afterDiscount * TaxRate;
            return tax;
        }

        public decimal CalculateShipping(decimal afterDiscount)
        {
            if (afterDiscount >= FreeShippingLimit)
                return 0;
            return ShippingCost;
        }

        public decimal CalculateFinalTotal(decimal afterDiscount, decimal tax, decimal shiiping)
        {
            decimal final = afterDiscount + tax + shiiping;
            return final;
        }
    }
}