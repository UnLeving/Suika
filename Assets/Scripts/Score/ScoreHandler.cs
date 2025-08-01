using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private FruitsScoreSO fruitsScoreSO;

    private int _score;
    
    public static event Action<int> OnScoreChanged;
    
    private void Start()
    {
        Spawner.Instance.OnFruitMerged += Spawner_OnOnFruitMerged;
        
        OnScoreChanged?.Invoke(_score);
    }

    private void OnDestroy()
    {
        Spawner.Instance.OnFruitMerged -= Spawner_OnOnFruitMerged;
    }
    
    private void Spawner_OnOnFruitMerged(int ind)
    {
        _score += fruitsScoreSO.GetScore(ind);
        
        OnScoreChanged?.Invoke(_score);
    }
}