using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float startDelay = 2;
    public float repeatRate = 2;
    public bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        isSpawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle ()
    {
        if (isSpawning)
        {
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
        }
    }

    /*IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitforSeconds(2);
        }
        yield return new WaitForSeconds(repeatRate);
    }*/
}
