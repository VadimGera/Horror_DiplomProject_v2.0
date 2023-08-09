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

    private bool startNoteClosed = false;

    private void Awake()
    {
        Instance = this;
        notePanel.SetActive(false);

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



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideNoteDetails();
        }
    }
    public void CloseStartNote()
    {
        startNoteClosed = true;

    }
    public bool IsStartNoteClosed()
    {
        return startNoteClosed;
    }


}
