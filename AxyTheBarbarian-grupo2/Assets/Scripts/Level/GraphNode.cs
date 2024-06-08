using UnityEngine;


public class GraphNode

{
    public Vector2Int Position { get; private set; }
    public float GValue { get; set; }
    public float HValue { get; set; }
    public float FValue => GValue + HValue;
    public GraphNode CameFrom { get; set; }

    public GraphNode(Vector2Int position)
    {
        Position = position;
    }
}
