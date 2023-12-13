using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;
    public float decayRate = 0.8f;
    public bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            isSpawning=false;
            StartCoroutine(SpawnDelay());
        }
    }
    

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(repeatRate);
        isSpawning=true;
    }

    public void ChangeSpeed()
    {
        repeatRate *= decayRate;
    }
}
