using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveBehavior : MonoBehaviour
{
    // A reference to the NavMeshAgent to move
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Find a ray from the camera to the mouse
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Cast the ray to the surface
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                // Set the destination
                _agent.SetDestination(hit.point);
            }
        }
    }
}
