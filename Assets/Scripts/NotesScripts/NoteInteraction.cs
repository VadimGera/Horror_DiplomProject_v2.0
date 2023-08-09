using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    public GameObject interactionText;
    public NoteData noteData;
    public bool isStartNote = false; // Добавляем переменную для определения начальной записки
    

    private bool canInteract;

    private void Start()
    {
        interactionText.SetActive(false);

        if (isStartNote && UIManager.Instance.IsStartNoteClosed())
        {
            NoteCounterUI noteCounter = FindObjectOfType<NoteCounterUI>();
            if (noteCounter != null)
            {
                noteCounter.ShowCounter(); // Показываем счетчик после закрытия начальной записки
            }
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            CollectNote();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactionText.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactionText.SetActive(false); 
        }
    }


    private void CollectNote()
    {
        if (isStartNote)
        {
            NoteCounterUI noteCounter = FindObjectOfType<NoteCounterUI>();
            if (noteCounter != null)
            {
                noteCounter.CloseStartNote(); // Закрываем начальную записку
            }
        }

        UIManager.Instance.ShowNoteDetails(noteData);

        interactionText.SetActive(false);
        gameObject.SetActive(false);
    }
}
