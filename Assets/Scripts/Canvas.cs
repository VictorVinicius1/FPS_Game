using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    //GAMEOBJECT CANVAS
    public Selecao_de_Armas selecao_de_armas;
    public Text municao;
    public Text wave;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        municao.text = selecao_de_armas.balasnopente+"/"+selecao_de_armas.capacidadetotal;
       // wave.text = "" + wave;
    }
}
