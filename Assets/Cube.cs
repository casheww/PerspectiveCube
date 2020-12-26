using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // eh, maybe it would make more sense for this part to be in Me.cs,
        // but it's here now, so...
        Magic();
    }

    void Magic()
    {
        Vector3 pos = transform.position;
        Vector3 camPos = Camera.main.transform.position;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!shiftHeldLastUpdate)
            {
                cameraDist = Vector3.Distance(pos, camPos);
            }

            transform.position = camPos + Camera.main.transform.forward * cameraDist;

            Zoom();
            shiftHeldLastUpdate = true;
        }
        else
        {
            shiftHeldLastUpdate = false;
        }
    }

    void Zoom()
    {
        Vector2 scroll = Input.mouseScrollDelta;
        if (scroll.y < 0)
        {
            cameraDist *= scaleDown;
            transform.localScale *= scaleDown;
        }
        else if (scroll.y > 0)
        {
            cameraDist *= scaleUp;
            transform.localScale *= scaleUp;
        }
    }

    float cameraDist;
    bool shiftHeldLastUpdate = false;
    float scaleUp = 1.03f;
    float scaleDown = 0.97f;
}
