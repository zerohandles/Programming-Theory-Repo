using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIElements : MonoBehaviour
{
    public GameObject heathBar;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public Slider healthSlider;
    public TextMeshProUGUI waveText;
    public SpawnManager spawnManager;

    int wave;

    private void Start()
    {
        Time.timeScale = 1;
        heathBar.SetActive(true);
    }

    private void Update()
    {
        if (healthSlider.value <= 0)
        {
            GameOver();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && spawnManager.isFinalWave)
        {
            Victory();
        }
    }

    public void SetWave()
    {
        wave = spawnManager.wave;
        waveText.text = $"Wave: {wave}";
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    private void Victory()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }
}
