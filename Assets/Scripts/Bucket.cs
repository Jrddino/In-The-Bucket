using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public GameManager gameManager;

    public float collisionTimer;
    public float collisionBuffer;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (collisionTimer > 0.0f)
        {
            collisionTimer -= Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && collisionTimer <= 0.0f)
        {
            gameManager.Score(1);
            collisionTimer = 2.0f;
        }
    }

    public void SetBuffer(float buffer)
    {
        if (buffer >= 0.0f)
        {
            collisionBuffer = buffer;
        }
    }

}
