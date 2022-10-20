using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    public float speed = 70f;
    public float speedRotate = -100f;
    public int life = 4;

    Rigidbody2D rb2d;
    Animator anim;
    PolygonCollider2D col;
    SpriteRenderer sprite;

    public GameObject bala;
    public GameObject bala2;
    public GameObject destructor1;
    public GameObject shield;
    private SoundManager soundManager;
    public GameObject particulaEscudo;


    void Start()
    {
        // GetComponent dice que en el objeto actual tengo x componentes y quiero buscar en este caso el que esta entre <> en este caso RigiBody
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
        col = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        // Este if evita que no puedas ir marcha atr�s
        if (vertical > 0)
        {
            //soundManager.SeleccionaAudio(1, 0.2f);
            rb2d.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing", true); // Aqui accedemos al parametro de la animacion 
        }
        else
        {
            anim.SetBool("impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 moveRote = new Vector3(0, 0, horizontal);
        transform.eulerAngles += moveRote * speedRotate * Time.deltaTime;

        // Disparos
        if (Input.GetButtonDown("Jump"))
        {
            soundManager.SeleccionaAudio(0, 0.2f);
            GameObject balaDestroy = Instantiate(bala, destructor1.transform.position, transform.rotation);
            Destroy(balaDestroy, 2.8f);
        }
    }

    public void Posicion()
    {
        transform.position = new Vector3(0, 0, 0);
        rb2d.velocity = new Vector2(0, 0);
    }

    public void Death()
    {
        GameManager.instancia.vidas -= 1;
        GameObject particulaShield = Instantiate(particulaEscudo, transform.position, transform.rotation);

        Destroy(particulaShield, 2.5f);

        Posicion();

        if(transform.position == new Vector3(0, 0, 0))
        {
            col.enabled = false;
        }

        col.enabled = true;

        if (GameManager.instancia.vidas < 1)
        {
            ShieldGenerator.GeneradorEscudo(shield);
        }

        if (GameManager.instancia.vidas < 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    // Esto es solo para cuando muera
    //IEnumerator Respawn_Coroutine()
    //{
    //    col.enabled = false;
    //    sprite.enabled = false;
    //    yield return new WaitForSeconds(2);
    //    col.enabled = true;
    //    sprite.enabled = true;

    //    Posicion();

    //    if (GameManager.instancia.vidas < 0)
    //    {
    //        Destroy(gameObject);
    //        Time.timeScale = 0;
    //        UIManager.instancia.death.gameObject.SetActive(true);
    //    }

    //}
}
