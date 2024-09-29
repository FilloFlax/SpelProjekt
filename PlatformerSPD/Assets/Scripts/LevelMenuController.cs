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
    public void IntroScene() 
    { 
        SceneManager.LoadScene(2); 
    }
    public void LoadQuestLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(3);
    }
    // TODO Connect to the right scene when created
    public void LoadLevelTwo()
     { 
        SceneManager.LoadScene(4); 
     }

    public void LoadLevelThree()
    {
       // SceneManager.LoadScene(5);
    }

    public void LoadLevelFour()
    {
       // SceneManager.LoadScene(6);
    }
    public void LoadLevelFive()
    {
       // SceneManager.LoadScene(7);
    }
    
    public void LoadLevelSix()
    {
        //SceneManager.LoadScene(8);
    }
    public void LoadLevelSeven()
    {
       // SceneManager.LoadScene(9);
    }
    public void LoadLevelEight()
    {
       // SceneManager.LoadScene(10);
    }
    public void LoadLevelNine()
    {
       // SceneManager.LoadScene(11);
    }








}
