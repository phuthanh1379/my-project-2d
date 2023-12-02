using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;
    [SerializeField] private string dialogue;

    private void Awake()
    {
        interactUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.SetActive(true);
        }
    }

    public void OnClickInteractUI()
    {
        DialogueController.Instance.ShowDialogue(dialogue);
    }
}
