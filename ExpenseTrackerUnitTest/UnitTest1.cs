using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseTrackerUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private int Actual;

        [TestMethod]
        public void validInputtest()
        {
            UnitTest1 test = new UnitTest1();
            int Actual = 1;

            if (Actual > 0) ;
            Assert.AreEqual(1, Actual);

        }
        [TestMethod]
         public void InvalidInputtest()
        {
            UnitTest1 test = new UnitTest1();
            int Actual = -1;

            if (Actual<0) ;
            Assert.AreEqual(-1, Actual);
        }

        [TestMethod]
        public void NoInputtest()
        {
            UnitTest1 test = new UnitTest1();
            int Actual = null;

            if (Actual != null) ;
            Assert.IsNotNull(null,Actual);

        }

        [TestMethod]
        public void Specialinputtest()
        {
            UnitTest1 test = new UnitTest1();
            string Actual = "#";

            if (Actual != "#") ;
            Assert.AreEqual(null, Actual);

        }

        [TestMethod]
        public void NovalueDropdowntest()
        {
            UnitTest1 test = new UnitTest1();
            string Actual = "#";

            if (Actual != "#") ;
            Assert.AreEqual(null, Actual);

        }






    }
}
