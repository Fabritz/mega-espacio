using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [Header("Jugador")]
    [SerializeField] float velocidadX = 10f;
    [SerializeField] float velocidadY = 10f;
    [SerializeField] float barrera = 1f;
    [SerializeField] int vida = 600;

    [Header("Laser")]
    [SerializeField] GameObject laser;
    [SerializeField] float velocidadLaser = 10f;
    [SerializeField] float tiempoDeRecarga = 0.5f;

    Coroutine corutinaDisparo;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        ArmarBarreras();
    }


    void Update()
    {
        Move();
        Fire();
    }


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            corutinaDisparo = StartCoroutine(DisparoSeguido());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(corutinaDisparo);
        }
    }

    IEnumerator DisparoSeguido()
    {
        while (true)
        {
            GameObject laserCopia = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserCopia.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadLaser);
            yield return new WaitForSeconds(tiempoDeRecarga);
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadX;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * velocidadY;


        float newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
    private void ArmarBarreras()
    {
        Camera camara = Camera.main;
        xMin = camara.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + barrera;
        xMax = camara.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - barrera;
        yMin = camara.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + barrera;
        yMax = camara.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - barrera;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HacerDano enemigo = collision.gameObject.GetComponent<HacerDano>();
        if(!enemigo) { return; }
        vida -= enemigo.ConseguirDano();
        enemigo.Hit();
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
