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
    private bool isDialogOpen = false; // Добавим флаг для отслеживания состояния диалога

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
            // Открываем или закрываем диалог, в зависимости от его текущего состояния
            if (!isDialogOpen)
            {
                StartDialog();
            }
            else
            {
                CloseDialog();
            }
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
            isDialogOpen = true;
            dialogManager.ShowDialog(dialogText);
        }
    }

    private void CloseDialog()
    {
        if (dialogManager != null)
        {
            isDialogOpen = false;
            dialogManager.CloseDialog();
        }
    }
}
