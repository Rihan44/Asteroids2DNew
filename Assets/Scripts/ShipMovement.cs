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
    public GameObject particulaEscudo;
    bool muerto = true;

    private SoundManager soundManager;


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
        if (muerto)
        {
            float vertical = Input.GetAxis("Vertical");

            if(Input.GetKeyDown(KeyCode.W))
            {
                soundManager.SeleccionaAudio(2, 0.3f);
            }

            // Este if evita que no puedas ir marcha atr�s
            if (vertical > 0)
            {
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

    }

    public void Posicion()
    {
        transform.position = new Vector3(0, 0, 0);
        rb2d.velocity = new Vector2(0, 0);
    }

    public void Death()
    {
        GameManager.instancia.vidas -= 1;
        if (GameManager.instancia.vidas >= 0)
        {
            soundManager.SeleccionaAudio(3, 0.5f);
        }

        GameObject particulaShield = Instantiate(particulaEscudo, transform.position, transform.rotation);
        Destroy(particulaShield, 2.5f);

        Posicion();

        StartCoroutine(Respawn_Coroutine());

        if (GameManager.instancia.vidas < 1)
        {
            ShieldGenerator.GeneradorEscudo(shield);
        }

    }

    IEnumerator Respawn_Coroutine()
    {
        // Antes de que se espere
        muerto = false;
        col.enabled = false;
        sprite.enabled = false;
        if (GameManager.instancia.vidas < 0)
        {
            soundManager.SeleccionaAudio(2, 0.5f);
        }
        yield return new WaitForSeconds(1.5f);

        // Después de la espera
        col.enabled = true;
        sprite.enabled = true;
        muerto = true;

        if (GameManager.instancia.vidas < 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
