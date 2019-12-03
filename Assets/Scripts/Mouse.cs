using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Node [] Dis_path;   //path to display
    Node current;
    private int NumberOfPaths = 0;
    private int index = 0;
    private bool Is_Path_Found=false;
    public float timebtwupdateds;
    private float temptime;
    Stack<Node> path = new Stack<Node>();
    private bool Is_poped=false;
    //make node for not visited
    //check directions for not visited
    //add it to stack
    //if its blocked pop from stack
    //else check directions 
    private void Start()
    {
        initialpath();
    }
    private void Update()
    {
        if (!Maze.IsReady)
            return;
        
        if (!Is_Path_Found)
        {
        while (true)
        {
                if (path.Count == 0)
                {
                    Debug.Log(NumberOfPaths);
                    Debug.Log("All Paths Found");
                    Maze.IsReady = false;
                    return;
                }
                current = path.Peek();

                Maze.Instance.Plane[current.x, current.y] = 2;

                if (!Is_poped)
                {
                    current.Check();
                }
                Is_poped = false;

                //find first path to show it
                if (current.x == Maze.Instance.MazeSize - 1 && current.y == Maze.Instance.MazeSize - 1) 
                {
                    Debug.Log("found");
                    current.visited = false;
                    Maze.Instance.Plane[current.x, current.y] = 1;

                    Dis_path = new Node[path.Count];
                    path.CopyTo(Dis_path, 0);

                    index = path.Count-1;

                    path.Pop();
                    Is_poped = true;
                    Is_Path_Found = true;
                    return;
                }

                DirCheck();
                if (current.IsBlocked)
                {
                    current.visited = false;
                    Maze.Instance.Plane[current.x, current.y] = 1;
                    path.Pop();
                    Is_poped = true;
                }
        }
        }
        //show path
        else
        {
           if (Time.time > temptime)
           {
               temptime = Time.time + timebtwupdateds;
             if (index<0)
             {
                 Is_Path_Found = false;
                 NumberOfPaths++;
                 return;
             }
             transform.position = new Vector3(Dis_path[index].x + 0.5f, -Dis_path[index].y + 0.5f,-1);
           index--;
            }
        }

    }
    private void DirCheck()
    {
        int direction = -1;
        for (int i = 0; i < 8; i++)
        {
            if (current.dir[i])
            {
                direction = i;  //مسیر باز
                break;
            }
        }
        if (direction == -1)
        {
        current.IsBlocked = true;
           // current.isBlocked();
            return;
        }
        current.isBlocked();
                current.dir[direction] = false; // که دیگه نریم توش

        //ببینیم کدوم ور بازه بریم توش اضاف =ه کنیم به استک
        
        if (direction==0)
        {
            makeNode(current.x + 1, current.y + 1);
        }
       else if (direction == 1)
        {
            makeNode(current.x + 1, current.y);
        }
        else if (direction == 2)
        {
            makeNode(current.x , current.y + 1);
        }
        else if (direction == 3)
        {
            makeNode(current.x + 1, current.y - 1);
        }
        else if (direction == 4)
        {
            makeNode(current.x - 1, current.y + 1);
        }
        else if (direction == 5)
        {
            makeNode(current.x , current.y - 1);
        }
        else if (direction == 6)
        {
            makeNode(current.x - 1, current.y);
        }
        else if (direction == 7)
        {
           makeNode(current.x - 1, current.y - 1);
        }
    }

    private void makeNode(int x,int y)
    {
        Node temp = new Node(x, y);//start position in maze
        temp.visited = true;
        path.Push(temp);
       // transform.position = new Vector3(x + 0.5f, -y + 0.5f);
    }

    private void initialpath()
    {
        Node temp = new Node(0, 0);//start position in maze
        temp.visited = true;
        path.Push(temp) ;

    }
}
