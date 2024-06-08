using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapFactory : MonoBehaviour
{
    public string mapFilePath = "Assets/Resources/map.txt";
    public GameObject wallPrefab;
    public GameObject playerPrefab;
    public GameObject skeletonPregab;
    public GameObject gazerPrefab;
    public GameObject exitPrefab;

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
    }

    public void GenerateMap()
    {
        string[] lines = File.ReadAllLines(mapFilePath);
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                char tile = lines[y][x];
                Vector3 position = new Vector3(x, -y, 0);

                switch (tile)
                {
                    case '.':
                        break;
                    case '#':
                        Instantiate(wallPrefab, position, transform.rotation);
                        break;
                    case 'P':
                        Instantiate(playerPrefab, position, transform.rotation);
                        break;
                    case 'G':
                        Instantiate(gazerPrefab, position, transform.rotation);
                        break;
                    case 'S':
                        Instantiate(skeletonPregab, position, transform.rotation);
                        break;
                    case 'X':
                        Instantiate(exitPrefab, position, transform.rotation);
                        break;
                }
            }
        }
    }
}

