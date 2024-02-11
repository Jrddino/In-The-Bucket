using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{
    public SoundEffectPlayer sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        sfxPlayer = GameObject.Find("GameManager").GetComponent<SoundEffectPlayer>();
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Cube")
        {
            sfxPlayer.PlayScream();
        }
    }
}
