using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace EhodVenteEnLigne.Resources.Models
{

    public class Product
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    ResourceManager temp = new ResourceManager("EhodVenteEnLigne.Resources.Models.Product", typeof(Product).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture
        {
            get { return resourceCulture; }
            set { resourceCulture = value; }
        }

        public static string MissingName
        {
            get { return ResourceManager.GetString("MissingName", resourceCulture); }
        }

        public static string MissingQuantity
        {
            get { return ResourceManager.GetString("MissingQuantity", resourceCulture); }
        }

        public static string MissingPrice
        {
            get { return ResourceManager.GetString("MissingPrice", resourceCulture); }
        }

        public static string StockNotAnInteger
        {
            get { return ResourceManager.GetString("StockNotAnInteger", resourceCulture); }
        }

        public static string PriceNotANumber
        {
            get { return ResourceManager.GetString("PriceNotANumber", resourceCulture); }
        }

        public static string PriceNotGreaterThanZero
        {
            get { return ResourceManager.GetString("PriceNotGreaterThanZero", resourceCulture); }
        }
    }

}