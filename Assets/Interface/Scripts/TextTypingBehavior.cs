using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TextTypingBehavior : MonoBehaviour
{
    private MoodBehavior _mood;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private AudioSource _voice;

    public float TypingDelay = 0.1f;
    public float PitchDeviation = 0.2f;

    private string _message = "";
    private AudioSource _soundEffect;
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

        // If a character should be printed
        if (_timer <= 0.0f && _char >= 0 && _char < _message.Length && _message != "")
        {
            // Alter mood
            if (_message[_char] == '`')
            {
                _char++;
                switch (_message[_char])
                {
                    case 'f':
                        _animator.SetTrigger("Fall");
                        break;
                    case 't':
                        _animator.SetTrigger("Throw");
                        break;
                    case 'p':
                        _animator.SetTrigger("Pickup");
                        break;
                    case 'c':
                        _animator.SetTrigger("Cry");
                        break;
                    case 's':
                        if (_soundEffect)
                            _soundEffect.Play();
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        _mood.AlterMood(_message[_char] - '0');
                        break;
                    case '0':
                        _mood.AlterMood(10);
                        break;
                }
                _char++;
            }
            else
            {
                // Play sound for letters
                if (_message[_char] != ' ' && _message[_char] != '.' && _message[_char] != '\"' && _message[_char] != '*' && _message[_char] != '`')
                {
                    _voice.pitch = 1.0f + Random.Range(-PitchDeviation, PitchDeviation) - (_mood.GetMood() >= 80 ? 0.5f : 0.0f);
                    _voice.Play();
                }

                // Print next character
                _text.text += _message[_char];

                // Advance
                _timer = TypingDelay + (_mood.GetMood() >= 80 ? 0.15f : 0.0f);
                _char++;
            }
        }
        else if (_char == _message.Length)
        {
            _char = -1;
        }

        _timer -= Time.deltaTime;

    }

    public void BeginTyping(string message, AudioSource sound)
    {
        _message = message;
        _text.text = "";

        _soundEffect = sound;

        _timer = 0.0f;
        _char = 0;
    }
}
