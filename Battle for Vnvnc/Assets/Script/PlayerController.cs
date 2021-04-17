using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedx = 1f;
    [SerializeField] private float _Jump = 100f;
    [SerializeField] private Animator _animator;

    private bool _isfacingright = true;
    private float _horizontal = 0f;
    private bool _isGround = false;
    private bool _isJump = false;
    private Rigidbody2D rb;

    const float _speedMultiplier = 50f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal"); 
        _animator.SetFloat("MovingBlend", Mathf.Abs(_horizontal));

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _isJump = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(_horizontal *_speedx * _speedMultiplier * Time.deltaTime, rb.velocity.y);
    
        if(_isJump)
        {
            rb.AddForce(new Vector2(0f, _Jump * 5f));
            _isGround = false; 
            _isJump = false;
        }

        if (_horizontal > 0f && !_isfacingright) 
        {
            Flip();
        }
        else if (_horizontal < 0f && _isfacingright)
        {
            Flip();
        }
    }

    void Flip()
    {
            _isfacingright = !_isfacingright;
            Vector3 PlayerScale = transform.localScale;
            PlayerScale.x *= -1;
            transform.localScale = PlayerScale;
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
