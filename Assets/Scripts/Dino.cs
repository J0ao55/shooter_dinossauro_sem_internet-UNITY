using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Vector2 yVelocity;

    float altura_maxima = 1f;
    float tempo_pico = 0.3f;

    float velocidade_pulo;
    float gravidade;

    float posicaoChao = 0f;
    bool noChao = false;
    // Start is called before the first frame update
    void Start()
    {
        gravidade = (2 * altura_maxima) / Mathf.Pow(tempo_pico, 2);
        velocidade_pulo = gravidade * tempo_pico;

        posicaoChao = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity += gravidade * Time.deltaTime * Vector2.down;

        if(transform.position.y <= posicaoChao)
        {
            transform.position = new Vector3(transform.position.x, posicaoChao, transform.position.z);
            yVelocity = Vector3.zero;
            noChao = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            yVelocity = velocidade_pulo * Vector2.up;
            noChao = false;
        }

        transform.position += (Vector3)yVelocity * Time.deltaTime;
         
    }
}
