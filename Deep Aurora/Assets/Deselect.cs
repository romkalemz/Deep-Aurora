using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour
{
    public GameObject Panel;

    void OnMouseUp() {
        Debug.Log("Deselected");
        if(Panel != null)
            Panel.SetActive(false);
    }

}
