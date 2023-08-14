using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public List<string> dialogSteps; // Список шагов диалога
    public GameObject interactionText;

    private bool canInteract = false;
    private DialogManager dialogManager;
    private bool isDialogOpen = false;
    private int currentStep = 0; // Текущий шаг диалога

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
            if (!isDialogOpen)
            {
                StartDialog();
            }
            else
            {
                if (currentStep < dialogSteps.Count - 1)
                {
                    // Перейти к следующему шагу диалога
                    currentStep++;
                    dialogManager.ShowDialog(dialogSteps[currentStep]);
                }
                else
                {
                    // Закрыть диалог, если это последний шаг
                    CloseDialog();
                }
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
            dialogManager.ShowDialog(dialogSteps[currentStep]);
        }
    }

    private void CloseDialog()
    {
        if (dialogManager != null)
        {
            isDialogOpen = false;
            dialogManager.CloseDialog();
            currentStep = 0; // Сбросить текущий шаг при закрытии диалога
        }
    }
}
