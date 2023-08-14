using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public Dialog01 dialog;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Показываем текст взаимодействия при подходе к персонажу
            Debug.Log("Trigger entered by player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Скрываем текст взаимодействия при отдалении от персонажа
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Начинаем диалог при нажатии клавиши "E"
            if (dialogManager != null)
            {
                dialogManager.ShowDialog(dialog.dialogText);
            }
        }
    }
}
