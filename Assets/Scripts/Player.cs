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
        }
        else
        {
            _jumpVelocity -= _gravity;
        }

        direction.y = _jumpVelocity;

        _controller.Move(direction * Time.deltaTime);
    }
}
