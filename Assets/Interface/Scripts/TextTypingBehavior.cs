using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TextTypingBehavior : MonoBehaviour
{
    private MoodBehavior _mood;

    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private AudioSource _voice;

    public float TypingDelay = 0.1f;
    public float PitchDeviation = 0.2f;

    private string _message = "";
    private float _timer;
    private int _char = -1;

    private const int COLUMNS = 33;
    private const int ROWS = 4;

    private void Awake()
    {
        _mood = GetComponent<MoodBehavior>();
    }

    private void Update()
    {
        if (_text == null)
            return;

        if (_timer <= 0.0f && _char >= 0 && _char < _message.Length && _message != "")
        {
            // Alter mood
            if (_message[_char] ==  '`')
            {
                _char++;
                _mood.AlterMood(_message[_char] - '0');
                _char++;
            }

            // Play sound for letters
            if (_message[_char] != ' ' && _message[_char] != '\'' && _message[_char] != '\"' && _message[_char] != '*')
            {
                _voice.pitch = 1 + Random.Range(-PitchDeviation, PitchDeviation);
                _voice.Play();
            }

            // Print next character
            _text.text += _message[_char];

            // Advance
            _timer = TypingDelay;
            _char++;
        }
        else if (_char == _message.Length)
        {
            _char = -1;
        }

        _timer -= Time.deltaTime;

    }

    public void BeginTyping(string message)
    {
        _message = message;
        _text.text = "";

        _timer = 0.0f;
        _char = 0;
    }
}
