using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    Dino dino;
    SpawnInimigo spawnInimigo;
    MovementoDoChao movementoDoChao;

    public GameObject telaGameOver;

    bool gameOver = false;


    float dificuldadeDoJogo = 0f;
    float intervalo = 5f;


    public Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        dino = FindObjectOfType<Dino>();
        spawnInimigo = FindObjectOfType<SpawnInimigo>();
        movementoDoChao = FindObjectOfType<MovementoDoChao>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("Inimigo")).Length > 0)
            {
                gameOver = true;

                spawnInimigo.stopSpawn = true;
                movementoDoChao.velocidade = 0;
                Cacto[] cactos = FindObjectsOfType<Cacto>();
                Time.timeScale = 0;
                Arma.pararArma();
                foreach (Cacto c in cactos)
                {
                    c.velocidade = 0;
                }
            }

            if(Time.time >= dificuldadeDoJogo)
            {
                movementoDoChao.velocidade += 0.2f;
                spawnInimigo.velocidade += 0.2f;

                score += 100;
                scoreText.text = score.ToString("D6");
                dificuldadeDoJogo = Time.time + intervalo;
            }
        }
        else
        {
            telaGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("CenaJogo"); 
            }
        }
    }
}
