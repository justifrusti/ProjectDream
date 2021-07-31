using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string lvlToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {
        print("Function to be Added");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
