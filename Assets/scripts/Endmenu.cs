using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void TryAgain()
    {
        Debug.Log("hi");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
       
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void nextMission()
    {
        ///fix this
        SceneManager.LoadScene("mission2");
    }
}
