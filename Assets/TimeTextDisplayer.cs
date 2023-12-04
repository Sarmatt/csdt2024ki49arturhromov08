using TMPro;
using UnityEngine;

public class TimeTextDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayTime(int time /* miliseconds */)
    {
        _text.text = time / 1000 + ":" + (time % 1000) / 10 + ":" + (time % 1000) % 10;
    }

    public void ResetText()
        => _text.text = "";
}