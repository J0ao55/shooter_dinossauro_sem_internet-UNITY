using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour
{

    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("esperar");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidade * Time.deltaTime; 
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(gameObject, new Vector3(5, Random.Range(0.01f, 2.22f)), transform.rotation);
        Destroy(gameObject, 2f);
    }
}
