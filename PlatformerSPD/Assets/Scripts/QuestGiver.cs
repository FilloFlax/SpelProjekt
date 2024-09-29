using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            textPopUp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            textPopUp.SetActive(false);
        }
    }
    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(4);
    }

}
