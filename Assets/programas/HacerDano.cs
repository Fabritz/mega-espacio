using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDano : MonoBehaviour
{
    [SerializeField] int dano = 100;
    public int ConseguirDano()
    {
        return dano;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
