using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoVoador : MonoBehaviour
{

    public float velocidade;

    public ParticleSystem explosaoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D collider = Physics2D.OverlapBox(transform.position, Vector2.one * 0.2f, 0, LayerMask.GetMask("Tiro"));

        if(collider != null)
        {
            Destroy(Instantiate(explosaoPrefab, transform.position, Quaternion.identity), 2f);
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        transform.position += Vector3.left * velocidade * Time.deltaTime;
        if(transform.position.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
