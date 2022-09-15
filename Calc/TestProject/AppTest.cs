using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcProject.App;
using System;

namespace TestProject
{
    
    [TestClass]
    public class AppTest
    {
        public Resources resources = new Resources();

        public AppTest()
        {
            RomanNumber.Resources = resources;
        }

        [TestMethod]
        public void TestCalc()
        {
            CalcProject.App.Calc calc = new(resources);
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
            Assert.AreEqual(Resources.NotExistMessage('0'),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("0")
                ).Message);

            Assert.AreEqual(Resources.NotExistMessage('G'),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("G")
                ).Message);

            Assert.AreEqual(Resources.NotExistMessage('¯'),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("¯")
                ).Message);

            Assert.AreEqual(Resources.NotExistMessage('%'),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("%")
                ).Message);

            Assert.AreEqual(Resources.NotExistMessage('@'),
                Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("@")
                ).Message);
        }

        [TestMethod]
        public void RomanNumberInvalidNumber()
        {
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("XIX1")
                ).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA(" XX")
                ).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("X X")
                ).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("cxx")
                ).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));

            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.RTOA("hello")
                ).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));
        }

        [TestMethod]
        public void RomanNumberCtor()
        {
            RomanNumber number;
            number = new RomanNumber(10);
            Assert.IsNotNull(number);
            number = new RomanNumber(0);
            Assert.IsNotNull(number);
        }

        [TestMethod]
        public void RomanNumberToString()
        {
            RomanNumber number;
            number = new RomanNumber(10);
            Assert.AreEqual("X", number.ToString());
            number = new RomanNumber(0);
            Assert.AreEqual("N", number.ToString());
            Assert.AreEqual("XXX", new RomanNumber(30).ToString());
            Assert.AreEqual("CM", new RomanNumber(900).ToString());
            Assert.AreEqual("MCMXCIX", new RomanNumber(1999).ToString());
            Assert.AreEqual("CD", new RomanNumber(400).ToString());
        }

        [TestMethod]
        public void RomanNumberParseToStringCrossTest()
        {
            RomanNumber number = new RomanNumber(1);
            for (int i = 1; i <= 2000; i++)
            {
                number.val = i;
                Assert.IsTrue(RomanNumber.RTOA(number.ToString()) == i);
            }
        }

        [TestMethod]
        public void RomanNumberClonesTest()
        {
            RomanNumber n1 = new(10);
            RomanNumber n2 = n1;
            Assert.AreSame(n1, n2);
            RomanNumber n3 = n1 with { val = 3 };
            Assert.AreNotSame(n3, n1);
            RomanNumber n4 = n1 with {};
            Assert.AreNotSame(n4, n1);
            Assert.AreEqual(n4, n1);

        }

        [TestMethod]
        public void RomanNumberAdd()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            Assert.AreEqual(5, n2.Add(n3).val);
            Assert.AreEqual(n5, n2.Add(n3));

        }

        [TestMethod]
        public void RomanNumberTest1()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            Assert.AreEqual("V", n2.Add(n3).ToString());
            n2.val = -(n2.val);
            n3.val = -(n3.val);
            n5.val = -(n5.val);
            RomanNumber n0 = new(0);
            RomanNumber n2_1 = new(-2);
            Assert.AreEqual("-V", n2.Add(n3).ToString());
            Assert.AreEqual(-5, n2.Add(n3).val);
            Assert.AreEqual(n5, n2.Add(n3));
            Assert.AreEqual("-II", n2.Add(n0).ToString());
            Assert.AreEqual(-2, n2.Add(n0).val);
            Assert.AreEqual(n2_1, n2.Add(n0));
            Assert.AreEqual(-4, n2.Add(n2).val);
            Assert.AreEqual(0, n2.Add(new RomanNumber(2)).val);
            var m = Assert.ThrowsException<ArgumentNullException>(
                    () => n2.Add((RomanNumber)null)
                ).Message;
            Assert.IsTrue(m.Contains(Resources.NullNumberMessage()));
        }

        [TestMethod]
        public void RomanNumberIntTest()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            RomanNumber n5_1 = new(5);
            Assert.AreEqual(n3, n2.Add(1));
            Assert.AreEqual(n3, n5.Add(-2));
            Assert.AreEqual(n5, n2.Add(3));
            Assert.AreEqual(n5_1, n5.Add(0));
        }

        [TestMethod]
        public void AddStringTest()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            RomanNumber n5_1 = new(5);
            RomanNumber n0 = new(0);
            Assert.AreEqual(n3, n2.Add("I"));
            Assert.AreEqual(n3, n5.Add("-II"));
            Assert.AreEqual(n5, n2.Add("III"));
            Assert.AreEqual(n5_1, n5.Add("N"));
            Assert.AreEqual(n5_1, n0.Add("V"));
            var m = Assert.ThrowsException<ArgumentNullException>(
                    () => n2.Add((null as String)!)
                ).Message;
            Assert.IsTrue(m.Contains(Resources.NullNumberMessage()) 
                || m.Contains(Resources.NullStringMessage()));
        } //doesn't exists

        [TestMethod]
        public void RomanNumberInvalidAdd()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => n2.Add("XR")).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => n2.Add("X-V")).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => n2.Add("IV ")).Message.EndsWith(Resources.NotExistMessage(' ')[^2..14]));
        }

        [TestMethod]
        public void AddStaticTest()
        {
            RomanNumber rn5 = RomanNumber.Add(2, 3);
            RomanNumber rn8 = RomanNumber.Add(rn5, 3);
            RomanNumber rn10 = RomanNumber.Add("I", "IX");
            RomanNumber rn9 = RomanNumber.Add(rn5, "IV");
            RomanNumber rn13 = RomanNumber.Add(rn5, rn8);
        }

        [TestMethod]
        public void ObjectToRNTest()
        {
            RomanNumber n2 = new(2);
            RomanNumber n3 = new(3);
            RomanNumber n5 = new(5);
            Assert.ThrowsException<ArgumentNullException>(
                    () => RomanNumber.Add(null as object, null as object));
            Assert.AreEqual(n5, RomanNumber.Add(n2 as object, n3 as object));
            Assert.AreEqual(n5, RomanNumber.Add(2 as object, 3 as object));
            Assert.AreEqual(n5, RomanNumber.Add("II" as object, "III" as object));
            Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                    () => RomanNumber.Add(52.36 as object, 2.45 as object)
                ).Message.StartsWith(Resources.InvalidArgumentMessage(n5.GetType())[..21]));
        }
    }
}
