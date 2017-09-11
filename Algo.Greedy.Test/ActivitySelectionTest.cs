using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Greedy.Test
{
    [TestClass]
    public class ActivitySelectionTest
    {
        [TestMethod]
        public void ActivitySelectionTester()
        {
            int[] startArr = new int[] {   0,1, 5,3, 8, 5 };
            int[] finishArr = new int[] {   6,2, 7,4, 9, 9 };
             
            ActivitySelection.FindMaxActivities(startArr, finishArr);
        }
    }
}
