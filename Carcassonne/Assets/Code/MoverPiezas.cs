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
    private Vector3 resetPosition;
    private GridManager correctPosition;

    int cols;
    int rows;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
        GetPositions();
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

    private void GetPositions(){
        correctPosition = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridManager>();
        cols = correctPosition.cols;
        rows = correctPosition.rows;
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
        float posX;
        float posY;

        for (int col = 0; col < cols; col++){
            for(int row = 0; row < rows; row++){
                posX = correctPosition.grid[col, row].X;
                posY = correctPosition.grid[col, row].Y;
                Debug.Log(posX + " " + this.transform.localPosition.x + " " + posY + " " + this.transform.localPosition.y);



                if(Mathf.Abs(this.transform.localPosition.x - posX) <= 0.5f &&  Mathf.Abs(this.transform.localPosition.y - posY) <= 0.5f){
                    this.transform.localPosition = new Vector3(posX, posY, 0);
                    //Debug.Log("POS CORRECTA");
                    break;
                }
                else{
                    //Debug.Log("POS inCORRECTA");
                    this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                }   
            }
        }



        /*
        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f && 
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f){
                this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
                
        }*/

    }


}
