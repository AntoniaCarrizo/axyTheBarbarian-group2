using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGraph : MonoBehaviour
{
    public int levelWidth = 10;
    public int levelHeight = 10;
    public GameObject gridObject;
    public float gridSize = 1f;
    public LayerMask passableLayers;

    void Start()
    {
        CreateGrid();
        GenerateGraph();
    }

    void CreateGrid()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                Vector3 position = new Vector3(x, 0f, y);
                Quaternion rotation = Quaternion.identity;
                Instantiate(gridObject, position, rotation);
            }
        }
    }

    void GenerateGraph()
    {
        GridCell[,] grid = new GridCell[levelWidth, levelHeight];

        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                Vector3 position = new Vector3(x, 0f, y) * gridSize;
                Collider2D collider = GetComponent<Collider2D>();
                RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.down, collider.bounds.size.y + 0.1f, passableLayers);

                if (hits.Length > 0)
                {
                    grid[x, y] = new GridCell(true);
                }
                else
                {
                    grid[x, y] = new GridCell(false);
                }
            }
        }

        GenerateGraphNodes(grid);
        GenerateGraphEdges(grid);
    }

    void GenerateGraphNodes(GridCell[,] grid)
    {
        List<GraphNode> nodes = new List<GraphNode>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                GraphNode node = new GraphNode(grid[x, y].passable);
                node.Position = new Vector2Int(x, y);
                nodes.Add(node);
            }
        }
    }

    void GenerateGraphEdges(GridCell[,] grid)
    {
        List<Edge> edges = new List<Edge>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                GridCell currentCell = grid[x, y];

                foreach (var neighbor in GetNeighbors(currentCell))
                {
                    if (neighbor.passable)
                    {
                        Edge edge = new Edge(currentCell, neighbor);
                        edges.Add(edge);
                    }
                }
            }
        }
    }

    IEnumerable<GridCell> GetNeighbors(GridCell cell)
    {
        Vector2Int[] directions = {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

        foreach (var direction in directions)
        {
            Vector2Int neighborPos = cell.Position + direction;
            if (neighborPos.x >= 0 && neighborPos.x < levelWidth && neighborPos.y >= 0 && neighborPos.y < levelHeight)
            {
                yield return grid[neighborPos.x, neighborPos.y];
            }
        }
    }

    struct GridCell
    {
        public bool passable;

        public GridCell(bool passable)
        {
            this.passable = passable;
        }
    }

    struct Edge
    {
        public GraphNode from;
        public GraphNode to;

        public Edge(GraphNode from, GraphNode to)
        {
            this.from = from;
            this.to = to;
        }
    }

    struct GraphNode
    {
        public bool passable;
        public Vector2Int Position;

        public GraphNode(bool passable)
        {
            this.passable = passable;
        }
    }
}