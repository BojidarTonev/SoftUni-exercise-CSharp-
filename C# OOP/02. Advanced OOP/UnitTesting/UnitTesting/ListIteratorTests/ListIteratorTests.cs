using System;
using System.Linq;
using System.Reflection;
using ListIterrator;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ListIteratorTests
{
    [TestFixture]
    public class ListIteratorTests
    {
        [Test]
        public void TestMoveNextMethod()
        {
            var ListIterator = new ListIterator("kris", "bojo");

            int index = (int)typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int)).GetValue(ListIterator);

            ListIterator.MoveNext();

            int indexTwo = (int)typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(int)).GetValue(ListIterator);

            Assert.That(index == indexTwo - 1);
        }

        [Test]
        public void TestNullValueConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null, "kris"));
        }
    }
}
