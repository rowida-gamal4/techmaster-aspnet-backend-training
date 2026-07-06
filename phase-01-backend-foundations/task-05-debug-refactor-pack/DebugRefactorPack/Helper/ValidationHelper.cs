using DebugRefactorPack.Models;

namespace DebugRefactorPack.Helper
{
    public class ValidationHelper
    {
        public bool ValidatePrice(decimal price)
        {
           if(price <= 0)
            {
               return false ; 
            }
            return true ;     
        }
         public bool ValidateQuantity(int quantity)
        {
           if(quantity <= 0)
            {             
               return false ; 
            }
            return true ;     
        }
         public bool ValidateName(string name)
        {
           if(string.IsNullOrWhiteSpace(name))
            {            
               return false ; 
            }
            return true ;     
        }
        public bool ValidateCustomerType(string type)
        {
            bool isValid = Enum.TryParse<CustomerType>(type, true, out _);

            return isValid;   
        }

    }
}