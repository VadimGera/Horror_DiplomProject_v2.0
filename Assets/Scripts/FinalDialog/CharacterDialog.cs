using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public string dialogText = "Привет! Это пример диалога с персонажем.";
    public GameObject interactionText; // Префаб текста о взаимодействии

    private bool canInteract = false;
    private DialogManager dialogManager; // Ссылка на DialogManager

    private void Start()
    {
        HideInteractionText(); // Скрываем надпись при старте
        dialogManager = FindObjectOfType<DialogManager>(); // Находим DialogManager на сцене
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by player");
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
            Debug.Log("E key pressed");
            StartDialog();
        }
    }

    private void ShowInteractionText()
    {
        interactionText.SetActive(true); // Показываем надпись о взаимодействии
    }

    private void HideInteractionText()
    {
        interactionText.SetActive(false); // Скрываем надпись о взаимодействии
    }

    private void StartDialog()
    {
        if (dialogManager != null)
        {
            dialogManager.ShowDialog(dialogText);
        }
    }
}
