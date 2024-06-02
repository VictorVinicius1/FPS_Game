using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Selecao_de_Armas : MonoBehaviour
{
    // Start is called before the first frame update
    public float cadeciadetiropistola;
    public float cadeciadetirometralhadora;
    public bool selecionarpistola;
    public bool selecionarmetralhadora;
    public int capacidadetotal = 100;
    public int balasnopente = 30;
    public int capacidadedopente = 30;
    public bool recarregando = false;

    public List<GameObject> muzzle= new List<GameObject>();


    public GameObject balanochao;
    public GameObject balaparede;

    float tempomuzzle = -1f;
    int muzzlechoice;

    void Start()
    {

    }
    private void Update()
    {
        
        recarregar();
        seleçaodearmas();
        if (selecionarpistola)
        {
            pistola();
        }
        if (selecionarmetralhadora)
        {
            metralhadora();
        }

        cadeciadetirometralhadora -= Time.deltaTime;
        cadeciadetiropistola -= Time.deltaTime;
        tempomuzzle -= Time.deltaTime;
        if (tempomuzzle >= 0)
        {

            muzzle[muzzlechoice].gameObject.SetActive(true);
        }
        else
        {
            muzzle[0].gameObject.SetActive(false);
            muzzle[1].gameObject.SetActive(false);
            muzzle[2].gameObject.SetActive(false);
            muzzle[3].gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (balasnopente == 0)
        {
            recarregando = true;
            recarregar();
        }
    }
    private void pistola()
    {
        if (Input.GetMouseButtonDown(0) && cadeciadetiropistola < 0 && selecionarpistola || Input.GetMouseButton(0) && cadeciadetiropistola < 0 && selecionarpistola)
        {
            cadeciadetiropistola = 0.5f;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
            }
        }
    }
    private void metralhadora()
    {
        
        if (Input.GetMouseButtonDown(0) && cadeciadetirometralhadora < 0 && selecionarmetralhadora || Input.GetMouseButton(0) && cadeciadetirometralhadora < 0 && selecionarmetralhadora )
        {
            if(balasnopente > 0)
            {
                cadeciadetirometralhadora = 0.1f;
                atirar();
                balasnopente--;
            }
        
        }
    }
    private void seleçaodearmas()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            selecionarpistola = true;
            selecionarmetralhadora = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selecionarpistola = false;
            selecionarmetralhadora = true;

        }
    }
    private void atirar()
    {
        tempomuzzle = 0.1f;
        RaycastHit hit;
        var destino = Camera.main.transform.position + Camera.main.transform.forward * 1000;
        var colisao = Physics.Raycast(transform.position, destino, out hit, 1000);
        muzzlechoice = Random.Range(0, 3);


        if (colisao)
        {
            Debug.Log("hit");
            Debug.DrawRay(transform.position, destino, Color.red);
            if (hit.transform.tag == "Chao")
            {
                Instantiate(balanochao, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if (hit.transform.tag == "Parede")
            {
                Instantiate(balaparede, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if (hit.transform.tag == "Enemy")
            {
                
                hit.collider.GetComponent<Inimigos>().HPENEMY -= 0.2f;
            }
        }
        else
        {
            Debug.Log(" no hit");
            Debug.DrawRay(transform.position, destino, Color.green);
        }
    }
    private void recarregar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            recarregando = true;
            int balasfaltando = capacidadedopente - balasnopente;
            if(capacidadetotal > balasfaltando)
            {
                capacidadetotal -= balasfaltando;
                balasnopente += balasfaltando;
            }
            else
            {
                balasnopente += capacidadetotal;
                capacidadetotal = 0;
            }   

        }
        else
        {
            recarregando = false;
        }
    }
}
