using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform leftWallTransform;
    [SerializeField] private Transform rightWallTransform;
    [SerializeField] private float speed = 2f;
    private float xDir;

    public void OnMove(InputValue value)
    {
        var dir = value.Get<Vector2>();

        xDir = dir.x;

        //xDir = Mathf.Clamp(xDir, leftWallTransform.position.x, rightWallTransform.position.x);
    }

    private void Update()
    {
        if (xDir == 0) return;
        
        if(transform.position.x + xDir > rightWallTransform.position.x) return;
        if(transform.position.x + xDir < leftWallTransform.position.x) return;

        transform.Translate(0, xDir * Time.deltaTime * speed, 0);
    }
}