using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActionStack : MonoBehaviour
{
    Stack mouseActionStack = new Stack();

    // Awake is called when initializing
    void Awake() {
        EventManager.AddEvent("ClickBo", ClickBo);
        EventManager.AddEvent<string>("ClickPlayer", ClickPlayer);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearStack()
    {
        mouseActionStack.Clear();
        Debug.Log("Mouse action stack cleared.");
    }

    private void ClickPlayer(string s)
    {
        Debug.Log(s);
    }

    private void ClickBo()
    {
        Debug.Log("sBo");
    }
}
