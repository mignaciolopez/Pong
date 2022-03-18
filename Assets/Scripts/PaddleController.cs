using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] string axisName = "Vertical";
    [SerializeField] float speed = 12f;
    [SerializeField] float yBound = 6.6f;

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw(axisName) * speed * Time.deltaTime;

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
}