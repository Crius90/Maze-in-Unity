# Maze-in-Unity

In this Repository you find the source for a random maze generator in Unity, with an implementation of aldous broder and recursive backtracker. 
There is also an extended implementation for a maze with rooms. 

## Maze

<img width="1078" alt="Unbenannt" src="https://user-images.githubusercontent.com/38067386/149332822-208c63a4-09aa-4443-b627-50b8473b3c59.png">

- Download the scripts from the folder "MAZE" and import them into a new Unity Project. 
- Create an empty Gameobject called MazeBuilder and attach the MazeBuilder script to it. 
- Create two Materials for the floor and the wall and drag them into the MazeBuilder script.
- After that, create another empty Gameobject called 'Maze'. 
- Add a Canvas with a Button and register the OnClick method from MazeBuilder to generate new Mazes in Playmode

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
- Make sure to use Recursive Backtracker here. Aldous Broder runs into Exceptions with rooms.

## Links for Mazes and PCG in general (mostly papers)

### Mazes

- Mazes for Programmers (Book): http://www.mazesforprogrammers.com/
- https://weblog.jamisbuck.org/2011/2/7/maze-generation-algorithm-recap
- https://medium.com/analytics-vidhya/maze-generations-algorithms-and-visualizations-9f5e88a3ae37
- https://catlikecoding.com/unity/tutorials/maze/
- Victor Bellot, Maxime Cautres, Jean-Marie Favreau, Milan Gonzalez-Thauvin, Pascal Lafourcade, Kergann Le Cornec, Bastien Mosnier, and Samuel Riviere-Wekstein. How to generate perfect mazes?
- Paul Hyunjin Kim and Roger Crawfis. Intelligent maze generation based on topological constraints.
- Barbara De Kegel and Mads Haahr. Procedural puzzle generation: a survey. 
- Paul Hyunjin Kim and Roger Crawfis. The quest for the perfect perfect-maze.

### PCG 

- https://www.gamedeveloper.com/design/procedural-content-generation-thinking-with-modules
- http://pcg.wikidot.com/
- Procedural Content Generation in Games: A Textbook and an Overview of Current Research
- Gillian Smith. Procedural content generation: An overview. Level Design Processes and Experiences
- Mark Hendrikx, Sebastiaan Meijer, Joeri Van Der Velden, and Alexandru Iosup. Procedural content generation for games: A survey.
- Timothy Roden and Ian Parberry. From artistry to automation: A structured methodology for procedural content creation.
- Michael Blatz and Oliver Korn. A very short history of dynamic and procedural content generation.
- Rafael Pereira de Araujo and Virginia Tiradentes Souto. Game worlds and creativity: The challenges of procedural content generation
- Antonios Liapis, Gillian Smith, and Noor Shaker. Mixed-initiative content creation.
- Julian Togelius, Georgios N Yannakakis, Kenneth O Stanley, and Cameron Browne. Search-based procedural content generation: A taxonomy and survey.
- Gillian Smith and Jim Whitehead. Analyzing the expressive range of a level generator.

### Dungeons

-  Breno MF Viana and Selan R dos Santos. A survey of procedural dungeon generation.
-  Roland Van Der Linden, Ricardo Lopes, and Rafael Bidarra. Procedural generation of dungeons.
-  Noor Shaker, Antonios Liapsis, Julian Togelius, Ricardo Lopes, and Rafael Bidarra. Constructive generation methods for dungeons and levels.
-  Noor Shaker, Gillian Smith, and Georgios N. Yannakakis. Evaluating content generators.
-  Lawrence Johnson, Georgios N Yannakakis, and Julian Togelius. Cellular automata for real-time generation of infinite cave levels.
-  Roland Van der Linden, Ricardo Lopes, and Rafael Bidarra. Designing procedurally generated levels.
-  Daniel Ashlock, Colin Lee, and Cameron McGuinness. Search based procedural generation of maze-like levels.
-  Nathan Williams. An investigation in techniques used to procedurally generate dungeon structures. 
