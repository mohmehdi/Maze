public class Node
{
    public bool IsBlocked=false;
    public int x;
    public int y;
    public bool visited;
    public bool[] dir;
    public Node(int x , int y)
    {
        this.x = x;
        this.y = y;
    }
    public Node()
    {

    }
    public void isBlocked()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            if (dir[i])
            {
                count++;
            }
        }
        if (count==0)
        {
            IsBlocked = true;
        }
    }
    public void Check()
    {
    dir = new bool[8];                                                        
    if (x + 1 < Maze.Instance.MazeSize && y + 1 < Maze.Instance.MazeSize && Maze.Instance.Plane[x + 1, y + 1]== 1) 
    {                                                                         
        dir[0] = true;                                                        
    }                                                                         
    if (x + 1 < Maze.Instance.MazeSize && Maze.Instance.Plane[x + 1, y] == 1) 
    {                                                                         
         dir[1] = true;                                                      
    }                                                                         
    if (y + 1 < Maze.Instance.MazeSize && Maze.Instance.Plane[x, y+1] == 1) 
    {                                                                         
         dir[2] = true;                                                      
    }                                                                         
    if (x + 1 < Maze.Instance.MazeSize&& y - 1 >= 0 && Maze.Instance.Plane[x + 1, y - 1] == 1) 
    {                                                                         
         dir[3] = true;                                                       
    }                                                                         
    if (y + 1 < Maze.Instance.MazeSize && x - 1 >= 0 && Maze.Instance.Plane[x - 1, y + 1] == 1) 
    {                                                                         
         dir[4] = true;                                                      
    }                                                                         
    if (y - 1 >= 0 && Maze.Instance.Plane[x , y - 1] == 1) 
    {                                                                         
         dir[5] = true;                                                      
    }                                                                         
    if (x - 1 >= 0 && Maze.Instance.Plane[x - 1, y] == 1) 
    {                                                                         
          dir[6] = true;                                                     
    }                                                                         
    if (x - 1 >= 0 && y - 1 >=0 && Maze.Instance.Plane[x - 1, y - 1] == 1) 
    {                                                                         
         dir[7] = true; 
    }
    }
}