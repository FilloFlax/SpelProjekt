using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 10;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerMovement>().bananasCollected >= questGoal)
            {
                dialogueBox.SetActive(true);
                finishedText.SetActive(true);
                anim.SetTrigger("Flag");
            }
            else
            {
                dialogueBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            finishedText.SetActive(false);
            unfinishedText.SetActive(false);
        }
    }
}
