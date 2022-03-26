using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace Tests.IntegrationTests
{
    public class IntegrationTestPrototype : ZenjectIntegrationTestFixture
    {
        // A Test behaves as an ordinary method
        [Test]
        public void IntegrationTestBaseSimplePasses()
        {
            PreInstall();
            //work with Container
            //...
            PostInstall();
            // Use the Assert class to test conditions
            Debug.Log("IntegrationTestBaseSimplePasses");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator IntegrationTestBaseWithEnumeratorPasses()
        {
            PreInstall();
            //work with Container
            //...
            PostInstall();
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            Debug.Log("IntegrationTestBaseWithEnumeratorPasses before");
            yield return null;
            Debug.Log("IntegrationTestBaseWithEnumeratorPasses after");
        }
    }
}
