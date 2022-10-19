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
        life.text = GameManager.instancia.vidas.ToString();
    }
}