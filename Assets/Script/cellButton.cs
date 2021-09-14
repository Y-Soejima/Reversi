using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellButton : MonoBehaviour
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
        if (panel.Cellchange(this.gameObject) == true)
        {
            panel.turn = panel.turn == Turn.blackTurn ? Turn.whiteTurn : Turn.blackTurn;
        }
        
    }
}
