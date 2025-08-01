using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool ignore;
    public int ind = -1;

    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void EnablePhysics()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void DisablePhysics()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border")) return;

        if (ignore) return;

        var fruit = other.gameObject.GetComponent<Fruit>();

        if (fruit.ind != ind) return;

        fruit.ignore = true;

        //print(other.gameObject.name);

        if (fruit.ind != ind) return;

        Destroy(gameObject);
        Destroy(fruit.gameObject);

        Spawner.Instance.RequestToMerge(ind, other.GetContact(0).point);
    }
}