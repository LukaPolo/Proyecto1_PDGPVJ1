using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] 
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    public Slider visualHealth;
    //public int attempts;
    //public Transform initialPos;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        visualHealth.GetComponent<Slider>().value = currentHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        CheckHealth();
    }
    public void CheckHealth()
    { 
        if (gameObject.name == "PlayerFinal")
        {
            if (currentHealth <= 0)
            {
                Debug.Log("has muerto");
                GetComponent<Player>().attempts -= 1;
                GetComponent<Player>().transform.position = GetComponent<Player>().posicionInicial;
                currentHealth = 100;
            }
            if (GetComponent<Player>().attempts <= 0)
            {
                Debug.Log("GAME OVER");
            }
        }
          else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
