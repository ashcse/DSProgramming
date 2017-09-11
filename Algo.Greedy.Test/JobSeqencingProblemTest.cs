using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Greedy.Test
{
    [TestClass]
    public class JobSeqencingProblemTest
    {
        [TestMethod]
        public void JobSeqencingProblemTester()
        {
            Job[] jobs = new Job[5];
            jobs[0] = new Job { Deadline = 2, Name = "a", Profit = 100 };
            jobs[1] = new Job { Deadline = 1, Name = "b", Profit = 19 };
            jobs[2] = new Job { Deadline = 2, Name = "c", Profit = 27 };
            jobs[3] = new Job { Deadline = 1, Name = "d", Profit = 25 };
            jobs[4] = new Job { Deadline = 3, Name = "e", Profit = 15 };

            JobSeqencingProblem.FindJobSequence(jobs);
        }
    }
}
