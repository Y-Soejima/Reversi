using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    None,
    Black,
    White,
}
public class Cell : MonoBehaviour
{
    public CellState isBlack = CellState.None;
    public int cellStateNum = 0;
    public int v_cell;
    public int h_cell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StateChange(Cell cell)
    {
        var button = cell.gameObject.GetComponentInChildren<Button>();
        ColorBlock buttonColor = button.colors;
        if (cellStateNum == (int)CellState.Black)
        {
            buttonColor.normalColor = Color.black;
            buttonColor.selectedColor = Color.black;
            button.colors = buttonColor;
            cell.isBlack = CellState.Black;
        }
        else if (cellStateNum == (int)CellState.White)
        {
            buttonColor.normalColor = Color.white;
            buttonColor.selectedColor = Color.white;
            button.colors = buttonColor;
            cell.isBlack = CellState.White;
        }
        else
        {
            buttonColor.normalColor = Color.green;
            buttonColor.selectedColor = Color.green;
            button.colors = buttonColor;
        }
    }
}
