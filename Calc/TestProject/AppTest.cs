using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcProject.App;
using System;

namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void TestCalc()
        {
            CalcProject.App.Calc calc = new();
            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.RTOA("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.RTOA("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.RTOA("XV"), 15);
            Assert.AreEqual(RomanNumber.RTOA("XXX"), 30);
            Assert.AreEqual(RomanNumber.RTOA("CM"), 900);
            Assert.AreEqual(RomanNumber.RTOA("MCMXCIX"), 1999);
            Assert.AreEqual(RomanNumber.RTOA("CD"), 400);
            Assert.AreEqual(RomanNumber.RTOA("CDI"), 401);
            Assert.AreEqual(RomanNumber.RTOA("LV"), 55);
            Assert.AreEqual(RomanNumber.RTOA("XL"), 40);
        }

        [TestMethod]
        public void RomanNumberInvalidDigit()
        {
            Assert.AreEqual("0 doesn't exists",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("0")
                ).Message);

            Assert.AreEqual("G doesn't exists",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("G")
                ).Message);

            Assert.AreEqual("¯ doesn't exists",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("¯")
                ).Message);

            Assert.AreEqual("% doesn't exists",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("%")
                ).Message);

            Assert.AreEqual("@ doesn't exists",
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("@")
                ).Message);
        }

        [TestMethod]
        public void RomanNumberInvalidNumber()
        {
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("XIX1")
                ).Message.EndsWith("doesn't exists"));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA(" XX")
                ).Message.EndsWith("doesn't exists"));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("X X")
                ).Message.EndsWith("doesn't exists"));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("cxx")
                ).Message.EndsWith("doesn't exists"));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("hello")
                ).Message.EndsWith("doesn't exists"));
        }

        [TestMethod]
        public void RomanNumberZero()
        {
            Assert.AreEqual(RomanNumber.RTOA("N"), 0);
        }
    }
}
