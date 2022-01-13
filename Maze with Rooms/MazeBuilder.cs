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
    
    //room variables
    public List<Room> roomList;
    
    //how spread the rooms are -> the bigger, the less room fit on the map
    public int roomDistance = 2;
    
    //how many times the loop tries to fit the rooms -> carefull with high numbers, might get stuck
    public int roomFitTries = 100;
    
    //in gridCells
    public int roomSizeMin = 4;
    public int roomSizeMax = 20;
    private void Awake()
    {

        Mask mask = new Mask(gridSize, gridSize);
        MakeRooms(mask);
        MaskedGrid grid = new MaskedGrid(mask);
        
        
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

    // public void OnClick()
    // {
    //     foreach (Transform child in Maze.transform)
    //     {
    //         GameObject.Destroy(child.gameObject);  
    //     }
    //     MazeGrid grid = new MazeGrid(GridSize, GridSize);
    //     AldousBroder.CreateMaze(grid);
    //     //BuildGrid(grid);
    // }

    public void MakeRooms(Mask mask)
    {
        roomList = new List<Room>();
        System.Random rnd = new System.Random();
        int rows = mask.Rows;
        int columns = mask.Columns;
        int test = 0;

        while (test < roomFitTries)
        {
            int x1 = rnd.Next(0, rows);
            int y1 = rnd.Next(0, columns);

            int x2 = rnd.Next(1, rows - x1) + x1;
            int y2 = rnd.Next(1, columns - y1) + y1;

            int size = ((0 - y1) + y2) * ((0 - x1) + x2);

            if (x2 >= 0 && x2 < rows)
            {
                if (y2 >= 0 && y2 < columns)
                {
                    bool intersect = false;
                    Room room = new Room(x1, y1, x2, y2);

                    var roomsize = room.RoomSize();

                    if (roomsize >= roomSizeMin && roomsize <= roomSizeMax)
                    {
                        if (roomList.Count > 0)
                        {
                            foreach (Room r in roomList)
                            {
                                if (r.CheckIntersection(room))
                                {
                                    intersect = true;
                                }
                            }
                        }

                        if (!intersect)
                        {
                            roomList.Add(room);
                            for (int i = x1; i <= x2; i++)
                            {
                                for (int j = y1; j <= y2; j++)
                                {
                                    mask.cellState[i, j] = false;
                                }
                            }
                        }
                    }
                }
            }

            test++;
        }
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

    //Create the walls for the rooms
    //You only need to draw the outer walls on the north an the East side 

    foreach(Room r in roomList){
        //Draws the EastWall of rectangle/room
        for(int i = r.UpperX; i <= r.LowerX; i++){
            GameObject eastWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            eastWall.name = string.Format("East Wall – Row {0} Col {1}", i, r.LowerY);
            eastWall.transform.position = new Vector3(i * cellSize, wallHeight / 2, (r.LowerY * cellSize) - (cellSize / 2) + cellSize);
            eastWall.transform.localScale = new Vector3(cellSize, wallHeight, 0.1f);
            eastWall.transform.SetParent(maze.transform);
            eastWall.transform.GetComponent<Renderer>().material = walls;
        }

        //Draws the NorthWall of rectangle/room
        for(int i = r.UpperY; i <= r.LowerY; i++){
            GameObject northWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            northWall.name = string.Format("North Wall – Row {0} Col {1}", r.UpperX, i);
            northWall.transform.position = new Vector3((r.UpperX * cellSize) - (cellSize / 2), wallHeight / 2, i * cellSize);
            northWall.transform.localScale = new Vector3(0.1f, wallHeight, cellSize);
            northWall.transform.SetParent(maze.transform);
            northWall.transform.GetComponent<Renderer>().material = walls; 
        }


        //Remove random Wall to make entrance to maze
        var o = rnd.Next(0,2) * 2 - 1; //Either -1 or 1
        bool tryAgain = true;
        while(tryAgain){
            //Take uper Left Point of room
            if(o == 1){
                var p = rnd.Next(0,2) * 2 - 1;

                //go right
                if(p == 1){
                    //Check bounds of grid to not make Entrance to void
                    if(r.UpperX > 0){
                        var t = rnd.Next(r.UpperY, r.LowerY);

                        //point (r.upperX -1, t)
                        
                        var str = string.Format("Maze/North Wall – Row {0} Col {1}", r.UpperX, t);
                        GameObject.Find(str).SetActive(false);
                        tryAgain = false;
                    }
                    
                }
                //go down
                else{
                    if(r.UpperY > 0){
                        var t = rnd.Next(r.UpperX, r.LowerX);

                        var str = string.Format("Maze/East Wall – Row {0} Col {1}", t, r.UpperY - 1);
                        GameObject.Find(str).SetActive(false);
                        tryAgain = false;
                    }
                }
            }
            //Take lower right Point of Room
            else if(o == -1){
                var p = rnd.Next(0,2) * 2 - 1;

                
                //go left
                if(p == 1){
                    if(r.LowerX < gridSize-1){
                        var t = rnd.Next(r.UpperY, r.LowerY);

                        var str = string.Format("Maze/North Wall – Row {0} Col {1}", r.LowerX + 1 , t);
                        GameObject.Find(str).SetActive(false);
                        tryAgain = false;
                    }
                }
                //go up
                else{
                    if(r.LowerY < gridSize-1){
                        var t = rnd.Next(r.UpperX, r.LowerX);

                        var str = string.Format("Maze/East Wall – Row {0} Col {1}", t, r.LowerY);
                        GameObject.Find(str).SetActive(false);
                        tryAgain = false;
                    }
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
