using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject LevelSelection_Panel;
    [SerializeField]
    GameObject Instructions_Panel;
    [SerializeField]
    GameObject Main_Menu_Panel;

    public void Instructions()
    {
        Main_Menu_Panel.SetActive(false);
        Instructions_Panel.SetActive(true);
    }

    public void StartGame()
    {
        Main_Menu_Panel.SetActive(false);
        LevelSelection_Panel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        /*LevelSelection_Panel.SetActive(false);
        Instructions_Panel.SetActive(false);
        Main_Menu_Panel.SetActive(true);*/

        SceneManager.LoadScene("Main_Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }
}
