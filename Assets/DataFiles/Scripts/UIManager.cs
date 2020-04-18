using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startButtonHolder;

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoPlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("S1");
        
    }

    public void DoExitButton()
    {
        Application.Quit();
    }
}
