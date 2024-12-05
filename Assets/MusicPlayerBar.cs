using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            collision.GetComponent<MusicNote>().PlayNote();
        }
    }
}
