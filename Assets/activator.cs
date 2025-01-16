using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class activator : MonoBehaviour
{
    private KeyCode key;

    public int chord;
   
    bool active = false;
    GameObject note;
    
    void Start()
    {      
        
    }

    void Update()
    {
        
        
        if (MVPInputChords.instance.isStrumming && MVPInputChords.instance.chord == chord && active)
        {
            Debug.Log("butt");
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
