using System.Collections;
using System.IO.Ports;
using Main;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MainTester
    {
        [UnityTest]
        public IEnumerator TestArduinoConnection()
        {
            SerialPort _sp = new SerialPort("COM6", 9600);
            _sp.Open();
            Assert.AreEqual(_sp.IsOpen, true);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestArduinoClose()
        {
            SerialPort _sp = new SerialPort("COM6", 9600);
            _sp.Open();
            _sp.Close();
            Assert.AreEqual(_sp.IsOpen, false);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestTimeTextDisplayer()
        {
            var go = new GameObject("TimeTextTest");
            go.AddComponent<TimeTextDisplayer>();
            var script = go.GetComponent<TimeTextDisplayer>();
            string convertedTime = script.GetConvertedTime(1000);
            Assert.AreEqual(convertedTime, "1:0:0");
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestJsonSending()
        {
            var go = new GameObject("JsonTest");
            go.AddComponent<ArduinoConnector>();
            var script = go.GetComponent<ArduinoConnector>();
            Assert.AreEqual(script.GetAssignedMeessage("0"), "{\"key1\":\"0\"}\n");
            yield return null;
        }
    }
}