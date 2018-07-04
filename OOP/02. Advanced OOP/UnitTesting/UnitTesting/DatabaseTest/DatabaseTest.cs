using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ListIterrator;
using NUnit.Framework;

namespace DatabaseTest
{
    [TestFixture]
    public class DatabaseTest
    {
        private Person pesho;
        private Person gosho;
        [SetUp]
        public void TestInt()
        {
            pesho = new Person("Pesho", 123);
            gosho = new Person("Gosho", 321);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void CheckConstructor(int[] values)
        {
            Database db = new Database(values);

            FieldInfo field = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(fi => fi.FieldType == typeof(int[]));
            IEnumerable<int> internalArray = ((int[])field.GetValue(db)).Take(values.Length);

            Assert.That(internalArray, Is.EquivalentTo(values));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        public void CheckAddMethod(int value)
        {
            Database db = new Database();

            FieldInfo field = typeof(Database).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(fi => fi.FieldType == typeof(int[]));
            IEnumerable<int> internalArray = (int[])field.GetValue(db);

            db.Add(value);
            IEnumerable<int> changedArray = (int[])field.GetValue(db);

            Assert.That(internalArray, Is.EquivalentTo(changedArray));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        public void CheckIfAddMethodIncreacesIndex(int value)
        {
            Database db = new Database();

            int index = (int)typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int)).GetValue(db);

            db.Add(value);
            int newIndex = (int)typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int)).GetValue(db);

            Assert.IsTrue(index == newIndex - 1);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        public void CheckIfRemoveMethodDecreacesIndex(int value)
        {
            Database db = new Database(new int[] { 1, 2, 3 });

            int index = (int)typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int)).GetValue(db);

            db.Remove();
            int newIndex = (int)typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int)).GetValue(db);

            Assert.IsTrue(index == newIndex + 1);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckIfFetchWorks(int[] values)
        {
            Database db = new Database(values);

            int[] field = (int[])typeof(Database).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int[])).GetValue(db);

            Assert.That(field, Is.EquivalentTo(db.Fetch()));
        }

        [Test]
        public void CheckInvaidConstructor()
        {
            int[] values = new int[17];

            Assert.That(() => new Database(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Stancho")]
        public void TestFindInvalidUsername(string username)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase();

            Assert.Throws<NullReferenceException>(() => extendedDb.FindByUsername(username));
        }

        [Test]
        [TestCase("Prakash")]
        public void TestFindValidUsername(string username)
        {
            ExtendedDatabase exntededDb = new ExtendedDatabase(new Person("Prakash", 1));

            Assert.That(exntededDb.FindByUsername(username) != null);
        }

        [Test]
        [TestCase(null)]
        public void TestNullInput(string username)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase();

            Assert.Throws<NullReferenceException>(() => extendedDb.FindByUsername(username));
        }

        [Test]
        [TestCase(int.MinValue)]
        public void TestFindByIdWithNegativeId(int value)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(value));
        }

        [Test]
        [TestCase(int.MaxValue)]
        public void TestFindWithInvalidId(int value)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase();

            Assert.Throws<NullReferenceException>(() => extendedDb.FindById(value));
        }

        [Test]
        [TestCase(9)]
        public void TestFindByIdWithValidId(int value)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase(new Person("Prakash", 9));

            Assert.That(extendedDb.FindById(value) != null);
        }

        [Test]
        [TestCase("Stoqn", 7)]
        public void TestAddingPersonWithAlreadyExistingId(string name, int id)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase(new Person("Pesho", 7));

            Person person = new Person(name, id);

            Assert.That(() => extendedDb.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Petko", 1)]
        public void TestAddingPersonWithAlreadyExistingName(string name, int id)
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase(new Person("Petko", 2));

            Person person = new Person(name, id);

            Assert.That(() => extendedDb.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void TestIfIndexIncreasesAfterAddingPerson()
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase(pesho);
            FieldInfo indexField = typeof(ExtendedDatabase).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));
            int indexValue = (int)indexField.GetValue(extendedDb);

            extendedDb.Add(gosho);

            int newIndex = (int)indexField.GetValue(extendedDb);

            Assert.That(indexValue == newIndex - 1);
        }

        [Test]
        public void TestRemoveMethodRemovesAtindex()
        {
            ExtendedDatabase extendedDb = new ExtendedDatabase(gosho, pesho);
            FieldInfo indexField = typeof(ExtendedDatabase).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(int));
            int indexValue = (int)indexField.GetValue(extendedDb);

            extendedDb.Remove();

            FieldInfo interArrayField = typeof(ExtendedDatabase)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == typeof(Person[]));
            Person[] copyArray = (Person[])interArrayField.GetValue(extendedDb);

            Assert.That(copyArray[indexValue] == null);
        }




    }
}
