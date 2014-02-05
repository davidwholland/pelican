using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Pelican.Helpers;

namespace Pelican.Tests
{
    public class GivenACultureHelper
    {
        [Fact]
        public void WhenGetImplementedCultureIsCalledFor_en()
        {
            var implementedCulture = CultureHelper.GetImplementedCulture("en");
            Assert.Equal("en-US", implementedCulture);
        }

        [Fact]
        public void WhenGetImplementedCultureIsCalledFor_fr()
        {
            var implementedCulture = CultureHelper.GetImplementedCulture("fr");
            Assert.Equal("en-US", implementedCulture);
        }

        [Fact]
        public void WhenGetImplementedCultureIsCalledWithEmptyString()
        {
            var implementedCulture = CultureHelper.GetImplementedCulture("");
            Assert.Equal("en-US", implementedCulture);
        }
    }
}
