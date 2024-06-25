using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    int amount = 10;

    private void OnTriggerEnter(Collider other)
    {
         
        if (other.tag == "Character")
        {
            other.GetComponent<Character>().TakeDamage(amount);
            Debug.Log("hiciste"+amount+"de daño");
        }
    }
}
