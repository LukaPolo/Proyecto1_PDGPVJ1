using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behaviour : MonoBehaviour
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
    public int Dano = 10;
    public int vida = 100;

    private int movimiento;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;


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
        animator.SetBool("attack", false);

        if (camina)
        {
            rb.velocity = direccionMovimiento * velMovimiento;
            animator.SetBool("walk", true);
        }
        else if (espera)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("walk", false);
        }
        else if (gira)
        {
            CambiarDireccion();
        }
    }

    void ManejarPersecucionJugador()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);


        if (distanciaAlJugador > 3f)
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
        animator.SetBool("attack", false);
        if (transform.position.x < jugador.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * velocidad;
            animator.SetBool("walk", true);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.velocity = direccion * velocidad;
            animator.SetBool("walk", true);
        }


    }

    void AtacarJugador()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("walk", false);
        animator.SetBool("attack", true);
    }
    void CambiarDireccion()
    {
        // Cambiar la dirección de movimiento a una dirección aleatoria
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = direccionMovimiento * velMovimiento;
    }
    public void FinalAnimacion()
    {
        animator.SetBool("attack", false);
    }

    void Accion()
    {
        movimiento = Random.Range(1, 4);

        camina = movimiento == 1;
        espera = movimiento == 2;
        gira = movimiento == 3;

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

    public void TomarDano()
    {
        //animator.SetBool("hit", false);
        vida -= 10;
        if (vida <= 0)
        {
            animator.SetBool("dead", true);
            Destroy(gameObject, 1f);
        }
    }
    public void Morir()
    {
        animator.SetBool("attack", false);
        animator.SetBool("walk", false);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // other.GetComponent<BarraVida>().RecibirDano(Dano);
            Debug.Log("golpe");
            //animator.SetBool("hit", true);
            TomarDano();
        }
    }
}
