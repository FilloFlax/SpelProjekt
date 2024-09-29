using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    [SerializeField] private GameObject firstTextButton;
    [SerializeField] private GameObject secondTextButton;
    [SerializeField] private GameObject thirdTextButton;
    [SerializeField] private GameObject fourthTextButton;


    private void Start()
    {
        StartCoroutine(QuestTextTimer());
    }
    public void BackToLevelMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void FirstText()
    { 
        firstTextButton.SetActive(true);
    }
    public void CloseFirstText()
    {
        firstTextButton.SetActive(false);
        secondTextButton.SetActive(true);
    }
    public void CloseSecondText()
    { 
        secondTextButton.SetActive(false);
        thirdTextButton.SetActive(true);
    }
    public void CloseThirdTextButton()
    { 
        thirdTextButton.SetActive(false);
        fourthTextButton.SetActive(true);
    }
    public void ToLevelOne()
    {
        SceneManager.LoadScene(3);
    }
    IEnumerator QuestTextTimer()
    {
        yield return new WaitForSecondsRealtime(2);
        FirstText();
    }



}
