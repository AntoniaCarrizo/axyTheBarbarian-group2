using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private GraphNode[,] nodes;

    public Graph(int width, int height)
    {
        nodes = new GraphNode[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                nodes[x, y] = new GraphNode(new Vector2Int(x, y));
            }
        }
    }

    public GraphNode GetNode(int x, int y)
    {
        return nodes[x, y];
    }

    public IEnumerable<GraphNode> GetNeighbors(GraphNode node)
    {
        List<GraphNode> neighbors = new List<GraphNode>();
        Vector2Int[] directions = {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

        foreach (var direction in directions)
        {
            Vector2Int neighborPos = node.Position + direction;
            if (IsWithinBounds(neighborPos))
            {
                neighbors.Add(GetNode(neighborPos.x, neighborPos.y));
            }
        }

        return neighbors;
    }

    public bool IsWithinBounds(Vector2Int position)
    {
        return position.x >= 0 && position.x < nodes.GetLength(0) &&
               position.y >= 0 && position.y < nodes.GetLength(1);
    }
}
