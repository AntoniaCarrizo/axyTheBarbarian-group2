using System;
using UnityEngine;

public abstract class DecisionNode
{
    public abstract bool Evaluate();
}

public class PlayerNearNode : DecisionNode
{
    private GameObject player;
    private float detectionRadius;
    private ActionNode trueNode;
    private ActionNode falseNode;
    private GameObject gameObject;

    public PlayerNearNode(GameObject gameObject, GameObject player, float detectionRadius, ActionNode trueNode, ActionNode falseNode)
    {
        this.gameObject = gameObject;
        this.player = player;
        this.detectionRadius = detectionRadius;
        this.trueNode = trueNode;
        this.falseNode = falseNode;
    }

    public override bool Evaluate()
    {
        float distanceToPlayer = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
        if (distanceToPlayer < detectionRadius)
        {
            trueNode.Execute();
            return true;
        }
        else
        {
            falseNode.Execute();
            return false;
        }
    }
}

public abstract class ActionNode
{
    public abstract void Execute();
}

public class RunAwayNode : ActionNode
{
    private GameObject gameObject;
    private GameObject player;
    private Vector2 movementDirection;
    private bool isRunningAway;
    private Action setRunningAway;

    public RunAwayNode(GameObject gameObject, GameObject player, Vector2 movementDirection, bool isRunningAway)
    {
        this.gameObject = gameObject;
        this.player = player;
        this.movementDirection = movementDirection;
        this.isRunningAway = isRunningAway;

        // Define setRunningAway as a function that sets isRunningAway to true
        this.setRunningAway = () => { this.isRunningAway = true; };
    }

    public override void Execute()
    {
        Vector2 directionAwayFromPlayer = (this.gameObject.transform.position - player.transform.position).normalized;
        movementDirection = directionAwayFromPlayer; // Set movementDirection to the opposite direction of the player
        isRunningAway = true;
        Debug.Log("Running Away: " + directionAwayFromPlayer);
    }
}

public class InactiveNode : ActionNode
{
    public override void Execute()
    {
        // No hacer nada
    }
}