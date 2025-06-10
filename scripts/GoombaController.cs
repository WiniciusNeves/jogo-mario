using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    private Rigidbody2D rbGoomba;
    private Animator animGoomba;
    private Player player;
    private Rigidbody2D playerRb;
    private Collider2D colliderGomb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform ponto1, ponto2;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask layer, playerLayer;
    [SerializeField] private float knockbackForce = 0.5f;
    [SerializeField] private Vector3 knockbackDirection = new Vector3(0, 1, -1);

    private bool isColliding;
    private bool playerCollide;
    private bool canFlip = true;

    private void Awake()
    {
        colliderGomb = GetComponent<Collider2D>();
        rbGoomba = GetComponent<Rigidbody2D>();
        animGoomba = GetComponent<Animator>();
        playerRb = GameObject.Find("Mario").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Mario").GetComponent<Player>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerCheck.position, playerLayer);
        if (hit.collider != null)
        {
            Debug.Log("Atingiu: " + hit.collider.name);
            Damage();
        }
    }

    private void FixedUpdate()
    {
        rbGoomba.velocity = new Vector2(speed, rbGoomba.velocity.y);
        isColliding = Physics2D.Linecast(ponto1.position, ponto2.position, layer);

        Debug.DrawLine(ponto1.position, ponto2.position, Color.blue);
        Debug.DrawLine(transform.position, playerCheck.position, Color.blue);

        if (isColliding && canFlip)
        {
            Flip();
        }
        else if (!isColliding)
        {
            canFlip = true;
        }

        if (animGoomba != null)
        {
            animGoomba.SetFloat("Speed", Mathf.Abs(speed));
        }
    }

    private void Flip()
    {
        speed *= -1;
        transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        canFlip = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layer) != 0)
        {
            Flip();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.Damage();

        }
    }

    private void Damage()
    {
        if (playerRb != null)
        {
            playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
        
        colliderGomb.enabled = false;
        rbGoomba.isKinematic = true;
        speed = 0;
        Destroy(this.gameObject, 2f);
    }
}
