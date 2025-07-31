using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefabs;
    [SerializeField] private int spawnIndex = -1;

    public void OnAttack()
    {
        SpawnFruit();
    }

    private void SpawnFruit()
    {
        if (spawnIndex != -1)
        {
            Instantiate(fruitsPrefabs[spawnIndex], transform.position, Quaternion.identity);
        }
        else
        {
            var randIndex = Random.Range(0, fruitsPrefabs.Length);
            
            Instantiate(fruitsPrefabs[randIndex], transform.position, Quaternion.identity);
        }
    }
}