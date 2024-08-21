using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behaviour : Enemy{
    [Header("Otros Par�metros")]
    public Transform jugador;
    public LayerMask capaJugador;
    private int movimiento;
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;
    //public AudioSource controlSonido;
    public AudioClip attackSound;
    //[SerializeField] private CharacterData enemy;
    //[SerializeField] private EnemyData enemyData;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Accion();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /*void Update()
    {
        //enemyData.IsAlert = Physics2D.OverlapCircle(transform.position, enemyData.DetectionRange, capaJugador);

        if (!enemyData.IsAlert)
        {
            ManejarMovimientoNormal();
        }
        else
        {
            ManejarPersecucionJugador();
        }
    }*/

    public void ManejarMovimientoNormal()
    {
        chara.IsAttacking = false;

        if (chara.IsWalking)
        {
            rb.velocity = direccionMovimiento * chara.MoveSpeed;
            chara.IsWalking = true;
        }
        else if (chara.IsWaiting)
        {
            rb.velocity = Vector2.zero;
            chara.IsWalking = false;
        }
        else if (chara.IsTurning)
        {
            CambiarDireccion();
        }
    }

    public void ManejarPersecucionJugador()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);


        if (distanciaAlJugador > 4f)
        {
            PerseguirJugador();
        }
        else
        {
            AtacarJugador();
        }
    }

    void PerseguirJugador()
    {
        chara.IsAttacking = false;
        chara.IsWaiting = false;
        if (transform.position.x < jugador.transform.position.x)
        {
            chara.IsTurning = false;
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * chara.RunSpeed;
            chara.IsWalking = true;
        }
        else
        {
            chara.IsTurning = true;
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * chara.RunSpeed;
            chara.IsWalking = true;
        }
    }

    void AtacarJugador()
    {
        rb.velocity = Vector2.zero;
        chara.IsWalking = false;
        chara.IsAttacking = true;
        if(chara.IsAttacking && !controlSonido.isPlaying) controlSonido.PlayOneShot(attackSound);
    }
    void CambiarDireccion()
    {
        // Cambiar la direcci�n de movimiento a una direcci�n aleatoria
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = direccionMovimiento * chara.MoveSpeed;
    }
    public void FinalAnimacion()
    {
        chara.IsAttacking = false;
    }

    void Accion()
    {
        movimiento = Random.Range(1, 4);

        chara.IsWalking = movimiento == 1;
        chara.IsWaiting = movimiento == 2;
        chara.IsTurning = movimiento == 3;

        /*if (chara.IsTurning)
        {
            StartCoroutine(TiempoGiro());
        }*/

        Invoke("Accion", enemy.ReactionTime);
    }

    IEnumerator TiempoGiro()
    {
        yield return new WaitForSeconds(2);
        chara.IsTurning = false;
    }
    public void Morir()
    {
        chara.IsWalking = false;
        chara.IsAttacking = false;

    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, enemyData.DetectionRange);
    }*/
}
