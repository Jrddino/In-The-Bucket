using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;

    public void SpawnCube()
    {
        Instantiate(cube, transform.position, transform.rotation);
    }
}
