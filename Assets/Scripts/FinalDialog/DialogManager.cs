using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    }

    public void CloseDialog()
    {
        if (currentDialogWindow != null)
        {
            Destroy(currentDialogWindow);
        }
    }

    public void OnDialogFinished()
    {
        SceneManager.LoadSceneAsync("EndGameCutScene");
    }

    public bool IsDialogOpen()
    {
        return currentDialogWindow != null;
    }
}
