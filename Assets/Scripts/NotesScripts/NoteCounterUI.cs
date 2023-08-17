using TMPro;
using UnityEngine;

public class NoteCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    private int totalNotes;
    private int foundNotes;
    private bool startNoteClosed = false;

    public NoteData[] notesDatas;


    private void Start()
    {
        totalNotes = notesDatas.Length;
        foundNotes = 0;
        counterText.gameObject.SetActive(false);
        UpdateCounter();

    }

    public void IncrementCounter()
    {
        foundNotes++;
        UpdateCounter();
    }

    public void ShowCounter()
    {
        counterText.gameObject.SetActive(true);
    }

    public void StartNoteClosed()
    {
        startNoteClosed = true;
        ShowCounter();
    }

    private void UpdateCounter()
    {
        counterText.text = foundNotes + " / " + totalNotes;
    }
}
