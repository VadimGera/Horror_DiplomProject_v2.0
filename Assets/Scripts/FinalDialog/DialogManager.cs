using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPrefab;
    private GameObject currentDialog;

    public void ShowDialog (string dialogText)
    {
        CloseDialog();

        currentDialog = Instantiate(dialogPrefab, transform);

        TextMeshProUGUI dialogTextField = currentDialog.GetComponentInChildren<TextMeshProUGUI>();

        if (dialogTextField != null )
        {
            dialogTextField.text = dialogText;
        }
        else
        {
            Debug.LogWarning("Dialog text field not found in the dialog prefab");
        }
    }

    public void CloseDialog()
    {
        if ( currentDialog != null )
        {

            currentDialog.SetActive(false);
        }
    }
}
