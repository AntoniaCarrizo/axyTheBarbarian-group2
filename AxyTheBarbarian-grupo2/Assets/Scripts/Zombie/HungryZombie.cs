using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryZombie : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.0f;
    public float pathUpdateInterval = 1.0f;

    private Graph graph;
    private List<GraphNode> path;
    private int currentPathIndex;

    private void Start()
    {
        int levelWidth = 10; 
        int levelHeight = 10;
        graph = new Graph(levelWidth, levelHeight);

        StartCoroutine(UpdatePath());
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            GraphNode startNode = graph.GetNode((int)transform.position.x, (int)transform.position.y);
            GraphNode goalNode = graph.GetNode((int)player.position.x, (int)player.position.y);
            path = FindPath(graph, startNode, goalNode);
            currentPathIndex = 0;

            yield return new WaitForSeconds(pathUpdateInterval);
        }
    }

    private List<GraphNode> FindPath(Graph graph, GraphNode start, GraphNode end)
    {
        List<GraphNode> openList = new List<GraphNode>();
        Dictionary<GraphNode, GraphNode> cameFrom = new Dictionary<GraphNode, GraphNode>();

        openList.Add(start);

        while (openList.Count > 0)
        {
            GraphNode currentNode = openList[0];
            openList.RemoveAt(0);

            if (currentNode == end)
            {
                List<GraphNode> path = new List<GraphNode>();
                while (currentNode != start)
                {
                    path.Add(currentNode);
                    currentNode = cameFrom[currentNode];
                }
                path.Add(start);
                path.Reverse();
                return path;
            }

            foreach (var neighbor in graph.GetNeighbors(currentNode))
            {
                if (!openList.Contains(neighbor) && !cameFrom.ContainsKey(neighbor))
                {
                    openList.Add(neighbor);
                    cameFrom[neighbor] = currentNode;
                }
            }
        }

        return null; // No path found
    }

    private void Update()
    {
        if (path != null && currentPathIndex < path.Count)
        {
            Vector2 nextPosition = path[currentPathIndex].Position;
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            if ((Vector2)transform.position == nextPosition)
            {
                currentPathIndex++;
            }
        }
    }
}