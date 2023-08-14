using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogWindowPrefab;
    private GameObject currentDialogWindow;

    public void ShowDialog(string dialogText)
    {
        CloseDialog();

        currentDialogWindow = Instantiate(dialogWindowPrefab, transform);

        TextMeshProUGUI dialogTextField = currentDialogWindow.GetComponentInChildren<TextMeshProUGUI>();

        if (dialogTextField != null)
        {
            dialogTextField.text = dialogText;
        }
        else
        {
            Debug.LogWarning("Dialog text field not found in the dialog window prefab");
        }
    }

    public void CloseDialog()
    {
        if (currentDialogWindow != null)
        {
            Destroy(currentDialogWindow);
        }
    }
}
