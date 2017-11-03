﻿using NUnit.Framework;

namespace Ethereum.GeneralState.Test
{
    [TestFixture]
    public class CallCodesTests : GeneralTestBase
    {
        [TestCaseSource(nameof(LoadTests), new object[] { "CallCodes" })]
        public void Test(GenerateStateTest generateStateTest)
        {    
            RunTest(generateStateTest);
        }
    }
}