using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    Camera cam;
    public GameObject tiroPrefab;
    public Transform pontoArma;

    public ParticleSystem muzzleFlash;
    public ParticleSystem capsule;

    float tiroIntervalo = 0.1f;
    float tiroInstanciaTempo = 0;

    Vector2 mousePosicao;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        cam = Camera.main;
        muzzleFlash.Stop();
        capsule.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale != 0)
        {
            mousePosicao = cam.ScreenToWorldPoint(Input.mousePosition);

            transform.right = (mousePosicao - (Vector2)transform.position).normalized;


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                capsule.Play();
                muzzleFlash.Play();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                capsule.Stop();
                muzzleFlash.Stop();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Time.time > tiroInstanciaTempo)
                {
                    Instantiate(tiroPrefab, pontoArma.position, pontoArma.rotation);
                    tiroInstanciaTempo = Time.time + tiroIntervalo;
                }
            }

        }   
    }

    public static void pararArma()
    {
        Time.timeScale = 0;
    }
}
