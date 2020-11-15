using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade;
    public Vector2 direcao;

    void Update()
    {
        transform.Translate(velocidade * direcao * Time.deltaTime);
    }
}
