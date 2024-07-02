using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Behaviour : MonoBehaviour
{
    [Header("Parámetros de Movimiento")]
    public float velMovimiento;
    public float tiempoReaccion = 0.8f;
    public float velocidad = 3f;
    public float rangoAlerta;

    [Header("Estados de Movimiento")]
    public bool espera, camina, gira, estarAlerta;

    [Header("Otros Parámetros")]
    public Transform jugador;
    public LayerMask capaJugador;
    [SerializeField] private CharacterData enemy;
    private int movimiento;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;
    public bool tiempoEspera = true;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Accion();
    }

    void Update()
    {
        estarAlerta = Physics2D.OverlapCircle(transform.position, rangoAlerta, capaJugador);

        if (!estarAlerta)
        {
            ManejarMovimientoNormal();
        }
        else
        {
            ManejarPersecucionJugador();
        }
    }

    void ManejarMovimientoNormal()
    {
        enemy.IsAttacking = false;

        if (espera)
        {
            rb.velocity = Vector2.zero;
            enemy.IsWalking = false;
        }
        else if (gira)
        {
            CambiarDireccion();
        }
    }

    void ManejarPersecucionJugador()
    {
        if (tiempoEspera)
        {
            animator.SetBool("spawn", true);
            enemy.IsWaiting = true;
            StartCoroutine(TiempoEspera());
            

        }
        else
        {
            
            
            float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);


            if (distanciaAlJugador > 2f)
            {
                PerseguirJugador();
            }
            else
            {
                AtacarJugador();
            }
        }
    }
    IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(1);
        tiempoEspera = false;
    }
    void PerseguirJugador()
    {
        enemy.IsAttacking = false;
        if (transform.position.x < jugador.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * velocidad;
            enemy.IsWalking = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * velocidad;
            enemy.IsWalking = true;
        }


    }

    void AtacarJugador()
    {
        rb.velocity = Vector2.zero;
        enemy.IsWalking = false;
        enemy.IsAttacking = true;
        //animator.SetBool("walk", false);
        //animator.SetBool("attack", true);
    }
    void CambiarDireccion()
    {
        // Cambiar la dirección de movimiento a una dirección aleatoria
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = direccionMovimiento * velMovimiento;
    }

    void Accion()
    {
        movimiento = Random.Range(1, 2);
        //camina = movimiento == 1;
        espera = movimiento == 1;
        gira = movimiento == 2;

        if (gira)
        {
            StartCoroutine(TiempoGiro());
        }

        Invoke("Accion", tiempoReaccion);
    }

    IEnumerator TiempoGiro()
    {
        yield return new WaitForSeconds(2);
        gira = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }
}
