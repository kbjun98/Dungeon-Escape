using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private bool grounded=false;
    private float jumpForce=5.0f;
    [SerializeField]
    private LayerMask groundLayerMask;
    [SerializeField]
    private float speed;
    private bool _resetJump=true;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    private Vector2 _swordArcInitialLocation;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation= GetComponent<PlayerAnimation>();
        _playerSprite= GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite= transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        _swordArcInitialLocation = _swordArcSprite.transform.localPosition;
    }

    void Update()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0)&&grounded)
        {
            _playerAnimation.Attack();
        }
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        Flip(move);
        grounded = isGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            _playerAnimation.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);
        _playerAnimation.Move(move);
    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            _swordArcSprite.transform.localPosition = _swordArcInitialLocation;
        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector2 leftSwordLocation = _swordArcInitialLocation;
            leftSwordLocation.x = -_swordArcInitialLocation.x;
            _swordArcSprite.transform.localPosition = leftSwordLocation; 
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump= false;
        yield return new WaitForSeconds(0.1f);
        _resetJump= true;
    }

    private bool isGrounded()
    {

        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (groundCheck.collider != null)
        {
            if(_resetJump==true)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }
}
