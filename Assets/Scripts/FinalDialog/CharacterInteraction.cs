using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public string dialogText;
    public GameObject interactionText; // Префаб текста о взаимодействии

    private bool canInteract = false;
    private DialogManager dialogManager;

    private void Start()
    {
        HideInteractionText();
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            ShowInteractionText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            HideInteractionText();
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            StartDialog();
        }
    }

    private void ShowInteractionText()
    {
        interactionText.SetActive(true);
    }

    private void HideInteractionText()
    {
        interactionText.SetActive(false);
    }

    private void StartDialog()
    {
        if (dialogManager != null)
        {
            dialogManager.ShowDialog(dialogText);
        }
    }
}
