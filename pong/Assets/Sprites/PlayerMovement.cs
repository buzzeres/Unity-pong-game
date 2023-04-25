using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove; // Fixed the variable name

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Fixed the capitalization of 'Rigidbody2D'
    }

    // Update is called once per frame
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1); // Fixed the variable name
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f) // Fixed the symbol and condition
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0); // Fixed the variable name
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }
}
