using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] float vida = 200f;
    [SerializeField] float contador;
    [SerializeField] float tiempoMinDisparo = 0.1f;
    [SerializeField] float tiempoMaxDisparo = 1.3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float velocidadLaser = 20f;


    private void Start()
    {
        contador = Random.Range(tiempoMinDisparo, tiempoMaxDisparo);
    }
    private void Update()
    {
        ContarParaDisparar();
    }

    private void ContarParaDisparar()
    {
        contador -= Time.deltaTime;
        if (contador <= 0)
        {
            Disparar();
            contador = Random.Range(tiempoMinDisparo, tiempoMaxDisparo);
        }
    }

    private void Disparar()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadLaser);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HacerDano enemigo = collision.gameObject.GetComponent<HacerDano>();
        if (!enemigo) { return; }
        vida -= enemigo.ConseguirDano();
        enemigo.Hit();
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
