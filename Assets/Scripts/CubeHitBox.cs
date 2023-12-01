using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeHitBox : MonoBehaviour
{
    public GameObject ball;
    public Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        
        defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position;
        transform.rotation = defaultRotation;
    }
}
