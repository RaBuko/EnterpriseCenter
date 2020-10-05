using EnterpriseCenterApp.Algos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WebApiTester
{
    public class MagicSquareTests
    {
        [Fact]
        public void TestCheckIfMagicTrue()
        {
            MagicSquare magicSquare = new MagicSquare(
                8, 3, 4,
                1, 5, 9,
                6, 7, 2);

            Assert.True(magicSquare.IsMagic());
        }
    }
}
