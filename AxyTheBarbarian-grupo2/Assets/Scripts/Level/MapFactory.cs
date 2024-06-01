using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory : MonoBehaviour
{
    public GameObject wall;

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
    }

    public void GenerateMap()
    {
        string mapTXT = System.IO.File.ReadAllText("Assets/Resources/level.txt");
    }
}

