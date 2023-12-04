using System.IO.Ports;
using System.Threading;
using UnityEngine;


public class ArduinoConnector : MonoBehaviour
{
    private Thread _iOThread = new Thread(DataThread);
    private static SerialPort _sp;
    private static string _incomingMsg = "";
    private static string _outgoingMsg = "";
    private static void DataThread()
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
            Thread.Sleep(200);
        }
    }
    private void Start()
    {
        _iOThread.Start();
 
    }
    private void Update()
    {
        if (_incomingMsg != "")
            Debug.Log(_incomingMsg);
        if(Input.GetKeyDown(KeyCode.Alpha1))
            _outgoingMsg = "0";
    }
 
    private void OnDestroy()
    {
        _iOThread.Abort();
        _sp.Close();
    }
}
