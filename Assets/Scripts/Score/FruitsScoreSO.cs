using UnityEngine;

[CreateAssetMenu (menuName = "FruitsScoreSO")]
public class FruitsScoreSO: ScriptableObject
{
    [SerializeField] private int[] scores;
    
    public int GetScore(int ind)
    {
        return scores[ind];
    }
}