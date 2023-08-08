using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    public GameObject interactionText;
    public NoteData noteData;

    private bool canInteract;

    private void Start()
    {
        interactionText.SetActive(false);
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
        NoteCounterUI noteCounter = FindObjectOfType<NoteCounterUI>();
        if (noteCounter != null)
        {
            noteCounter.IncrementCounter();
        }

        UIManager.Instance.ShowNoteDetails(noteData);


        interactionText.SetActive(false); 
        gameObject.SetActive(false);
    }
}
