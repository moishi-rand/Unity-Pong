using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float limitSpeed = 20f;
    [SerializeField] private float speedIncrease = 0.25f;

    private float currentSpeed;
    private Vector2 currentDir;
    [SerializeField]
    private Vector3 startPos;
    private bool isReset = false;

    private void Start()
    {
        currentSpeed = startSpeed;
        transform.position = startPos;
        currentDir = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        if (isReset)
        {
            return;
        }

        Vector2 moveDir = currentDir * currentSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveDir.x, moveDir.y, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            currentDir.y *= -1;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            currentDir.x *= -1;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(ResetGame());
            other.GetComponent<Goal>().AddPoint();
        }
        else if(other.gameObject.CompareTag("AddBall"))
        {
            other.GetComponent<AddBall>().AddBallToGame();
            Destroy(other.gameObject);
        }


        currentSpeed += speedIncrease;
        currentSpeed = Mathf.Clamp(currentSpeed, startSpeed, limitSpeed);

    }
    
    private IEnumerator ResetGame()
    {
        isReset = true;
        currentSpeed = 0;
        yield return new WaitForSeconds(3);
        Start();
        isReset = false;
    }
}
