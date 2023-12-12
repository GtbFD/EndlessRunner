using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public int offset;
    void Start()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            Instantiate(platforms[i], new Vector3(0, 0, i * 89), transform.rotation);
            offset += 89;
        }
    }

    public GameObject platformTest;
    void Update()
    {
        /*
         * Teste
         */

        if (Input.GetKeyDown(KeyCode.A))
        {
            Recycle(platforms[0]);
        }
    }

    void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += 89;
    }
}
