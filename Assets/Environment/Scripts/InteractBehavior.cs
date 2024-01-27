using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;

    public TextTypingBehavior TextTyping;

    public string Message;

    private void OnTriggerEnter(Collider other)
    {
        TextTyping.BeginTyping(Message);
    }
}
