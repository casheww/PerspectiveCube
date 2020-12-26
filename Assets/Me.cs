using System;
using UnityEngine;

public class Me : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeRotation();
        ChangePosition();
        AnchorCamera();
        VelocityResetCheck();
    }

    void ChangeRotation()
    {
        /* https://forum.unity.com/threads/mouse-look-script.233903/ */

        const float minX = 0.0f;
        const float maxX = 360.0f;
        const float minY = -90.0f;
        const float maxY = 90.0f;

        rotX += Input.GetAxis("Mouse X") * (mouseSensitivity * Time.deltaTime);

        if (rotX < minX) rotX += maxX;
        else if (rotX > maxX) rotX -= maxX;

        rotY -= Input.GetAxis("Mouse Y") * (mouseSensitivity * Time.deltaTime);

        if (rotY < minY) rotY = minY;
        else if (rotY > maxY) rotY = maxY;

        transform.rotation = Quaternion.Euler(rotY, rotX, 0.0f);
    }

    void ChangePosition()
    {
        float sideways = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * sideways + transform.forward * forward;
        movement = transform.position + movement * speed;
        transform.position = new Vector3(movement.x, 2f, movement.z);
    }

    void AnchorCamera()
    {
        Camera.main.transform.position = transform.position;
        Camera.main.transform.rotation = transform.rotation;
    }

    void VelocityResetCheck()
    {
        /* some collision stuff is causing a velocity bug and I cba to fix it properly */

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    float speed = 0.1f;
    float mouseSensitivity = 200f;

    float rotX;
    float rotY;
}
