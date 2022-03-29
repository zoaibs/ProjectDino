using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipOnClicks : MonoBehaviour
{
    public float clicksNeeded;
    float clicks;
    Vector3 newScale;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicks += 1;
        }
        if (clicks == clicksNeeded)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            clicks = -9999;
        }
    }
    
}
