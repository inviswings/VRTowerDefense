using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour
{
    public LineRenderer line;

    // Update is called once per frame
    void FixedUpdate()
    {
        OVRInput.Update();
        RaycastHit hit;
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.transform.position);
                line.enabled = true;
            }
        }
        else {
            line.enabled = false;
        }
    }
}
