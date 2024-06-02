using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Personagem : MonoBehaviour
{
    //GAMEOBJECT PERSONAGEM
    //variaves de correr//
    public bool carregarstamina;
    public float stamina = 100;
    public bool correndo;
    public bool checarmovimento;
    public GameObject barra_de_stamina;
    /////////////////////////////
    //variaveis de Barra_de_Hp//
    public float hpatual = 100;
    public GameObject Barra_de_Hp;
    public Text hptext;
    public float intangibilidade;
    /////////////////////////////
    //Variaveis de Gravidade e pulo//
    public float gravidade = 5.0f;
    public Transform verificadordechao;
    public float alcanceverificadordechao;
    public LayerMask layerdochao;
    private bool estanochao;
    public Vector3 vetordequeda;
    public float alturaPulo = 8.0f;
    //////////////////////////////


    private CharacterController controledopersonagem;
    private Vector3 direcaoMovimento;
    public float velocidadedemovimento = 4f;
    public Selecao_de_Armas Selecao_De_Armas;
    public Transform corpo;
    public Transform controledecamera;
    void Start()
    {
        
        controledopersonagem = GetComponent<CharacterController>();
    }

    void Update()
    {
        agachar();
        MoverPersonagem();
        AplicarGravidade();
        pular();
        correr();
        HP();
    }

    private void MoverPersonagem()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direcaoMovimento = new Vector3(horizontal, 0, vertical);
        direcaoMovimento = Camera.main.transform.TransformDirection(direcaoMovimento);
        
        controledopersonagem.Move(direcaoMovimento * velocidadedemovimento * Time.deltaTime);
        if (direcaoMovimento != Vector3.zero)
        {
            checarmovimento = true;
        }
        else
        {
            checarmovimento = false;
        }
    }
    private void AplicarGravidade()
    {
        estanochao = Physics.CheckSphere(verificadordechao.position, alcanceverificadordechao, layerdochao);
        if (estanochao && vetordequeda.y < 0)
        {
            vetordequeda.y = -2f;
            
        }
        vetordequeda.y += gravidade * Time.deltaTime;
        controledopersonagem.Move(vetordequeda * Time.deltaTime);
    
    }
    private void pular()
    {
        if (Input.GetButtonDown("Jump") && estanochao)
        {
            vetordequeda.y = Mathf.Sqrt(alturaPulo * -2f * gravidade);
        }
    }
    private void correr()
    {
        barra_de_stamina.GetComponent<RectTransform>().sizeDelta = new Vector2(stamina, 10f);

        if (Input.GetKey(KeyCode.LeftShift) && checarmovimento)
        {
            carregarstamina = false;
        }
        else
        {
            carregarstamina = true;
            if (stamina < 100)
            {
                stamina = stamina + 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && checarmovimento)
        {

            correndo = true;
            if (correndo)
            {
                stamina = stamina - 2;
                velocidadedemovimento = 10f;
            }
        }
        else
        {
            correndo = false;
            velocidadedemovimento = 4f;
        }

    }
    void agachar()
    {
        if (Input.GetKey(KeyCode.C))
        {
            corpo.transform.localScale = new Vector3(1f, 0.5f, 1f);
            controledopersonagem.height = 1f;
            controledecamera.transform.localPosition = new Vector3(0.05f, 0.375f, 0.16f);
            velocidadedemovimento = 1;
        }
        else
        {
            corpo.transform.localScale = new Vector3(1f, 1f, 1f);
            controledopersonagem.height = 2f;
            controledecamera.transform.localPosition = new Vector3(0.05f, 0.75f, 0.16f);
        }

    }
    void HP()
    {
        Barra_de_Hp.GetComponent<RectTransform>().sizeDelta = new Vector2(hpatual, 10f);
        hptext.text = "" + hpatual;
        intangibilidade -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider Entrada_de_Colisoes)
    {
        //Colisor da muniçao de metralhadora
        if (Entrada_de_Colisoes.tag == "municaometralhadora") 
        {
            Selecao_De_Armas.capacidadetotal += 30;
            Destroy(Entrada_de_Colisoes.gameObject);
        }
    }
    private void OnTriggerStay(Collider Colisoes_Continuas)
    {
        if (Colisoes_Continuas.tag == "inimigo" && intangibilidade <=0)
        {
            hpatual = hpatual - 10;
            intangibilidade = 0.5f;
        }
    }

}