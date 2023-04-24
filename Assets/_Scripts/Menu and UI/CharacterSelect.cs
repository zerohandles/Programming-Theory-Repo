using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public static int playerChoice = 0;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectPunk()
    {
        playerChoice = 1;
        Debug.Log("Punk Selected");
        SceneManager.LoadScene(1);
    }

    public void SelectLawyer()
    {
        playerChoice = 0;
        Debug.Log("Lawyer Selected");
        SceneManager.LoadScene(1);
    }

    public void SelectFarmer()
    {
        playerChoice = 2;
        Debug.Log("Farmer Selected");
        SceneManager.LoadScene(1);
    }

}
