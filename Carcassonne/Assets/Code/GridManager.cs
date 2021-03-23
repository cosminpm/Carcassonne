using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords{
    public Coords(float x, float y){
        X = x;
        Y = y;
    }
    public float X {get;}
    public float Y {get;} 
}

public class GridManager : MonoBehaviour
{
    public int rows;
    public int cols;
    public float tileSize;  
    public Coords[,] grid;
    // Start is called before the first frame update
    void Start()
    {
       
        GenerateGrid();
        
        printGrid();
        Debug.Log(grid);
        //MonoBehaviour.print(grid);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    private void GenerateGrid(){
        GameObject referenceTile = (GameObject) Instantiate(Resources.Load("Campo"));
        //grid = new Coords[rows, cols];
        grid = new Coords[rows, cols];
        for (int row = 0; row < rows; row++){
            for (int col = 0; col< cols; col++){
                GameObject tile = (GameObject) Instantiate(referenceTile, transform);
                float posX = col * tileSize;
                float posY = row * - tileSize;
                tile.transform.position = new Vector2(posX, posY);
                grid[row,col] = new Coords(posX, posY);
            }
        }
        MonoBehaviour.print(grid);
        Destroy(referenceTile);
    }

    private void printGrid(){
        for (int row = 0; row < rows; row++){
            for (int col = 0; col< cols; col++){
               MonoBehaviour.print(grid[row,col].X + " " + grid[row,col].Y);
            }
        }
    }
}
