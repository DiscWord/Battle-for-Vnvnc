using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _WalkDistance  = 6f;
    [SerializeField] private float _WalkSpeed = 1f;
    [SerializeField] private float _timeToWait = 5f;
    
    
    private Rigidbody2D _rb;
    private Vector2 _leftBounderyPosition;
    private Vector2 _rightBounderyPosition;
    [SerializeField] private Animator _animator;
    

    private bool _isfacingright = true;
    private bool _isWait = false;
    private float _TimeWait;
    private void Start() 
    {
        _TimeWait = _timeToWait;
        _rb = GetComponent<Rigidbody2D>();
        _leftBounderyPosition = transform.position;
        _rightBounderyPosition = _leftBounderyPosition + Vector2.right * _WalkDistance;
    }
    private void Update()
    {
        if (CheckWait())
        {
            _isWait = true;
        }

        if (_isWait)
        {
            Wait();
        }
        
    }

    private void FixedUpdate()
    {
        
      Vector2 nextPoint = Vector2.right * _WalkSpeed * Time.fixedDeltaTime;
      if (!_isfacingright) 
      {
          nextPoint.x *= -1;
      }
      if (!_isWait) 
      {
        _rb.MovePosition((Vector2)transform.position + nextPoint);
        _animator.SetFloat("MovingBlend", 0.3f);
      }

      if(_isWait)
      {
          _animator.SetFloat("MovingBlend", 0f);
      }

    }
    private void Wait () 
    {
         _TimeWait -= Time.deltaTime;
            if(_TimeWait < 0f)
            {
                _TimeWait = _timeToWait;
                _isWait = false;
                Flip();
            }
    }
    private bool CheckWait()
    {
        bool isRightOutBoundery = _isfacingright && transform.position.x >= _rightBounderyPosition.x;
        bool isLeftOutBoundery = !_isfacingright && transform.position.x <= _leftBounderyPosition.x;

        return isRightOutBoundery || isLeftOutBoundery;

    }
    void Flip()
    {
            _isfacingright = !_isfacingright;
            Vector3 PlayerScale = transform.localScale;
            PlayerScale.x *= -1;
            transform.localScale = PlayerScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBounderyPosition,_rightBounderyPosition);
    }

}
