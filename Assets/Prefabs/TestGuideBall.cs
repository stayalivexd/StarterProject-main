using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGuideBall : MonoBehaviour
{
    public GuideBall guideBall; // Reference to the GuideBall script

    void Update()
    {
        // Move the GuideBall to a random position when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, guideBall.positions.Length);
            guideBall.MoveToPosition(randomIndex);
        }
    }
}
