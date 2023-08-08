using UnityEngine;
using TMPro;

public class NoteCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    private int totalNotes;
    private int foundNotes;

    public NoteData[] notesDatas;

    private void Start()
    {
        totalNotes = notesDatas.Length;
        foundNotes = 0;
        UpdateCounter();
    }

    public void IncrementCounter()
    {
        foundNotes++;
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        counterText.text = " " + foundNotes + " / 3 " ;
    }
}
