using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPiezas : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving = false;

    private float startPosX;
    private float startPosY;
    private bool heRotado = false;

    private float rotZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving){
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            Rotate();
        }
    }

    // Funcion para rotar las piezas 
    // Con la tecla q se gira hacia la izquierda, con la tecla r se gira hacia la derecha
    void Rotate(){
        if (Input.GetKey("r") && !heRotado){
            rotZ -= 90;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            heRotado = true;
        }

        else if (Input.GetKey("q") && !heRotado){
            rotZ += 90;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            heRotado = true;
        }

        else if (!Input.GetKey("r") && !Input.GetKey("q")) {
            heRotado = false;
        }

        if(rotZ%360 == 0){
            rotZ = 0;
        }

    }

    // Override
    public void OnMouseDown(){
        if (Input.GetMouseButtonDown(0)){
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            moving = true;
        }

    }
    // Override
    private void OnMouseUp(){
        moving = false;
    }
}
