using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform road;
    
    [SerializeField] float speed = 1f;
    
    [SerializeField] private int startingNodeIndex;
    
    Vector3[] nodes;
    int numberOfNodes;
    
    private int targetNodeIndex = 1;
    Vector3 targetNode;
    Vector3 afterTargetNode;
    
    // Start is called before the first frame update
    private void Start()
    {
        numberOfNodes = road.childCount;
        nodes = new Vector3[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            Vector3 node = road.GetChild(i).position;
            nodes[i] = node;
        }

        targetNodeIndex = startingNodeIndex + 1;
        
        transform.position = nodes[startingNodeIndex];
        targetNode = nodes[targetNodeIndex];
        transform.LookAt(targetNode);
        afterTargetNode = nodes[targetNodeIndex + 1];
    }

    // Update is called once per frame
    private void Update()
    {
        float path = speed * Time.deltaTime;
        float distanceToTarget = Vector3.Distance(transform.position, targetNode);

        if (path > distanceToTarget)
        {
            NextNode();
        }
        else
        {
            Vector3 movement = (targetNode - transform.position).normalized * path;
            transform.position += movement;
            Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(afterTargetNode - targetNode), path/distanceToTarget);
            transform.rotation = rotation;
        }
    }

    private void NextNode()
    {
        transform.position = targetNode;
        targetNodeIndex++;
        if (targetNodeIndex >= numberOfNodes)
            targetNodeIndex = 0;
        targetNode = nodes[targetNodeIndex];
        int afterTargetNodeIndex = targetNodeIndex + 1;
        if (afterTargetNodeIndex >= numberOfNodes)
            afterTargetNodeIndex = 0;

        afterTargetNode = nodes[afterTargetNodeIndex];
        transform.LookAt(targetNode);
    }
}
