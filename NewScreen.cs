using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    public static class NewScreen
    {
        public static HomeScreen HomeScreen
        {
            get
            {
                var home = new HomeScreen();
                return home;
            }
        }


        public static Calculator Calculator
        {
            get
            {
                var calc = new Calculator();
                return calc;
            }


        }
    }

}