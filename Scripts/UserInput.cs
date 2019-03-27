using System.Collections;
using System.Collections.Generic;
using RTS;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //maintains player object.
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        //gets transform components at root of Player
        player = transform.root.GetComponent< Player >();

    }
    private void MoveCamera()
    {
        //gets mouse x & y positions.
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;

        //movement of the camera.
        Vector3 movement = new Vector3(0, 0, 0);

        //horizontal camera movement
        if (xpos >= 0 && xpos < ResourceManager.ScrollWidth)
        {
            movement.x -= ResourceManager.ScrollSpeed;
        }else if (xpos<= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth)
        {
            movement.x += ResourceManager.ScrollSpeed;
        }

        //vertical camera movement
        if (ypos >= 0 && ypos < ResourceManager.ScrollWidth)
        {
            movement.z -= ResourceManager.ScrollSpeed;
        }
        else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth)
        {
            movement.z += ResourceManager.ScrollSpeed;
        }

        /*
         * Movement explained
         * scrollwidth = distance mouse must be from border to move.
         * so, if xpos is to the rightmost area, move to the right
         * or ypos is to the bottommost area, move down.
        */

        //make sure movement is in the direction the camera is pointing, but ignore the vertical tilt of the camera to get sensible scrolling
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;

        //camera vertical movement, uses scroll wheel.
        //away from ground
        movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");


        //calculate expected camera position, based on input
        Vector3 orgin = Camera.main.transform.position;
        Vector3 destination = orgin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        //limits camera movement.
        if(destination.y > ResourceManager.MaxCameraHeight)
        {
            destination.y = ResourceManager.MaxCameraHeight;
        }else if(destination.y < ResourceManager.MinCameraHeight){
            destination.y = ResourceManager.MinCameraHeight;
        }


        //if location will change, move.
        if (destination != orgin)
        {
            Camera.main.transform.position = Vector3.MoveTowards(orgin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
        }
    }
    private void RotateCamera()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if (player.human)
        {
            MoveCamera();
            RotateCamera();
        }
    }
}
