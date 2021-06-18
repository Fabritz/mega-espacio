using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<ConfigOleada> oleadas;
    [SerializeField] int primeraOleada = 0;
    [SerializeField] bool loop = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnearOleadas());
        }
        while (loop);
        
    }

    private IEnumerator SpawnearOleadas()
    {
        for(int oleada = primeraOleada; oleada < oleadas.Count; oleada++)
        {
            var oleadaActual = oleadas[oleada];
            yield return StartCoroutine(SpawnearEnemigos(oleadaActual));
        }
    }

    private IEnumerator SpawnearEnemigos(ConfigOleada oleada)
    {
        for (int i=0; i<oleada.ConseguirNumeroDeEnemigos();i++)
        {
            var nuevoEnemigo = Instantiate(oleada.ConseguirTipoEnemigo(), 
                oleada.ConseguirObjetivos()[0].transform.position,
                Quaternion.identity);
            nuevoEnemigo.GetComponent<IAenemiga>().AgregarOleada(oleada);
            yield return new WaitForSeconds(oleada.ConseguirVelocidadAparicion());
        }
            
    }

}
