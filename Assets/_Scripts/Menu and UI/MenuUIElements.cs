using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIElements : MonoBehaviour
{
    public GameObject heathBar;

    private void Start()
    {
        heathBar.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
