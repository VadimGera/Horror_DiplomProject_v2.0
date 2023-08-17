using UnityEngine;

public class CharacterSpawner : MonoBehaviour

{
    public GameObject characterPrefab;
    public GameObject spawnPoint;

    private bool spawned = false;



    public void SpawnCharacter()
    {
        if (!spawned)
        {
            Instantiate(characterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned = true;
        }
    }
}
