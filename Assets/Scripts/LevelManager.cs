using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];

    public void SetLevel()
    {
        Reset();

        int randIndex = Random.Range(0, 2);
        SetObstacle(obstacles[randIndex], false);
    }

    public void Reset()
    {
        foreach (GameObject obstacle in obstacles)
        {
            SetObstacle(obstacle, true);
        }
    }

    public void SetObstacle(GameObject obstacle, bool isObjectLoaded)
    {
        obstacle.GetComponent<Collider>().enabled = isObjectLoaded;
        obstacle.GetComponent<MeshRenderer>().enabled = isObjectLoaded;
    }
}
