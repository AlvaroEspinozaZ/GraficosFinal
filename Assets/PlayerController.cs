using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;
    private Rigidbody _rgb;
    public GameObject _direction;
    public Vector2 directionPlayer;
    public float walkPlayer;
    public float runPlayer;
    public float forceJumpaPlayer;
    public float RaycastPlayer;
    public bool _isJump;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _rgb = GetComponent<Rigidbody>();
        runPlayer = 1;
        walkPlayer = 1;
        _isJump = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 tmp = new Vector3(_direction.transform.position.x - transform.position.x, _rgb.velocity.y, _direction.transform.position.z - transform.position.z);      
        _rgb.velocity = tmp  *walkPlayer * runPlayer * directionPlayer.x;

        _animator.SetFloat("Speed", directionPlayer.magnitude * walkPlayer *runPlayer);
        
    }
   
    public void onMovementPlayer(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            directionPlayer = value.ReadValue<Vector2>();
            walkPlayer = 2;
            transform.Rotate(Vector3.up, 45 * directionPlayer.y);
        }
        else
        {
            directionPlayer = Vector2.zero;
            walkPlayer = 1;
        }      
    }

    public void onJumpPlayer(InputAction.CallbackContext value)
    {
        if (value.started&& IsFloor())
        {
            _rgb.velocity = new Vector3(_rgb.velocity.x, forceJumpaPlayer, _rgb.velocity.z); 
            _animator.SetTrigger("Jump");
            if (IsFloor())
            {
                _animator.SetBool("OnAir", false);
            }
        }
       
    }
    public void onRunPlayer(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            
            runPlayer = 3;
        }
        else
        {
            runPlayer =1;
        }
    }

    bool IsFloor()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = Vector3.down;

        if (Physics.Raycast(rayOrigin, rayDirection, RaycastPlayer))
        {
            Debug.Log(" El personaje está en el suelo");
            return true;
        }
        else
        {
            Debug.Log(" El personaje está en el aire"); 
            return false;
        }
    }
}
