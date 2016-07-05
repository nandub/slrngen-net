﻿#region License
// Copyright (c) 2016 Fernando Ortiz
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

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
