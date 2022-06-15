using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credit;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Ilham Triza Kurniawan - 149251970101-56");
    }

    public void OpenCredit()
    {
        mainMenu.SetActive(false);
        credit.SetActive(true);
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credit.SetActive(false);
    }
}
