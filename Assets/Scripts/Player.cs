using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;
    public float _speed;
    public float _jumpHeight;
    private float _jumpVelocity;
    public float _gravity;
    public float horizontalSpeed;

    private bool isMovingLeft;
    private bool isMovingRight;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        var direction = Vector3.forward * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpVelocity = _jumpHeight;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) 
                && transform.position.x < 5.3f && !isMovingRight)
            {
                isMovingRight = true;
                StartCoroutine(RightMove());
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow)
                && transform.position.x > -5.3f && !isMovingLeft)
            {
                isMovingLeft = true;
                StartCoroutine(LeftMove());
            }
        }
        else
        {
            _jumpVelocity -= _gravity;
        }

        direction.y = _jumpVelocity;

        _controller.Move(direction * Time.deltaTime);
    }

    IEnumerator LeftMove()
    {
        for (float i = 0; i < 10; i += 0.1f)
        {
            _controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingLeft = false;
    }

    IEnumerator RightMove()
    {
        for (float i = 0; i < 10; i += 0.1f)
        {
            _controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingRight = false;
    }
}
