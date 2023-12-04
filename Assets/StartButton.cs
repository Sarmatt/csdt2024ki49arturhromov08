using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [Header("Attached Components")] [SerializeField]
    private ArduinoConnector _arduinoConnector;
     
    public void Click()
        => _arduinoConnector.AssignMessage("0");

}
