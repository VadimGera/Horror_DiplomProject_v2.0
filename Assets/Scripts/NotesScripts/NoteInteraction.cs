using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    public GameObject interactionText; // Ссылка на объект с надписью "нажмите [E] чтобы взять"

    private bool canInteract; // Флаг, определяющий, может ли игрок взаимодействовать с запиской

    private void Start()
    {
        interactionText.SetActive(false); // Скрываем надпись при старте уровня
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // При нажатии на кнопку E подбираем записку
            CollectNote();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactionText.SetActive(true); // Показываем надпись при наведении на записку
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactionText.SetActive(false); // Скрываем надпись при отведении курсора от записки
        }
    }

    private void CollectNote()
    {
        // Добавь здесь логику для сбора записки (увеличение счетчика, скрытие записки и т.д.)
    }
}
