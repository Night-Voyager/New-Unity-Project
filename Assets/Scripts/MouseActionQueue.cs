using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActionQueue : MonoBehaviour
{
    Queue mouseActionQueue = new Queue();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearQueue()
    {
        mouseActionQueue.Clear();
        Debug.Log("Mouse action queue cleared.");
    }
}
