using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    public TextTypingBehavior TextTyping;

    public string[] Messages;
    private int _messageIndex = 0;

    public bool IsMultiUse = true;
    public int HideAfterMessage = -1;

    [SerializeField]
    private AudioSource _audioSource;

    private bool _isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsMultiUse && _isUsed)
            return;

        if (Messages.Length == 0 || _messageIndex < 0 || _messageIndex >= Messages.Length)
            return;

        // Stop character's movement
        TextTyping.GetComponent<MoveBehavior>().Stop();
        
        // Type next character
        TextTyping.BeginTyping(Messages[_messageIndex], _audioSource);

        // Hide object if needed
        if (HideAfterMessage != -1 && _messageIndex >= HideAfterMessage)
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        // Go to next character
        if (_messageIndex < Messages.Length - 1)
        {
            _messageIndex++;
        }
        else
        {
            _isUsed = true;
        }
    }
}
