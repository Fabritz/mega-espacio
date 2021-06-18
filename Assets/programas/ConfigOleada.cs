using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuracion de oleada enemiga")]
public class ConfigOleada : ScriptableObject
{
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject camino;
    [SerializeField] float velocidadAparicion = 0.5f;
    [SerializeField] float aparicionesaleatorias = 0.3f;
    [SerializeField] int numeroDeEnemigos = 5;
    [SerializeField] float velocidadEnemigo;

    public GameObject ConseguirTipoEnemigo() { return enemigo;  }
    public List<Transform> ConseguirObjetivos() {
        var objetivos = new List<Transform>();
        foreach(Transform child in camino.transform)
        {
            objetivos.Add(child);
        }
        return objetivos; 
    }
    public float ConseguirVelocidadAparicion() { return velocidadAparicion; }
    public float ConseguirAparicionesAleatorias() { return aparicionesaleatorias; }
    public int ConseguirNumeroDeEnemigos() { return numeroDeEnemigos; }
    public float ConseguirVelocidadEnemiga() { return velocidadEnemigo; }


}
