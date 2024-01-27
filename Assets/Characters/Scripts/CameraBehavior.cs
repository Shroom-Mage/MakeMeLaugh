using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // A reference to the Camera to move
    private Camera _camera;
    // The offset of the Camera from its FollowTarget
    private Vector3 _offset;

    // A reference to the Transform to follow
    public Transform FollowTarget;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        if (_camera && FollowTarget)
        {
            _offset = transform.position - FollowTarget.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the camera
        if (_camera && FollowTarget)
        {
            transform.position = FollowTarget.position + _offset;
        }
    }
}
