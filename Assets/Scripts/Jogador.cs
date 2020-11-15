using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Jogador : MonoBehaviour
{
    public float velocidade = 2f;

    private float pontos;

    public float multiplicaPontos = 1;
    
    public Text pontosText;

    public BoxCollider2D areaJogo;

    // Start is called before the first frame update
    void Start()
    {
        print(areaJogo.bounds.extents);
    }

    // Update is called once per frame
    void Update()
    {
        pontos += Time.deltaTime * multiplicaPontos;

        pontosText.text=$"Pontos: {Mathf.FloorToInt(pontos)}";

        // Movimentação do Jogador
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(horizontal, vertical) * velocidade * Time.deltaTime);

        // Garantir que o jogador está dentro da área de jogo

        var position = areaJogo.transform.position;
        var extents = areaJogo.bounds.extents;
        var offset = areaJogo.offset;

        var limiteXMin = -extents.x + position.x + offset.x * 2.5f;
        var limiteXMax = extents.x + position.x + offset.x * 2.5f;

        var limiteYMin = -extents.y + position.y + offset.y * 2.5f;
        var limiteYMax = extents.y + position.y + offset.y * 2.5f;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, limiteXMin, limiteXMax),
            Mathf.Clamp(transform.position.y, limiteYMin, limiteYMax)
        );
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Atingido"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
