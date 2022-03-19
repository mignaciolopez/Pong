using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] string axisName = "Vertical";
    [SerializeField] float speed = 12f;
    [SerializeField] float yBound = 6.6f;

    public bool aiControlled = false;

    GameObject ball;

    float verticalInput;
    public float aiDelay = 0.025f;

    bool coRoutine = false;

    private void Start()
    {
        ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if (aiControlled)
        {
            if (aiDelay <= 0f)
            {
                verticalInput = (transform.position.y < ball.transform.position.y) ? 1f : -1f;
            }
            else
            {
                if (!coRoutine)
                {
                    StartCoroutine(CalculateVerticalInput());
                    coRoutine = true;
                }
            }
        }
        else
        {
            verticalInput = Input.GetAxisRaw(axisName);
        }

        verticalInput *= speed * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y += verticalInput;
        pos.y = Mathf.Clamp(pos.y, -yBound, yBound);

        transform.position = pos;
    }

    public void RestartPosition()
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
    }

    IEnumerator CalculateVerticalInput()
    {
        //verticalInput = 0f;
        yield return new WaitForSeconds(aiDelay);
        verticalInput = (transform.position.y < ball.transform.position.y) ? 1f : -1f;
        coRoutine = false;
    }
}
