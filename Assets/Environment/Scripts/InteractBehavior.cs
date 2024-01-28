using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    public TextTypingBehavior TextTyping;

    public string[] Messages;
    private int _messageIndex = 0;

    public bool IsMultiUse = true;
    public bool HideAfterUse = false;

    [SerializeField]
    private AudioSource _audioSource;

    private bool _isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsMultiUse && _isUsed)
            return;

        TextTyping.BeginTyping(Messages[_messageIndex], _audioSource);
        if (_messageIndex < Messages.Length - 1)
        {
            _messageIndex++;
        }
        else
        {
            _isUsed = true;
            if (HideAfterUse)
            {
                GetComponentInChildren<MeshRenderer>().enabled = false;
            }
        }
    }
}
