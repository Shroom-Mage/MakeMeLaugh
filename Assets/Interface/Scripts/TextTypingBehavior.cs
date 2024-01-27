using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TextTypingBehavior : MonoBehaviour
{
    public float TypingDelay = 0.1f;
    public float PitchDeviation = 0.2f;

    private TextMeshProUGUI _text;
    private AudioSource _audioSource;
    
    private string _message = "";
    private float _timer;
    private int _char;

    private const int COLUMNS = 33;
    private const int ROWS = 4;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_text == null)
            return;

        if (_timer <= 0.0f && _char < _message.Length && _message != "")
        {
            if (_message[_char] != ' ' && _message[_char] != '.' && _message[_char] != ',' && _message[_char] != '!' && _message[_char] != '?' && _message[_char] != '\'' && _message[_char] != '\"' && _message[_char] != '*')
            {
                _audioSource.pitch = 1 + Random.Range(-PitchDeviation, PitchDeviation);
                _audioSource.Play();
            }

            _text.text += _message[_char];
            _timer = TypingDelay;
            _char++;
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
