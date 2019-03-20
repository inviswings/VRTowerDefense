using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public OVRInput.Controller rightController;
    public OVRInput.Controller leftController;
    private float velocity = 3.0f;

    private bool Move = true;
    private float waitTime = 0.5f;
    private float timer = 0f;
    private Vector3 rotation;

    private void Start()
    {
    }

    void Update()
    {
        OVRInput.Update();
        
        if (OVRInput.Get(OVRInput.Button.One)) {
            if (Move)
            {
                //rotation = transform.TransformDirection(OVRInput.GetLocalControllerRotation(rightController).eulerAngles);
                Vector3 rotationtemp = OVRInput.GetLocalControllerRotation(rightController).eulerAngles;

                rotation = new Vector3(0.0f, 0.0f, 0.0f);
                rotation.x = Mathf.Sin(rotationtemp.y * Mathf.Deg2Rad);
                rotation.z = Mathf.Cos(rotationtemp.y * Mathf.Deg2Rad);
                rotation.y = -Mathf.Sin(rotationtemp.x * Mathf.Deg2Rad);
                if (rotation.x > 0.0f)
                    rotation.x = 0.35f;
                else if (rotation.x < 0.0f)
                    rotation.x = -0.35f;
                if (rotation.y > 0.0f)
                    rotation.y = 0.35f;
                else if (rotation.y < 0.0f)
                    rotation.y = -0.35f;
                if (rotation.z > 0.0f)
                    rotation.z = 0.35f;
                else if (rotation.z < 0.0f)
                    rotation.z = -0.35f;

                Move = false;
            }
            else {
                transform.position += rotation * velocity;
            }
        }
        if(!Move)
        {
            transform.position += rotation * (velocity - timer);
        }

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0f;
            Move = true;
        }
    }
}
