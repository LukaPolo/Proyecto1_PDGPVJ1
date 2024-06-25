using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    private float activeMoveSpeed;
    [SerializeField] private float dashSpeed;
    private float dashLenght = .5f;
    private float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    [Header("Animation")]
    private Animator animator;
    public bool iddle, run, turnAround, attack, dash, death;
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb2d.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLenght;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
