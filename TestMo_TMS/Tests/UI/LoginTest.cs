using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Pages;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void SuccessLoginTest()
        {
            LoginPage.TryToLogin(Configurator.Admin);
        }
    }
}
