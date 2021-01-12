using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementoDoChao : MonoBehaviour
{
    public SpriteRenderer[] chaos;
    public float velocidade;

    Vector2 fimPosicao = new Vector2(-5.58f, -1.7f);
    Vector2 posicaoInicial = new Vector2(6.301f, -1.7f) ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < chaos.Length; i++)
        {
            chaos[i].transform.position += Vector3.left * velocidade * Time.deltaTime;

            if(chaos[i].transform.position.x <= fimPosicao.x)
            {
                chaos[i].transform.position = posicaoInicial;
                chaos[i].sprite = chaos[Random.Range(0, chaos.Length)].sprite;
            }
        }
    }
}
