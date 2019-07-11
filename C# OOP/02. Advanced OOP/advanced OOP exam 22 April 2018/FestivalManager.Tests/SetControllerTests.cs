// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)


using FestivalManager.Core.Controllers;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities;


namespace FestivalManager.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private SetController setController;

        [SetUp]
        public void TestInit()
        {
        }

        [Test]
        public void TestIfSetCountIncreases()
        {
            //Act
            Stage stage = new Stage();
            ISong song = new Song("Ledena kralica", new TimeSpan(0, 5, 0));
            stage.AddSong(song);
            this.setController = new SetController(stage);
            int firstSetCound = 1;

            setController.PerformSets();

            MethodInfo method = typeof(SetController).GetMethods(BindingFlags.Public)
                .First(m => m.Name == "PerformSets");
            string methodReturnType = method.ReturnType.ToString();

            Assert.AreEqual(methodReturnType, "System.String");
        }

        [Test]
        public void TestConstructor()
        {
            Stage stage = new Stage();
            ISong song = new Song("Ledena kralica", new TimeSpan(0, 5, 0));
            stage.AddSong(song);
            SetController setController = new SetController(stage);

            FieldInfo field = typeof(SetController).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(fi => fi.FieldType == typeof(IStage));

            Assert.AreNotEqual(field, null);
        }
    }
}