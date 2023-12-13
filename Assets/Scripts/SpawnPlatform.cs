using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();
    public int offset;
    private Transform playerTransform;
    private Transform currentPlatformPoint;
    private int platformIndex;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        
        for (int i = 0; i < platforms.Count; i++)
        {
            
            var platformTransform = Instantiate(platforms[i], 
                new Vector3(0, 0, i * 89), transform.rotation).transform;
            currentPlatforms.Add(platformTransform);
            offset += 89;
        }

        platformIndex = 0;
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
    }
    
    void Update()
    {
        var distance = playerTransform.position.z - currentPlatformPoint.position.z;

        if (distance >= 5)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;
            
            if (platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
        }
    }

    void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += 89;
    }
}
