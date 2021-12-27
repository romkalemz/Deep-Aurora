using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject Panel;
    Transform target;
    Camera cam;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    private bool startedHolding = false;
    public float holdTimer = 1.0f;  // in seconds


    void OnMouseDrag() {
        startedHolding = true;
        
    }

    void OnMouseUp() {
        OpenMenu();
        startedHolding = false;
        holdTimer = 1.0f;

    }

    public void OpenMenu() {
        if(Panel != null) {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        target = GetComponent<Transform>();
        
        // display whie outline of selected item
        // the outline will be determined by shape of object selected
        // (starship - triangle, station - hexagon, planet - circle, astroid - square)

        // highlight sonar range of selected item?


    }

    // Update is called once per frame
    void Update()
    {
        // update holdTimer
        if(startedHolding == true) {
            holdTimer -= Time.deltaTime;
            if(holdTimer <= 0) {
                mouse_pos = Input.mousePosition;
                //mouse_pos.z = -20;
                object_pos = cam.WorldToScreenPoint(target.position);
                mouse_pos.x = mouse_pos.x - object_pos.x;
                mouse_pos.y = mouse_pos.y - object_pos.y;
                angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                target.rotation = Quaternion.Euler(0, 0, angle - 90);
                // display drag animation for movement
                Debug.Log("Holding...");
                //rb.rotation = cam.ScreenToWorldPoint(Input.mousePosition).;
            }
        }
    }
}
