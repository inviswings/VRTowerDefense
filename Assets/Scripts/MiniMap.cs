using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Player;
    private List<Vector3> Satellite;
    private bool curentlyIn = false;

    // Start is called before the first frame update
    void Start()
    {
        Satellite = new List<Vector3>();
        Satellite.Add(new Vector3(0f, 100f, -450f));
        Satellite.Add(new Vector3(-450f, 100f, 0f));
        Satellite.Add(new Vector3(0f, 100f, 450f));
        Satellite.Add(new Vector3(450f, 100f, 0f));

        Satellite.Add(new Vector3(225f, 325f, -225f));
        Satellite.Add(new Vector3(-225f, 325f, -225f));
        Satellite.Add(new Vector3(225f, -125f, -225f));
        Satellite.Add(new Vector3(-225f, 325f, -225f));

        Satellite.Add(new Vector3(225f, 325f, 225f));
        Satellite.Add(new Vector3(-225f, 325f, 225f));
        Satellite.Add(new Vector3(225f, -125f, 225f));
        Satellite.Add(new Vector3(-225f, -125f, 225f));

        Satellite.Add(new Vector3(0f, 550f, 0f));
        Satellite.Add(new Vector3(0f, -350f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!curentlyIn)
        {
            curentlyIn = true;
            MinimapButton b = collider.GetComponent<MinimapButton>();
            if (b != null)
            {
                Player.position = Satellite[b.ID - 1];
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }

    private void OnTriggerExit(Collider collider)
    {
        if (curentlyIn)
        {
            curentlyIn = false;
        }
    }

}
