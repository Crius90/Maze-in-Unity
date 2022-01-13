using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MazeBuilder : MonoBehaviour
{

    [FormerlySerializedAs("Floor")] public Material floor;

    [FormerlySerializedAs("Walls")] public Material walls;
    
    //gridSize is n x n 
    [FormerlySerializedAs("GridSize")] public int gridSize = 10;

    [FormerlySerializedAs("Maze")] public GameObject maze;
    
    
    private void Awake()
    {

        MazeGrid grid = new MazeGrid(gridSize, gridSize);
        
        
        RecursiveBacktracker.CreateMaze(grid);
        
        BuildGrid(grid);
        
        // MazeGrid grid = new MazeGrid(GridSize, GridSize);
        //
        // //calculate the maze
        // AldousBroder.CreateMaze(grid);
        //
        // //visualize it in Unity
        // BuildGrid(grid);

    }

    public void OnClick()
    {
        foreach (Transform child in maze.transform)
        {
            GameObject.Destroy(child.gameObject);  
        }
        MazeGrid grid = new MazeGrid(gridSize, gridSize);
        RecursiveBacktracker.CreateMaze(grid);
        //AldousBroder.CreateMaze(grid);
        
        BuildGrid(grid);
    }

    
   private void BuildGrid(MazeGrid grid)
{

    System.Random rnd = new System.Random();
    float startX = 1, startZ = 1;

    float cellSize = 1f;
    float wallHeight = 2.5f;
    float floorHeight = 0.1f;

    //Create the floor and interior walls
    for (int row = 0; row < grid.Rows; row++)
    {
        for (int col = 0; col < grid.Columns; col++){
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            floor.name = string.Format("Row {0} Col {1}", row, col);

            floor.transform.position = new Vector3((startX * row * cellSize), floorHeight, (startZ * col * cellSize));
            floor.transform.localScale = new Vector3(cellSize, floorHeight, cellSize);
            floor.transform.GetComponent<Renderer>().material = this.floor;
            floor.transform.SetParent(maze.transform);
            
            

            Cell currentCell = grid.GetCell(row, col);
            

            if(currentCell != null){
                // If the cell is not linked to the north, draw the wall
                if (!currentCell.IsLinked(currentCell.North)){
                    GameObject northWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    northWall.name = string.Format("North Wall – Row {0} Col {1}", row, col);
                    northWall.transform.position = new Vector3((row * cellSize) - (cellSize / 2), wallHeight / 2, col * cellSize);
                    northWall.transform.localScale = new Vector3(0.1f, wallHeight, cellSize);
                    northWall.transform.SetParent(maze.transform);
                    northWall.transform.GetComponent<Renderer>().material = walls; 
                }

                // If the cell is not linked to the east, draw the wall
                if (!currentCell.IsLinked(currentCell.East)){
                    GameObject eastWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    eastWall.name = string.Format("East Wall – Row {0} Col {1}", row, col);
                    eastWall.transform.position = new Vector3(row * cellSize, wallHeight / 2, (col * cellSize) - (cellSize / 2) + cellSize);
                    eastWall.transform.localScale = new Vector3(cellSize, wallHeight, 0.1f);
                    eastWall.transform.SetParent(maze.transform);
                    eastWall.transform.GetComponent<Renderer>().material = walls;
                }
            }

            
        }
    }

    


        

    //Create the rear wall
    GameObject westWall = GameObject.CreatePrimitive(PrimitiveType.Cube);

    float totalLength = cellSize * grid.Rows;

    westWall.name = "Rear Wall";

    westWall.transform.position = new Vector3((totalLength / 2) - (cellSize / 2), (wallHeight / 2), -(cellSize / 2));
    westWall.transform.localScale = new Vector3(totalLength, wallHeight, 0.1f);
    westWall.transform.SetParent(maze.transform);
    westWall.transform.GetComponent<Renderer>().material = walls;

    // Create South Wall
    GameObject southWall = GameObject.CreatePrimitive(PrimitiveType.Cube);

    southWall.name = "South Wall";
    southWall.transform.position = new Vector3(totalLength - (cellSize / 2), (wallHeight / 2), (totalLength / 2) - (cellSize / 2));
    southWall.transform.localScale = new Vector3(0.1f, wallHeight, totalLength);
    southWall.transform.SetParent(maze.transform);
    southWall.transform.GetComponent<Renderer>().material = walls;

}
}
