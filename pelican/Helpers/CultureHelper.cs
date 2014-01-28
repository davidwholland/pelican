using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Pelican.Helpers
{
    public static class CultureHelper
    {
        // valid cultures
        private static readonly List<string> _validCultures = new List<string> { "en-GB", "en-AU" };
        private static readonly List<string> _cultures = new List<string>
        {
            "en-US", // first culture is the DEFAULT
            "es"     // Spanish neutral culture      
        };

        public static string GetImplementedCulture(string name)
        {            
            // return default if null
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture();

            // verify valid culture
            if (_validCultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() == 0)
                return GetDefaultCulture();

            // if implemented, accept it
            if (_cultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                return name;

            // find a close match
            // e.g. if "en-US" is defined and user requests "en-GB", return with "en-US"
            var n = GetNeutralCulture(name);
            foreach (var c in _cultures)
            {
                if (c.StartsWith(n))
                {
                    return c;
                }
            }

            return GetDefaultCulture();
        }        

        public static string GetDefaultCulture()
        {
            return _cultures[0]; // return default culture
        }

        public static string GetCurrentCulture(string name)
        {
            return Thread.CurrentThread.CurrentCulture.Name;            
        }

        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        public static string GetNeutralCulture(string name)
        {
            if (name.Length < 2)
            {
                return name;
            }

            return name.Substring(0, 2); // read first two chars only (e.g. "en", "es")
        }
    }
}