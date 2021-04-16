using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float WalkDistance  = 6f;
    [SerializeField] private float WalkSpeed = 1f;
    [SerializeField] private float TimeWait = 5f;

    private Rigidbody2D rb;
    private Vector2 leftBounderyPosition;
    private Vector2 rightBounderyPosition;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        leftBounderyPosition = transform.position;
        rightBounderyPosition = leftBounderyPosition + Vector2.right * WalkDistance;
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + Vector2.right * WalkSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftBounderyPosition,rightBounderyPosition);
    }

}
