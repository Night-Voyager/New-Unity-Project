using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_0_Controller : MonoBehaviour
{
    private Renderer playerRenderer;

    enum State {Chu, Bo, Fang, Out};

    public int state;
    public int qi;

    public int blinkNumber;
    public float blinkTime;

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
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
            EventManager.DispatchEvent("ClickBo");
        }
        else
        {
            state = (int)State.Out;
            Debug.Log("You are out.");
            Blink();
        }
    }

    public void Fang()
    {
        Debug.Log("防");
        state = (int)State.Fang;
    }

    void Blink()
    {
        StartCoroutine(DoSomeBlinks(blinkNumber, blinkTime));
    }

    IEnumerator DoSomeBlinks(int number, float time)
    {
        for (int i=0; i<number; i++)
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            yield return new WaitForSeconds(time);
        }
        GetComponent<Renderer>().enabled = true;
    }
}
