using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10.0f; //multiplier for faster movement
    
    private float _moveHorizontal = 0.0f;
    private float _moveVertical = 0.0f;
    [SerializeField]
    private float _jumpForce = 0.0f; //controling jumping height/force
   
    private bool _isGrounded = false; //is Player grounded?
    private bool _jump = false;
    private bool _doubleJump = true; //is Player able to double jump?

    private Rigidbody _rigidbody;

    void Awake()
    {
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForInput();

        if (_jump && (_isGrounded || _doubleJump))
        {
            Jump();
        }

    }

    void CheckForInput()
    {
        _moveHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal"); //move on X axis
        _moveVertical = CrossPlatformInputManager.GetAxisRaw("Vertical"); // move on Z axis
        _jump = CrossPlatformInputManager.GetButtonDown("Jump"); // move on Y axis

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        _rigidbody.AddForce(direction * Speed);
    }

    void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z); //reset velocity on Y axis to normalize in case of double jump
        _rigidbody.AddForce(Vector3.up * _jumpForce * 100); 

        if(!_isGrounded)
        {
            _doubleJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            _isGrounded = true; 
            _doubleJump = true; //reset double jump ability
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = false;
        } 
    }
}
