using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instancia;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI points;
    public TextMeshProUGUI paused;
    public TextMeshProUGUI death;
    public TextMeshProUGUI win;
    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        paused.gameObject.SetActive(false);
        death.gameObject.SetActive(false);
    }

    void Update()
    {
        textoTiempo.text = Time.time.ToString("00.00");
        points.text = GameManager.instancia.puntuacion.ToString();

        if(GameManager.instancia.vidas < 0)
        {
            death.gameObject.SetActive(true);
        }

        if(GameManager.instancia.puntuacion >= 250)
        {
            win.gameObject.SetActive(true);
        }
    }
}
