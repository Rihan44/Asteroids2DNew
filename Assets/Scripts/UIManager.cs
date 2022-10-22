using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instancia;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI points;
    public TextMeshProUGUI life;
    public TextMeshProUGUI paused;
    public TextMeshProUGUI death;
   // public TextMeshProUGUI start;
    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        paused.gameObject.SetActive(false);
        death.gameObject.SetActive(false);
        //life.text = "0";
    }

    void Update()
    {
        textoTiempo.text = Time.time.ToString("00.00");
        points.text = GameManager.instancia.puntuacion.ToString();
        //life.text = GameManager.instancia.vidas.ToString();

        if(GameManager.instancia.vidas < 0)
        {
            death.gameObject.SetActive(true);
            //life.text = "0";
        }
    }
}
