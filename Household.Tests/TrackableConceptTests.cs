using Household.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Household.Tests
{
    [TestClass]
    public class TrackableConceptTests
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
            context.Concept.AddProperty();
        }

        [TestMethod]
        public void OnCreatedItHasAnInstance()
        {
            var foo = new TrackableConcept();
            Assert.IsNotNull(foo.CurrentInstance);
            Assert.IsNotNull(foo.Instances);
            Assert.IsFalse(foo.Instances.Count == 0);
        }

        [TestMethod]
        public void OnCreateNewInstanceUseSameSchema()
        {
            var foo = new TrackableConcept();
            var firstInstance = foo.CurrentInstance;
            var schema = foo.CurrentInstance.Properties;

            foo.NewInstance();
            Assert.AreNotEqual(firstInstance, foo.CurrentInstance);
            Assert.AreEqual(schema, foo.CurrentInstance.Properties);
        }

        [TestMethod]
        public void EachTrackableHasADifferentId()
        {
            var foo = new TrackableConcept();
            var bar = new TrackableConcept();
            var iglu = new TrackableConcept();

            Assert.AreNotEqual(foo.Id, bar.Id);
            Assert.AreNotEqual(foo.Id, iglu.Id);
            Assert.AreNotEqual(iglu.Id, bar.Id);
        }
    }
}
