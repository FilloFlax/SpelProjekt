using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }
   public void LoadLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelTwo()
     { 
        SceneManager.LoadScene(3); 
     }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevelFour()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevelFive()
    {
        SceneManager.LoadScene(6);
    }
    
    public void LoadLevelSix()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevelSeven()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadLevelEight()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevelNine()
    {
        SceneManager.LoadScene(10);
    }
    public void LoadQuestLevel()
    {
        SceneManager.LoadScene(11);
    }







}
