using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("dashing")]
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash;
    // Start is called before the first frame update
    void Start()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var dir = new Vector2(x, y);

        
    }


    // Update is called once per frame
    void Update()
    {
        var dashInput = Input.GetButtonDown("Dash");
        if (dashInput && canDash)
        {
            isDashing = true;
            canDash = false;
            //rigidbody.velocity = dir * dashVelocity;
        }
    }
}
