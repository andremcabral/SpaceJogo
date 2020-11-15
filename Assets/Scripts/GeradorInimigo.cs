using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    public GameObject[] inimigoPrefabs;

    public float delay;
    
    public float delayEntre;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GerarInimigo",delay,delayEntre);
    }

    // Update is called once per frame
    void GerarInimigo()
    {
        var quantidadeInimigos = inimigoPrefabs.Length;
        var indiceAleatorio = Random.Range(0,quantidadeInimigos);
        var inimigoPrefab = inimigoPrefabs[indiceAleatorio];
        Instantiate(inimigoPrefab,transform.position, Quaternion.identity);
        
    }

}
