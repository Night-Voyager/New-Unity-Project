using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_0_Controller : MonoBehaviour
{
    enum State {Chu, Bo, Fang, Out};

    public int state;
    public int qi;

    // Start is called before the first frame update
    void Start()
    {
        state = (int)State.Chu;
        qi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chu()
    {
        Debug.Log("储");
        state = (int)State.Chu;
        qi++;
    }

    public void Bo()
    {
        Debug.Log("波");
        if (qi > 0)
        {
            state = (int)State.Bo;
            qi--;
        }
        else
        {
            state = (int)State.Out;
            Debug.Log("You are out.");
        }
    }

    public void Fang()
    {
        Debug.Log("防");
        state = (int)State.Fang;
    }
}
