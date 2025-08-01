using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }
    
    
    [SerializeField] private Fruit[] fruitsPrefabs;
    [SerializeField] private int spawnIndex = -1;

    private int _indToSpawn;
    
    public event System.Action<int> OnFruitMerged;

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
            _indToSpawn = spawnIndex;
        }
        else
        {
            var randIndex = Random.Range(0, fruitsPrefabs.Length);
            
            _indToSpawn = randIndex;
        }
        
        Instantiate(fruitsPrefabs[_indToSpawn], transform.position, Quaternion.identity);
    }

    public void RequestToMerge(int ind, Vector2 pos)
    {
        OnFruitMerged?.Invoke(ind);
        
        Instantiate(fruitsPrefabs[++ind], pos, Quaternion.identity);
    }
}