using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isActive;
    public GameManager gameManager;
    public SoundEffectPlayer sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxPlayer = GameObject.Find("GameManager").GetComponent<SoundEffectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StrafeLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StrafeRight();
            }
        }
    }

    public void StrafeLeft()
    {
        transform.Translate(new Vector3(0, 0, -2));
    }

    public void StrafeRight()
    {
        transform.Translate(new Vector3(0, 0, 2));
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bucket")
        {
            isActive = false;
        }
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (isActive)
        {
            if (trigger.gameObject.tag == "Trigger")
            {
                sfxPlayer.PlayScream();
            }

            if (trigger.gameObject.name == "CubeDespawner")
            {
                gameManager.GameOver();

            }
        }
    }
}
