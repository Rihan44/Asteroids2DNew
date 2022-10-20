using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    public GameObject particulaAsteroide;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        //particulaAsteroide = GetComponent<GameObject>();

    }

    void Update()
    {
        
    }

    public void DestruyeBala()
    {
        GameObject particulasAsteroid = Instantiate(particulaAsteroide, transform.position, transform.rotation);
        Destroy(particulasAsteroid, 2.5f);
        Destroy(gameObject);
    }


}
