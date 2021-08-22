using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum PlayerNumber
{
    Player1,
    Player2
}

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float movePositiveRange = 22.5f;
    [SerializeField]
    private float moveNegativeRange = -5f;

    [SerializeField]
    private PlayerNumber myPaddle;

    private bool acceptsInput = true;
    

    // Update is called once per frame
    void Update()
    {
        if (!acceptsInput)
        {
            return;
        }

        float input = 0;

        if (myPaddle == PlayerNumber.Player1)
        {
            input = Input.GetAxis("Vertical");
        }
        
        if(myPaddle == PlayerNumber.Player2)
        {
            input = Input.GetAxis("Vertical2");
        }

        Vector3 newPosition = transform.position;

        newPosition.y += input * moveSpeed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, moveNegativeRange, movePositiveRange);

        transform.position = newPosition;
    }
}
