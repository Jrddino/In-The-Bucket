using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDespawner : MonoBehaviour
{
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Cube")
        {
            Destroy(trigger.gameObject);
        }
    }
}
