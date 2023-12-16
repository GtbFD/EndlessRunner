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
    
    public LayerMask layerMask;

    private bool isMovingLeft;
    private bool isMovingRight;

    public Animator anim;
    public bool isDead;

    private GameController gameOver;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        gameOver = FindObjectOfType<GameController>();
    }


    void Update()
    {
        OnCollision();
        
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
    
        if (!isDead){
            _controller.Move(direction * Time.deltaTime);
        }
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

    void OnCollision()
    {
        RaycastHit hit;
        
        var originPoint = transform.position;
        var diretionPoint = transform.TransformDirection(Vector3.forward);
        var distance = 2f;
            
        if (Physics.Raycast(originPoint, diretionPoint, out hit, distance, layerMask)
            && !isDead)
        {
            //Debug.Log("Bateu!");
            anim.SetTrigger("die");
            _speed = 0;
            _jumpHeight = 0;
            horizontalSpeed = 0;
            isDead = true;
            Invoke("GameOver", 1f);
            
        }
    }

    void GameOver()
    {
        gameOver.ShowGameOver();
    }
}
