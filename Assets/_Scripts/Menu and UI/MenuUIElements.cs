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
        // Update player health bar
        if (healthSlider.value <= 0)
        {
            GameOver();
        }
        // Trigger victory when the player has cleared the last wave.
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && spawnManager.isFinalWave)
        {
            Victory();
        }
    }

    // Set the wave text UI element
    public void SetWave()
    {
        wave = spawnManager.wave;
        waveText.text = $"Wave: {wave}";
    }

    // Exit the application 
    public void QuitGame()
    {
        Application.Quit();
    }

    // Load the title scene
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Display game over UI elements and pause gameplay
    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    // Display victory UI elements and pause gameplay
    private void Victory()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }
}
