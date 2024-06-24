using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeDamege : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colisiona es un enemigo
        if (other.CompareTag("Enemy"))
        {
            // Obtén el componente EnemyController2D del objeto enemigo
            golemMovement enemy = other.GetComponent<golemMovement>();

            // Si se encontró el componente EnemyController2D, aplica el daño
            if (enemy != null)
            {
                enemy.TakeDamegeEnemy(damage);
                Debug.Log("GOlPEYO");
            }

            SkeletonBehaviour enemy2 = other.GetComponent<SkeletonBehaviour>();
            if (enemy2 != null)
            {
                enemy2.TakeDamegeEnemy(damage);
                Debug.Log("GOlPEYO");
            }
        }
    }
}
