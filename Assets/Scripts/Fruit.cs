using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool ignore;
    public int ind = -1;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border")) return;
        
        if (ignore) return;

        var fruit = other.gameObject.GetComponent<Fruit>();
        
        if(fruit.ind != ind) return;
        
        fruit.ignore = true;
        
        //print(other.gameObject.name);

        if (fruit.ind != ind) return;
        
        Destroy(gameObject);
        Destroy(fruit.gameObject);
        
        Spawner.Instance.RequestToMerge(ind, other.GetContact(0).point);
    }
}