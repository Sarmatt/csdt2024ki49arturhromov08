using TMPro;
using UnityEngine;

namespace Main
{
    public class TimeTextDisplayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        ////////////////////
        /// \brief The method which sends json data to arduino when Clicking on mouse
        /// \param time The message catched from arduino
        /// \return void
        /// \code
        ///  public void DisplayTime(int time /* miliseconds */)
        ///  {
        ///     _text.text = time / 1000 + ":" + (time % 1000) / 10 + ":" + (time % 1000) % 10;
        ///  }
        /// 
        /// \endcode
        ////////////////////
        public void DisplayTime(int time /* miliseconds */)
        {
            _text.text = GetConvertedTime(time);
        }

        public void ResetText()
            => _text.text = "00:00:00";
        
        public string GetConvertedTime(int time)
            => time / 1000 + ":" + (time % 1000) / 10 + ":" + (time % 1000) % 10; /// 1:0:0
    }
}