using System;
using System.IO.Ports;
using System.Threading;
using TMPro;
using UnityEngine;

namespace Main
{
    public class ArduinoConnector : MonoBehaviour
    {
        [SerializeField] private TMP_Text _displayingText;
        
        
        [SerializeField] private TimeTextDisplayer _timeTextDisplayer;

        private Thread _iOThread = new Thread(DataThread);
        private static SerialPort _sp; 
        private static string _incomingMsg = "";
        private static string _outgoingMsg = "";

        ////////////////////
        /// \brief The method which connects Unity code to arduino
        /// \param _sp Serial Port
        /// \code
        /// private static void DataThread()
        /// {
        ///     _sp = new SerialPort("COM6", 9600);
        ///     _sp.Open();
        ///
        /// while (true)
        /// {
        ///     if (_outgoingMsg != "")
        ///     {
        ///         _sp.Write(_outgoingMsg);
        ///         _outgoingMsg = "";
        ///     }
        ///
        ///     _incomingMsg = _sp.ReadExisting();
        ///     Debug.Log(_incomingMsg);
        ///     Thread.Sleep(50);
        ///     }
        /// }
        /// \endcode
        ////////////////////
        public static void DataThread()
        {
            _sp = new SerialPort("COM6", 9600);
            _sp.Open();

            while (true)
            {
                if (_outgoingMsg != "")
                {
                    _sp.Write(_outgoingMsg);
                    _outgoingMsg = "";
                }

                _incomingMsg = _sp.ReadExisting();
                Debug.Log(_incomingMsg);
                Thread.Sleep(50);
            }
        }
        
        
        private void Start()
        {
            _iOThread.Start();
        }

        private void Update()
        {
            if (_incomingMsg != "")
                _timeTextDisplayer.DisplayTime(Int32.Parse(_incomingMsg));
        }

        private void OnDestroy()
        {
            _iOThread.Abort();
            _sp.Close();
        }

        public string GetAssignedMeessage(string msg)
        => "{\"key1\":\"" + msg + "\"}\n";

        ////////////////////
        /// \brief The method which sends json data to arduino
        /// \param msg The message to send to arduino
        /// \return void
        /// \code
        ///
        ///  public void AssignMessage(string msg)
        ///  {
        ///   string jsonData = "{\"key1\":\"0\"}\n";
        ///   _outgoingMsg = msg;
        ///  }
        /// 
        /// \endcode
        ////////////////////
        public void AssignMessage(string msg)
        {
            _outgoingMsg = GetAssignedMeessage(msg);
        }
    }
}