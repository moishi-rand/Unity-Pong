using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum PlayerPaddle
{
    Paddle1,
    Paddle2
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
    private PlayerPaddle myPaddle;

    private bool acceptsInput = true;
    

    // Update is called once per frame
    void Update()
    {
        if (!acceptsInput)
        {
            return;
        }

        float input = 0;

        if (myPaddle == PlayerPaddle.Paddle1)
        {
            input = Input.GetAxis("Vertical");
        }
        
        if(myPaddle == PlayerPaddle.Paddle2)
        {
            input = Input.GetAxis("Vertical2");
        }

        Vector3 newPosition = transform.position;

        newPosition.y += input * moveSpeed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, moveNegativeRange, movePositiveRange);

        transform.position = newPosition;
    }
}
