using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditorUnitTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EditorUnitTestSimplePasses()
        {
            //Arrange
            //var CreateObj = new 
          
         
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EditorUnitTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [TestCase(100, 200, "String")]
        private void Methods()
        {

        }
    }
}
