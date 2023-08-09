using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject notePanel;
    public TextMeshProUGUI noteText;
    public Image noteImage;
    public TextMeshProUGUI counterText;

    private bool startNoteClosed = false;

    private void Awake()
    {
        Instance = this;
        notePanel.SetActive(false);
        counterText.gameObject.SetActive(false);
    }

    public void ShowNoteDetails(NoteData noteData)
    {
        noteText.text = noteData.noteText;
        noteImage.sprite = noteData.noteImage;
        notePanel.SetActive(true);
    }

    public void HideNoteDetails()
    {
        notePanel.SetActive(false);
    }

    public void CloseStartNote()
    {
        startNoteClosed = true;
        ShowCounter(); // Показываем счетчик после закрытия начальной записки
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideNoteDetails();
        }
    }

    public bool IsStartNoteClosed()
    {
        return startNoteClosed;
    }

    public void ShowCounter()
    {
        counterText.gameObject.SetActive(true);
    }
}
