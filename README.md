# Maze-in-Unity

In this Repository you find the source for a random maze generator in Unity, with an implementation of aldous broder and recursive backtracker. 
There is also an extended implementation for a maze with rooms. 

## Maze

<img width="1078" alt="Unbenannt" src="https://user-images.githubusercontent.com/38067386/149332822-208c63a4-09aa-4443-b627-50b8473b3c59.png">

- Download the scripts from the folder "MAZE" and import them into a new Unity Project. 
- Create an empty Gameobject called MazeBuilder and attach the MazeBuilder script to it. 
- Create two Materials for the floor and the wall and drag them into the MazeBuilder script.
- After that, create another empty Gameobject called 'Maze'. 

Now you can go into Playmode and generate new Mazes. 

## Maze with Rooms

<img width="1257" alt="Maze with Rooms" src="https://user-images.githubusercontent.com/38067386/149347378-9c3b5250-c428-49ef-8069-c7bc28592353.png">

- Download the scripts from the folder "Maze with Rooms" and import them into a Unity Project
- Create an empty Gameobject called MazeBuilder and attach the MazeBuilder script to it.
- Create two Materials for the floor and wall and drag them into the MazeBuilder script.
- After that, create another empty Gameobject called 'Maze'
- Variables in MazeBuilder:
- -> RoomFitTries: How often the loop tries to create rooms (the higher the number the slower the computation)
- -> RoomSizeMin: Minimum number of gridCells the rooms have to be
- -> RoomSizeMax: Maximum number of gridCells the rooms have to be
