using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    Panel panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = FindObjectOfType<Panel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        panel.turn = panel.turn == Turn.blackTurn ? Turn.whiteTurn : Turn.blackTurn;
    }
}
