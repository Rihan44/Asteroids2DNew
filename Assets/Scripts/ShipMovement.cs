using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    public float speed = 70f;
    public float speedRotate = -100f;
    public int life = 4;

    Rigidbody2D rb2d;
    Animator anim;
    public GameObject bala;
    public GameObject bala2;
    public GameObject destructor1;
    public GameObject shield;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent dice que en el objeto actual tengo x componentes y quiero buscar en este caso el que esta entre <> en este caso RigiBody
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        // Este if evita que no puedas ir marcha atrás
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

        Posicion();

        if (GameManager.instancia.vidas < 1)
        {
            ShieldGenerator.GeneradorEscudo(shield);
        }

        if (GameManager.instancia.vidas < 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            UIManager.instancia.death.gameObject.SetActive(true);
        }
    }
}
