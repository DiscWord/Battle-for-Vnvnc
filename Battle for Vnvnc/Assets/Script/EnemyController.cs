using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _WalkDistance  = 6f;
    [SerializeField] private float _WalkSpeed = 1f;
    [SerializeField] private float _TimeWait = 5f;

    private Rigidbody2D _rb;
    private Vector2 _leftBounderyPosition;
    private Vector2 _rightBounderyPosition;

    private bool _isfacingright = true;
    private bool _isWait = false;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _leftBounderyPosition = transform.position;
        _rightBounderyPosition = _leftBounderyPosition + Vector2.right * _WalkDistance;
    }
    private void Update()
    {
        bool isRightOutBoundery = _isfacingright && transform.position.x >= _rightBounderyPosition.x;

        bool isLeftOutBoundery = !_isfacingright && transform.position.x <= _leftBounderyPosition.x;

        if (isRightOutBoundery || isLeftOutBoundery)
        {
            _isWait = true;
        }
    }

    private void FixedUpdate()
    {
      if (!_isWait) 
      {
        _rb.MovePosition((Vector2)transform.position + Vector2.right * _WalkSpeed * Time.fixedDeltaTime);
      }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBounderyPosition,_rightBounderyPosition);
    }

}
