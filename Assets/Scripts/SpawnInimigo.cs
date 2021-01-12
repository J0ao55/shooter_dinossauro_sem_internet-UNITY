using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    struct spawnTempo
    {
        public float intervalo;// segundos
        public float instanciaTempo;
        public float intervaloVariacao;
    }


    public Sprite[] cactusSprite;
    public GameObject cactusPrefab;
    public GameObject dinoVoadorPrefab;

    spawnTempo cacto;
    spawnTempo dinoVoador;

    float alturaMxima = 0.45f;
    float alturaMinima = -1.16f;

    public bool stopSpawn = false;


    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        cacto.instanciaTempo = 0f; 
        cacto.intervalo = 2f;
        cacto.instanciaTempo = 0.5f;

        dinoVoador.instanciaTempo = 0f;
        dinoVoador.intervalo = 2f;
        dinoVoador.instanciaTempo = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > cacto.instanciaTempo && !stopSpawn)
        {
            GameObject obj =  Instantiate(cactusPrefab, new Vector3(5, -1.721929f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprite[Random.Range(0, cactusSprite.Length)];
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<Cacto>().velocidade = velocidade;
            cacto.instanciaTempo = Time.time + Random.Range(cacto.intervalo - cacto.intervaloVariacao, cacto.intervalo + cacto.intervaloVariacao);
        }

        if (Time.time > dinoVoador.instanciaTempo && !stopSpawn)
        {
            GameObject obj = Instantiate(dinoVoadorPrefab, new Vector3(5, -Random.Range(alturaMinima,alturaMxima)), Quaternion.identity);
            obj.GetComponent<DinoVoador>().velocidade += 0.2f;
            dinoVoador.instanciaTempo = Time.time + Random.Range(dinoVoador.intervalo - dinoVoador.intervaloVariacao, dinoVoador.intervalo + dinoVoador.intervaloVariacao);
        }
    }
}
