using UnityEngine;
using TMPro;

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

    public void CloseStartNote()
    {
        startNoteClosed = true;
        ShowCounter(); // Обновляем счетчик после закрытия начальной записки
    }

        private void UpdateCounter()
    {
        if (startNoteClosed)
        {
            counterText.text = foundNotes + " / " + (totalNotes - 1);
        }
        else
        {
            counterText.text = foundNotes + " / " + totalNotes;
        }
    }
    
    public void ShowCounter()
    {
        counterText.gameObject.SetActive(true); // Показываем счетчик
    }
}
