using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_de_Camera : MonoBehaviour { 

    //GAMEOBJECT CONTROLADOR DE CAMERA 
    Camera camera;
    public float sensibilidade;
    public float mouseX, mouseY;
    public float mouseYmax,mouseYmin;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        camera = Camera.main;
    }

    // Update is called once per frame


    void Update()
    {
       
        mouseX += sensibilidade * Input.GetAxis("Mouse X");
        mouseY += sensibilidade * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -mouseYmin, mouseYmax);

        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0f);
      
    }
}
