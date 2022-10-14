using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Muerte : MonoBehaviour
{
    public static TextMeshProUGUI muerteTexto;

    void Start()
    {
        muerteTexto = GetComponent<TextMeshProUGUI>();
        muerteTexto.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
