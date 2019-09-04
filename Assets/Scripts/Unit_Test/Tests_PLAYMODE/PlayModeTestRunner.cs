using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine;


namespace Tests
{
    public class PlayModeTestRunner
    {
        

        // A Test behaves as an ordinary method
        /// <summary>
        /// Play Mode test runner Script
        /// </summary>
        /// 
        [Test]
        public void PlayModeTestRunnerSimplePasses()
        {
            ///Arrange

           

            ///Act
            ///

            ///Assert
            ///Use the Assert class to test conditions
           
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayModeTestRunnerWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [Test]
        public void AddAnotherTestMethod()
        {
            
            
        }
    }
}
