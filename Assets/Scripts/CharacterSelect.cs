using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public int playerChoice = 0;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerChoice != 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SelectPunk()
    {
        playerChoice = 2;
        Debug.Log("Punk Selected");
    }

    public void SelectLawyer()
    {
        playerChoice = 1;
        Debug.Log("Lawyer Selected");
    }

    public void SelectFarmer()
    {
        playerChoice = 3;
        Debug.Log("Farmer Selected");
    }

}
