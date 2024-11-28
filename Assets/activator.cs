using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{

    public KeyCode key;
    bool active = false;
    GameObject note;
    void Start()
    {
        
    }

   
    void Update()
    {
            if (Input.GetKeyDown(key) && active)
            {
                Debug.Log("butt");
               // Destroy(note);
                Destroy(gameObject);
        }
           
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag =="Note")
            note = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }
}
