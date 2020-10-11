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

        [Fact]
        public void TestCheckIfMagicFalse()
        {
            MagicSquare magicSquare = new MagicSquare(
                8, 4, 8,
                1, 7, 4,
                6, 7, 2);

            Assert.False(magicSquare.IsMagic());
        }

        [Fact]
        public void TestMagicSquareSums()
        {
            MagicSquare magicSquare = new MagicSquare(
                1, 2, 3,
                4, 5, 6,
                7, 8, 9);

            var (horzSums, vertSums) = magicSquare.GetSums();

            Assert.Equal(horzSums, new List<int>() { 6, 15, 24 });
            Assert.Equal(vertSums, new List<int>() { 12, 15, 18 });

            magicSquare.AdjustSquareToBeMagic();

            Assert.True(magicSquare.IsMagic());
        }
    }
}
