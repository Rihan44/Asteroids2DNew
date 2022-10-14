using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosAsteroides : MonoBehaviour
{
    public static int puntuacion = 0;
    TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        //texto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = puntuacion.ToString();
    }
}
