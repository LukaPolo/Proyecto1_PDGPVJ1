using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class golemMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public makeDamege makeDamege;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    private Transform currentPosition;
    public float minDistance;
    public GameObject target;
    public float visionRange;
    public float speedPatrol = 1.0f;
    private Animator anim;
    Vector2 flipSrpite = new Vector2(-1, 1);
    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        currentPosition = pointA;
        anim = GetComponent<Animator>();
        target = GameObject.Find("player");
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToPlayer = (target.transform.position - transform.position).magnitude;
        if (DistanceToPlayer > minDistance)
        {
            anim.SetBool("IsAttack", false);
               anim.SetBool("IsWalk", true);
                transform.position = Vector2.MoveTowards(transform.position, currentPosition.position, speedPatrol * Time.deltaTime);
                if (transform.position == pointA.position)
                {
                   // transform.localScale *= flipSrpite;
                    currentPosition = pointB;
                }
                
                if (transform.position == pointB.position)
                {
                   // transform.localScale *= flipSrpite;
                    currentPosition = pointA;
                }
                /*
                if (transform.position == pointC.position)
                {
                    //transform.localScale *= flipSrpite;
                    currentPosition = pointD;
                }
                if (transform.position == pointD.position)
                {
                    transform.localScale *= flipSrpite;
                    currentPosition = pointA;
                }**/
        }
        else
        {       
                
            if (transform.position.x < target.transform.position.x)
            {
                //anim.SetBool("IsWalk", false);
                anim.SetBool("IsAttack", true);
               // anim.SetBool("Hit", false);
                // transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else
            {
                //anim.SetBool("IsWalk", false);
                anim.SetBool("IsAttack", true);
               // anim.SetBool("Hit", false);
                //transform.rotation = Quaternion.Euler(0, 180, 0);

            }
        }
     
   }
    public void TakeDamegeEnemy(int damage)
    {
        currentHealth -= damage;
        anim.SetBool("IsAttack", false);
        anim.SetBool("Hit", true);

        if (Time.time >= 1f)
        {
            anim.SetBool("Hit", false);
        }
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("murio");
        }

    }
    void Die()
    {
        anim.SetBool("IsAttack", false);
        anim.SetBool("Hit", true);
        anim.SetTrigger("Dead");       
        //GetComponent<Collider2D>().enabled = false;
       // this.enabled = false;

        Destroy(gameObject, 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            // Restar vida al jugador         
            Debug.Log("golpe");
        }
    }

}
