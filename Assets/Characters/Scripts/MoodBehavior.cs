using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodBehavior : MonoBehaviour
{
    [SerializeField]
    private Image _portrait;
    [SerializeField]
    private Sprite _neutral;
    [SerializeField]
    private Sprite _happy;
    [SerializeField]
    private Sprite _laughing;
    [SerializeField]
    private Sprite _overblown;
    [SerializeField]
    private Sprite _sad;
    [SerializeField]
    private Sprite _concerned;
    [SerializeField]
    private Sprite _angry;
    [SerializeField]
    private Sprite _mad;
    [SerializeField]
    private Sprite _empty;

    [SerializeField]
    private AudioSource _bgm;

    private int _mood = 0;

    public void SetMood(int mood)
    {
        _mood = mood;

        if (_mood > 35)
        {
            _portrait.sprite = _empty;
        }
        else if (_mood > 30)
        {
            _portrait.sprite = _mad;
        }
        else if (_mood > 25)
        {
            _portrait.sprite = _angry;
        }
        else if (_mood > 20)
        {
            _portrait.sprite = _concerned;
        }
        else if (_mood > 15)
        {
            _portrait.sprite = _sad;
        }
        else if (_mood > 10)
        {
            _portrait.sprite = _overblown;
        }
        else if (_mood > 5)
        {
            _portrait.sprite = _laughing;
        }
        else if (_mood > 0)
        {
            _portrait.sprite = _happy;
        }
        else
        {
            _portrait.sprite = _neutral;
        }

        _bgm.pitch = 1 + (_mood * 0.025f);
    }

    public int GetMood()
    {
        return _mood;
    }

    public void AlterMood(int change)
    {
        SetMood(GetMood() + change);
    }
}
