using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGuideBall : MonoBehaviour
{
    public GuideBall guideBall; // Reference to the GuideBall script
    private bool isMoving = false;

    void Update()
    {
        // Start moving the GuideBall when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
            StartCoroutine(MoveGuideBall());
        }
    }

    IEnumerator MoveGuideBall()
    {
        int currentIndex = 0;

        while (isMoving)
        {
            guideBall.MoveToPosition(currentIndex);

            // Wait for some time before moving to the next position
            yield return new WaitForSeconds(2.0f);

            // Move to the next position in the array
            currentIndex = (currentIndex + 1) % guideBall.positions.Length;
        }
    }
}
