using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    public Vector3 posicionInicial;
    public int attempts = 3;

    private void Start()
    {
        posicionInicial = transform.position;
    }
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }

}
