using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Maze : MonoBehaviour
{
    Color wall, way, footprint;
    public static Maze Instance { set; get; }               //to refrence in other objects
    public int MazeSize;
    public static bool IsReady = false;                     //nullrefrence exeption handler :)
    public int[,] Plane;                                    // maze matrix

    private const float offcet = 0.5f;              //center of unity units for cubes center :)
    private Vector2 size = new Vector2(0.95f,0.95f);  //size of every cube
    private void Awake()
    {
        wall = new Color(0.5f, 0.3f, 0.1f);
        way = new Color(0.9f, 0.7f, 0.5f);
        footprint = new Color(1, 0.8f, 0.8f);
    }
    private void Start()
    {
        Instance = this;
        if (Manager.TORC)
        {
        maze_input();
        }
        else
        {
        Make_Maze(Manager.SizeField);
        }
        IsReady = true;
    }
    private void OnDrawGizmos()
    {
        if (MazeSize < 1)
            return;


        for (int i = 0; i < MazeSize; i++)
        {
            for (int j = 0; j < MazeSize; j++)
            {
                if (Plane[i,j]==1)
                {
                    Gizmos.color = way;
                    Gizmos.DrawCube(new Vector2(i + offcet, -j + offcet), size);
                }
                else if (Plane[i,j]==0)
                {
                    Gizmos.color = wall;
                    Gizmos.DrawCube(new Vector2(i + offcet, -j + offcet), size);
                }
                else if (Plane[i, j] == 2)
                {
                    Gizmos.color = footprint;
                    Gizmos.DrawCube(new Vector2(i + offcet, -j + offcet), size);
                }
            }
        }
        Gizmos.color = Color.green;                             //declare start position
        Gizmos.DrawCube(new Vector2(offcet, offcet), size);

        Gizmos.color = Color.red;                               //declare end position
        Gizmos.DrawCube(new Vector2((MazeSize - 1) + offcet, -(MazeSize - 1) + offcet), size);

    }
    private void create_Square(int x ,int y)
    {
        if (x+1>0 && x+1<MazeSize-1 && y>0 && y<MazeSize-1)
        {
            Plane[x + 1, y] = 0;
        }
        if (x > 0 && x < MazeSize - 1 && y+1 > 0 && y+1 < MazeSize - 1)
        {
            Plane[x , y+1] = 0;
        }
        if (x-1 > 0 && x-1 < MazeSize - 1 && y > 0 && y < MazeSize - 1)
        {
            Plane[x -1, y] = 0;
        }
        if (x > 0 && x < MazeSize - 1 && y-1 > 0 && y-1 < MazeSize - 1)
        {
            Plane[x , y-1] = 0;
        }
        if (x+1 > 0 && x+1 < MazeSize - 1 && y+1 > 0 && y+1 < MazeSize - 1)
        {
            Plane[x + 1, y+1] = 0;
        }
        if (x-1 > 0 && x-1 < MazeSize - 1 && y-1 > 0 && y-1 < MazeSize - 1)
        {
            Plane[x - 1, y-1] = 0;
        }
        if (x+1 > 0 && x+1 < MazeSize - 1 && y-1 > 0 && y-1 < MazeSize - 1)
        {
            Plane[x + 1, y-1] = 0;
        }
        if (x-1 > 0 && x-1 < MazeSize - 1 && y+1 > 0 && y+1 < MazeSize - 1)
        {
            Plane[x - 1, y+1] = 0;
        }
    }
    private void Make_Maze(int size)
    {
        System.Random rand = new System.Random();
        MazeSize = size;
        int squers = (size* size) /5;     //number of square walls //a square is a  3X3 wall

        Plane = new int[MazeSize, MazeSize];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Plane[i, j] = 1;
            }
        }

        for (int i = 0; i < squers; i++)
        {
            create_Square(rand.Next(size - 1), rand.Next(size - 1));
        }
    }
    private void maze_input() //get input from file
    {
        if (!File.Exists("E:\\unity projects\\Maze\\Assets\\Input\\way.txt"))//return if there is no file in path
            return;

        StreamReader mazeText =new StreamReader("E:\\unity projects\\Maze\\Assets\\Input\\way.txt");//refrence to the file

        string maze_Size_txt = mazeText.ReadLine();     //read size of matrix as string in first line
        MazeSize  = Convert.ToInt32(maze_Size_txt);//convert the size to integer

        Plane = new int[MazeSize, MazeSize];      //create the maze by MazeSize^2

        for (int i = 0; i < MazeSize; i++)
        {
            string line = mazeText.ReadLine();     //read line by line 
            line = line.Replace(" ", "");
            for (int j=0; j < MazeSize;j++ )      //check 0 & 1 's in the text File
            {
                if (line[j] =='1')
                {
                    Plane[j, i] = 0;
                }
                else
                {
                    Plane[j, i] = 1;
                }
                
            }
        }
    }
}
