using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }


    [SerializeField] private Fruit[] fruitsPrefabs;
    [SerializeField] private int spawnIndex = -1;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private int dontSpawnFromEnd = 3;
    private int _indToSpawn;
    private Fruit _fruit;
    
    public event System.Action<int> OnFruitMerged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnFruit();
    }

    public void OnAttack()
    {
        if(_fruit == null) return;
        
        _fruit.transform.SetParent(null);
        
        _fruit.EnablePhysics();
        
        _fruit = null;
        
        Invoke(nameof(SpawnFruit), spawnDelay);
    }

    private void SpawnFruit()
    {
        if (spawnIndex >= 0)
        {
            _indToSpawn = spawnIndex;
        }
        else
        {
            var randIndex = Random.Range(0, fruitsPrefabs.Length - dontSpawnFromEnd);

            _indToSpawn = randIndex;
        }

        _fruit = Instantiate(fruitsPrefabs[_indToSpawn], transform.position, Quaternion.identity, this.transform);
    }

    public void RequestToMerge(int ind, Vector2 pos)
    {
        OnFruitMerged?.Invoke(ind);

       var f = Instantiate(fruitsPrefabs[++ind], pos, Quaternion.identity);
       f.EnablePhysics();
    }
}