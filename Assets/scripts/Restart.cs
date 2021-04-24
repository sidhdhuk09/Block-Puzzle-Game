using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public void restartscene()
    {
        SceneManager.LoadScene(0);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {

            restartscene();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
