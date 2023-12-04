using UnityEngine;

namespace Main
{
    public class StartButton : MonoBehaviour
    {
        [Header("Attached Components")] [SerializeField]
        private ArduinoConnector _arduinoConnector;
    
    
        ////////////////////
        /// \brief The method which sends json data to arduino when Clicking on mouse
        /// \return void
        /// \code
        ///
        ///     public void Click()
        ///         => _arduinoConnector.AssignMessage("0");
        /// 
        /// \endcode
        ////////////////////
        public void Click()
            => _arduinoConnector.AssignMessage("0");
    }
}
