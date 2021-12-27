using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    Rigidbody2D rb;
    Camera cam;

    void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("started");
    }
    void onMouseDown() {
        Debug.Log("clicked");
    }

    void onMouseUp() {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("released");
    }

}
