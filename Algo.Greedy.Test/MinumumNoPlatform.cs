using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Greedy.Test
{
   [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MinumumNoPlatform
    {
        [TestMethod]
        public void TestMinimumNoPlatform()
        {
            int[] arrival = new int[] { 900, 940, 950, 1100, 1500, 1800 };
            int[] depart = new int[] { 910, 1200, 1120, 1130, 1900, 2000 };

            MinimnNoOfPlatform.FindMinumumNoPlatform(arrival, depart);
        }
    }
}
