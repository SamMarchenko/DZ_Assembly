using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BasePlayerController : MonoBehaviour
{
    protected Rigidbody _rigidBody;
    [SerializeField] protected float _sideSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _forwardSpeed = 10f;
    public float ForwardSpeed
    {
        get => _forwardSpeed;
        set => _forwardSpeed = value;
    }

    private bool _canJump = true;

    protected virtual void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            _rigidBody.position += transform.forward * (_forwardSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    protected void Jump()
    {
        if (!_canJump) return;
        _rigidBody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        _canJump = false;
    }

    private void OnCollisionStay(Collision other)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _canJump = false;
    }
}
