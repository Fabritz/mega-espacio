using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAenemiga : MonoBehaviour
{
    ConfigOleada oleada;
    float velocidad;
    List<Transform> objetivos;
    int posicion = 0;

    // Start is called before the first frame update
    void Start()
    {
        objetivos = oleada.ConseguirObjetivos();
        velocidad = oleada.ConseguirVelocidadEnemiga();
        transform.position = objetivos[posicion].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    public void AgregarOleada(ConfigOleada oleada)
    {
        this.oleada = oleada;
    }

    private void Mover()
    {
        if (posicion <= objetivos.Count - 1)
        {
            var posicionObjetivo = objetivos[posicion].transform.position;
            var movimiento = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, movimiento);
            if (transform.position == posicionObjetivo)
            {
                posicion++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
