using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControler : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    Rigidbody2D rb;
    private SoundManager soundManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcion = direcion * Random.Range(speed_min, speed_max);
        rb.AddForce(direcion);
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundManager.SeleccionaAudio(4, 0.5f);
            GameManager.instancia.vidas += 1; ;
            Destroy(gameObject);
        }
    }
}
