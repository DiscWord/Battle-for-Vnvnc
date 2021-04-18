using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    [SerializeField] private GameObject currentHitobject;

    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask; 

    private Vector2 origin;
    private Vector2 direction;
    private float currentHitDinstance;

    private void Update() 
    {
        origin = transform.position;
        origin.y = origin.y + 1.5f; // поднимаем райкаст на уровень глаз
        direction = Vector2.right;

        RaycastHit2D hit = Physics2D.CircleCast(origin,circleRadius,direction,maxDistance,layerMask);

        if (hit)
        {
            currentHitobject = hit.transform.gameObject;
            currentHitDinstance = hit.distance;
            if (currentHitobject.CompareTag("Player")) 
            {

            }
        }
        else 
        {
            currentHitobject = null;
            currentHitDinstance = maxDistance;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + direction *currentHitDinstance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDinstance,circleRadius);
    }
}
