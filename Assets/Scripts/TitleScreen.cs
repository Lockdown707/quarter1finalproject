using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start and Restart Button
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        //Exit
        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
