using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    // Portraits
    [SerializeField]
    private Image _portrait;
    [SerializeField]
    private Sprite _neutralPortrait;
    [SerializeField]
    private Sprite _happyPortrait;
    [SerializeField]
    private Sprite _laughingPortrait;
    [SerializeField]
    private Sprite _overblownPortrait;
    [SerializeField]
    private Sprite _sadPortrait;
    [SerializeField]
    private Sprite _concernedPortrait;
    [SerializeField]
    private Sprite _angryPortrait;
    [SerializeField]
    private Sprite _madPortrait;
    [SerializeField]
    private Sprite _emptyPortrait;

    // Materials
    [SerializeField]
    private SkinnedMeshRenderer _mesh;
    [SerializeField]
    private Material _neutralMaterial;
    [SerializeField]
    private Material _happyMaterial;
    [SerializeField]
    private Material _sadMaterial;
    [SerializeField]
    private Material _rageMaterial;
    [SerializeField]
    private Material _pie1Material;
    [SerializeField]
    private Material _pie2Material;

    [SerializeField]
    private AudioSource _bgm;

    private int _mood = 0;

    private float _pieTimer = 0.0f;

    private void Update()
    {
        _pieTimer -= Time.deltaTime;

        if (_pieTimer > 0.0f && _pieTimer <= 20.0f)
        {
            _mesh.material = _pie2Material;
        }
    }

    public void SetMood(int mood)
    {
        _mood = mood;

        _animator.SetFloat("Mood", _mood);

        if (_pieTimer > 0.0f)
            return;

        if (_mood >= 80)
        {
            _portrait.sprite = _emptyPortrait;
            _mesh.material = _neutralMaterial;
            _bgm.pitch = 0.5f;
        }
        else if (_mood >= 70)
        {
            _portrait.sprite = _madPortrait;
            _mesh.material = _rageMaterial;
            _bgm.pitch = 2.0f;
        }
        else if (_mood >= 60)
        {
            _portrait.sprite = _angryPortrait;
            _mesh.material = _rageMaterial;
            _bgm.pitch = 1.3f;
        }
        else if (_mood >= 50)
        {
            _portrait.sprite = _concernedPortrait;
            _mesh.material = _sadMaterial;
            _bgm.pitch = 0.8f;
        }
        else if (_mood >= 40)
        {
            _portrait.sprite = _sadPortrait;
            _mesh.material = _sadMaterial;
            _bgm.pitch = 0.9f;
        }
        else if (_mood >= 30)
        {
            _portrait.sprite = _overblownPortrait;
            _mesh.material = _happyMaterial;
            _bgm.pitch = 1.2f;
        }
        else if (_mood >= 20)
        {
            _portrait.sprite = _laughingPortrait;
            _mesh.material = _happyMaterial;
            _bgm.pitch = 1.1f;
        }
        else if (_mood >= 10)
        {
            _portrait.sprite = _happyPortrait;
            _mesh.material = _happyMaterial;
            _bgm.pitch = 1.0f;
        }
        else
        {
            _portrait.sprite = _neutralPortrait;
            _mesh.material = _neutralMaterial;
            _bgm.pitch = 1.0f;
        }
    }

    public int GetMood()
    {
        return _mood;
    }

    public void AlterMood(int change)
    {
        SetMood(GetMood() + change);
    }

    public void Pie()
    {
        _pieTimer = 30.0f;
        _mesh.material = _pie1Material;
    }
}
