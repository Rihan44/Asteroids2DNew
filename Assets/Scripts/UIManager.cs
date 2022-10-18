using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI points;
    public TextMeshProUGUI life;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textoTiempo.text = Time.time.ToString("00.00");
        points.text = GameManager.instancia.puntuacion.ToString();
        life.text = GameManager.instancia.vidas.ToString();
    }
}
