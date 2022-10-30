using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndroidController : BasePlayerController
{
    public Rigidbody Rigidbody;
    public float HorizontalSpeed;

    private void Start()
    {
        base.Start();
        _sideSpeed = 0;
    }
    private void FixedUpdate()
    {
        var direction = _sideSpeed * Time.fixedDeltaTime;

        if (direction == 0f) return;
        Rigidbody.position += direction * transform.right;
    }

    public void LeftButtonDown()
    {
        _sideSpeed = -HorizontalSpeed;
    }
    
    public void RightButtonDown()
    {
        _sideSpeed = HorizontalSpeed;
    }

    public void Stop()
    {
        _sideSpeed = 0;
    }

    public void WantJump()
    {
        Jump();
    }
}