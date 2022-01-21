using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Controller : MonoBehaviour
{
    private static Animator animator;

    enum State {Chu, Bo, Fang, Out};

    public int state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getBo() {
        Debug.Log("Player 1 got a Bo.");

        if (state != (int)State.Fang) {
            state = (int)State.Out;
            animator.SetTrigger("Out");
            Debug.Log("Player 1 is out.");
        }
    }

    private void OnMouseUpAsButton() {
        Debug.Log("click player 1");
    }
}
