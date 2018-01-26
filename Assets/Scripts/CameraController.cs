using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float targetOrtho;
    // Use this for initialization
    void Start() {
        targetOrtho = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1f;

        mouseMove(speed);
        zoom();

    }

    void mouseMove(float speed) {
        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0f);
    }

    void zoom() {
        float zoomSpeed = 1;

        float smoothSpeed = 1.0f;
        float minOrtho = 1.0f;
        float maxOrtho = 20.0f;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}

