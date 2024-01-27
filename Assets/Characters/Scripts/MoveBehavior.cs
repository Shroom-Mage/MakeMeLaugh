using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    /**
     * The magnitude of the GameObject's movement.
     **/
    public float speed = 1.0f;
    /**
     * A reference to the CharacterController to move.
     **/
    public CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetMouseButton(0))
        {
            //Get the mouse position
            Vector3 mousePosition = Input.mousePosition;
            //Get a ray from the camera to the mouse
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            //Create a plane at the player's position
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            //Find how far from the camera the ray intersects the plane
            float rayDistance = 0.0f;
            playerPlane.Raycast(mouseRay, out rayDistance);
            //Get the point on the ray at the distance to the plane
            Vector3 targetPoint = mouseRay.GetPoint(rayDistance);

            //Find the direction
            direction = (targetPoint - transform.position).normalized;
        }

        //Apply the speed
        Vector3 movement = direction * speed;

        //Move
        characterController.SimpleMove(movement);
    }
}
