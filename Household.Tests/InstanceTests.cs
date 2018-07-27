using Household.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Household.Tests
{
    [TestClass]
    public class InstanceTests
    {
        public class Context
        {
            public TrackableConcept Concept { get; set; }

            public static Context Create()
            {
                var context = new Context();
                context.Concept = new TrackableConcept();
                return context;
            }
        }


        [TestMethod]
        public void OnAddPropertyClonesTheSchemaIfItsUsedBySomeoneElse()
        {
            var context = Context.Create();
            var initialInstance = context.Concept.CurrentInstance;
            var initialSchema = initialInstance.Properties;
            context.Concept.NewInstance();
            var newInstance = context.Concept.CurrentInstance;

            context.Concept.AddProperty(); //This is on the new instance
            Assert.AreNotEqual(initialSchema, newInstance.Properties);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
