using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcion = direcion * Random.Range(speed_min, speed_max);
        rb.AddForce(direcion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
