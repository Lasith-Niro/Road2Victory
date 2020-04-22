using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    private Vector3 startOffset;
    private Vector3 moveVector;

    [Header("Camera")]
    private float transition = 0f;
    public float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        startOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.position + startOffset;
        // X 
        moveVector.x = 0;
        // Y 
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            // Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(player.position + Vector3.up);
        }
    }
}
