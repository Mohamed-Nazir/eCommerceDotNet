using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace EhodVenteEnLigne.Resources.Models
{

    public class Order
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
                    ResourceManager temp = new ResourceManager("EhodVenteEnLigne.Resources.Models.Order", typeof(Order).Assembly);
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

        public static string ErrorMissingAddress
        {
            get { return ResourceManager.GetString("ErrorMissingAddress", resourceCulture); }
        }

        public static string ErrorMissingCity
        {
            get { return ResourceManager.GetString("ErrorMissingCity", resourceCulture); }
        }

        public static string ErrorMissingCountry
        {
            get { return ResourceManager.GetString("ErrorMissingCountry", resourceCulture); }
        }

        public static string ErrorMissingName
        {
            get { return ResourceManager.GetString("ErrorMissingName", resourceCulture); }
        }

        public static string ErrorMissingZipCode
        {
            get { return ResourceManager.GetString("ErrorMissingZipCode", resourceCulture); }
        }
    }

}