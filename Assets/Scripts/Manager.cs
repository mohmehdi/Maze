using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject Maze;
    public GameObject Mouse;
    public  GameObject Panel;
    public InputField inputField;
    public static int SizeField;//textFfield number
    public static bool TORC; //text or create;
    public  void TextButt()
    {
        TORC = true;
        Panel.SetActive(false);
        Maze.SetActive(true);
        Mouse.SetActive(true);
    }
    public void CreateButt()
    {
        bool flag = int.TryParse(inputField.text, out SizeField);
        if (flag)
        {
        TORC = false;
        Panel.SetActive(false);
        Maze.SetActive(true);
        Mouse.SetActive(true);
        }
    }
}
