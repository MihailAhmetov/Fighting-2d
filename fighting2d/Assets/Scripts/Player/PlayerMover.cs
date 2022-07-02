using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 4.5f;
    [SerializeField] private float _checkRadius = 0.5f;

    [SerializeField] private Transform _groundPoint;
    [SerializeField] LayerMask _groundLayer;

    private bool _facingRight;
    private bool _isGrounded;
    private float _xInput;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();

        if (_player.WasdPlayer)
            _facingRight = true;
        else
            _facingRight = false;
    }

    private void Update()
    {   
            GroundCheck();

            if (_player.WasdPlayer)
                _xInput = Input.GetAxis("Horizontal1");
            else
                _xInput = Input.GetAxis("Horizontal2");

            if (_facingRight && _xInput < 0)
                Flip();
            else if (!_facingRight && _xInput > 0)
                Flip();
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, _checkRadius, _groundLayer);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Move()
    {
        if (_xInput == 0)
            _animator.SetBool("Running", false);
        else
            _animator.SetBool("Running", true);

        _rigidbody.velocity = new Vector2(_xInput * _speed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _animator.SetTrigger("Jump");
            _rigidbody.velocity = Vector3.up * _jumpForce;
        }
    }
}
