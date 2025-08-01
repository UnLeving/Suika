using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }
         
    
    
    [SerializeField] private Fruit[] fruitsPrefabs;
    [SerializeField] private int spawnIndex = -1;

    private int indToSpawn;

    private void Awake()
    {
        Instance = this;
    }

    public void OnAttack()
    {
        SpawnFruit();
    }

    private void SpawnFruit()
    {
        if (spawnIndex != -1)
        {
            indToSpawn = spawnIndex;
        }
        else
        {
            var randIndex = Random.Range(0, fruitsPrefabs.Length);
            
            indToSpawn = randIndex;
        }
        
        Fruit fruit = Instantiate(fruitsPrefabs[indToSpawn], transform.position, Quaternion.identity);
            
        //fruit.ind = indToSpawn;
    }

    public void RequestToMerge(int ind, Vector2 pos)
    {
        Fruit fruit = Instantiate(fruitsPrefabs[++ind], pos, Quaternion.identity);
            
        //fruit.ind = indToSpawn;
    }
}