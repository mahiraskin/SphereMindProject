using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location : MonoBehaviour
{
    public int loc = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Moved()
    {
        if (transform.position.x >= 160)
        { loc = 1; }
        else if (transform.position.x >= 80 )
        { loc = 2; }
        else if (transform.position.x >= 0 )
        { loc = 3; }
        else if (transform.position.x >= -80 )
        { loc = 4; }
        else if (transform.position.x >= -160 )
        { loc = 5; }
        else
        { loc = 6; }

    }
  
    void Update()
    {
        Moved();
        
    }
}
