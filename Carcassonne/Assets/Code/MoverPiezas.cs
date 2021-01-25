using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPiezas : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;

    private float startPosX;
    private float startPosY;


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
        }
        Rotate();
        
    }

    // Funcion para rotar las piezas
    void Rotate(){
        if (Input.GetKey("r")){
            gameObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
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
