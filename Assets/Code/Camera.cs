using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    //John: Replaced GameObject to Transform
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    /*
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    */

    //John: Added a smoother way of having the camera follow the player
    //      Set it to FixedUpdate so it keeps with the current FPS
    private void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos;
    }
}