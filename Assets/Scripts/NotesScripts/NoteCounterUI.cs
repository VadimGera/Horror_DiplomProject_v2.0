using UnityEngine;
using TMPro;

public class NoteCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    private int totalNotes;
    private int foundNotes;

    private void Start()
    {
        totalNotes = GameObject.FindGameObjectsWithTag("Note").Length;
        foundNotes = 3;
        UpdateCounter();
    }

    public void IncrementCounter()
    {
        foundNotes++;
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        counterText.text = " " + foundNotes + " / " + totalNotes;
    }
}
