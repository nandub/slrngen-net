using System;
using Xunit;
using static Hellosaint.SLRN.SLRNGenerator;

namespace Hellosaint.SLRN.Tests
{
    public class SLRNGeneratorTests
    {
        [Fact]
        public void TestCreateSLRN() 
        {
            String slrn = CreateSLRN();
            bool valid = VerifySLRN(slrn);
            Assert.True(valid);
            Console.WriteLine("Create: " + slrn + " is valid: " + valid);
        }

        [Fact]
        public void TestVerifySLRN() 
        {
            bool valid = VerifySLRN("123-456-781");
            Assert.True(valid);
            Console.WriteLine("Verify: 123-456-781 is valid: " + valid);
        }
    }
}
