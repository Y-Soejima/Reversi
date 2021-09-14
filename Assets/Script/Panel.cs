using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Turn
{
    blackTurn = 1,
    whiteTurn = 2,
}
public class Panel : MonoBehaviour
{
    [SerializeField] Cell cellPrefab;
    [SerializeField] Cell[,] cellArray = new Cell[8, 8];
    [SerializeField] GridLayoutGroup panel;
    public Turn turn = Turn.blackTurn;
    // Start is called before the first frame update
    void Start()
    {
        CellSet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CellSet()
    {
        for (int i = 0; i < cellArray.GetLength(0); i++)
        {
            for (int k = 0; k < cellArray.GetLength(1); k++)
            {
                var cell = Instantiate(cellPrefab);
                cell.transform.SetParent(panel.transform);
                cellArray[i, k] = cell;
                cellArray[i, k].v_cell = i;
                cellArray[i, k].h_cell = k;
                if (i == 3 && k == 3 || i == 4 && k == 4)
                {
                    cellArray[i, k].cellStateNum = (int)CellState.Black;
                }
                else if (i == 3 && k == 4 || i == 4 && k == 3)
                {
                    cellArray[i, k].cellStateNum = (int)CellState.White;
                }
                else
                {
                    cellArray[i, k].isBlack = CellState.None;
                }
                cellArray[i, k].StateChange(cellArray[i, k]);
            }
        }
    }

    public bool Cellchange(GameObject button)
    {
        var cell = button.GetComponentInParent<Cell>();
        bool turnChange = false;
        int v = cell.v_cell;
        int h = cell.h_cell;
        if (cell.isBlack == CellState.None)
        {
            if (v != 0)
            {
                if (h != 0)
                {
                    if (cellArray[v - 1, h - 1].cellStateNum != (int)turn && cellArray[v - 1, h - 1].isBlack != CellState.None)
                    {
                        int enemyCell = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                for (int k = 2; k < 8; k++)
                                {
                                    if (v - k < 0 || h - k < 0 || cellArray[v - k, h - k].isBlack == CellState.None) { break; }
                                    if (cellArray[v - k, h - k].cellStateNum == (int)turn)
                                    {
                                        enemyCell = k;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < enemyCell; k++)
                                {
                                    cellArray[v - k, h - k].cellStateNum = (int)turn;
                                    cellArray[v - k, h - k].StateChange(cellArray[v - k, h - k]);
                                    turnChange = true;
                                }
                            }
                        }
                        
                    }
                }
                if (cellArray[v - 1, h].cellStateNum != (int)turn && cellArray[v - 1, h].isBlack != CellState.None)
                {
                    int enemyCell = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            for (int k = 2; k < 8; k++)
                            {
                                if (v - k < 0 || cellArray[v - k, h].isBlack == CellState.None) { break; }
                                if (cellArray[v - k, h].cellStateNum == (int)turn)
                                {
                                    enemyCell = k;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < enemyCell; k++)
                            {
                                cellArray[v - k, h].cellStateNum = (int)turn;
                                cellArray[v - k, h].StateChange(cellArray[v - k, h]);
                                turnChange = true;
                            }
                        }
                    }
                }
                if (h != 7)
                {
                    if (cellArray[v - 1, h + 1].cellStateNum != (int)turn && cellArray[v - 1, h + 1].isBlack != CellState.None)
                    {
                        int enemyCell = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                for (int k = 2; k < 8; k++)
                                {
                                    if (v - k < 0 || h + k > cellArray.GetLength(1) - 1 || cellArray[v - k, h + k].isBlack == CellState.None) { break; }
                                    if (cellArray[v - k, h + k].cellStateNum == (int)turn)
                                    {
                                        enemyCell = k;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < enemyCell; k++)
                                {
                                    cellArray[v - k, h + k].cellStateNum = (int)turn;
                                    cellArray[v - k, h + k].StateChange(cellArray[v - k, h + k]);
                                    turnChange = true;
                                }
                            }
                        }
                    }
                }
            }
            if (h != 0)
            {
                if (cellArray[v, h - 1].cellStateNum != (int)turn && cellArray[v, h - 1].isBlack != CellState.None)
                {
                    int enemyCell = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            for (int k = 2; k < 8; k++)
                            {
                                if (h - k < 0 || cellArray[v, h - k].isBlack == CellState.None) { break; }
                                if (cellArray[v, h - k].cellStateNum == (int)turn)
                                {
                                    enemyCell = k;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < enemyCell; k++)
                            {
                                cellArray[v, h - k].cellStateNum = (int)turn;
                                cellArray[v, h - k].StateChange(cellArray[v, h - k]);
                                turnChange = true;
                            }
                        }
                    }
                }
            }
            if (h != 7)
            {
                if (cellArray[v, h + 1].cellStateNum != (int)turn && cellArray[v, h + 1].isBlack != CellState.None)
                {
                    int enemyCell = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            for (int k = 2; k < 8; k++)
                            {
                                if (h + k > cellArray.GetLength(1) - 1 || cellArray[v, h + k].isBlack == CellState.None) { break; }
                                if (cellArray[v, h + k].cellStateNum == (int)turn)
                                {
                                    enemyCell = k;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < enemyCell; k++)
                            {
                                cellArray[v, h + k].cellStateNum = (int)turn;
                                cellArray[v, h + k].StateChange(cellArray[v, h + k]);
                                turnChange = true;
                            }
                        }
                    }
                }
            }
            if (v != 7)
            {
                if (h != 0)
                {
                    if (cellArray[v + 1, h - 1].cellStateNum != (int)turn && cellArray[v + 1, h - 1].isBlack != CellState.None)
                    {
                        int enemyCell = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                for (int k = 2; k < 8; k++)
                                {
                                    if (v + k > cellArray.GetLength(0) - 1 || h - k < 0 || cellArray[v + k, h - k].isBlack == CellState.None) { break; }
                                    if (cellArray[v + k, h - k].cellStateNum == (int)turn)
                                    {
                                        enemyCell = k;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < enemyCell; k++)
                                {
                                    cellArray[v + k, h - k].cellStateNum = (int)turn;
                                    cellArray[v + k, h - k].StateChange(cellArray[v + k, h - k]);
                                    turnChange = true;
                                }
                            }
                        }
                    }
                }
                if (cellArray[v + 1, h].cellStateNum != (int)turn && cellArray[v + 1, h].isBlack != CellState.None)
                {
                    int enemyCell = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            for (int k = 2; k < 8; k++)
                            {
                                if (v + k > cellArray.GetLength(0) - 1 || cellArray[v + k, h].isBlack == CellState.None) { break; }
                                if (cellArray[v + k, h].cellStateNum == (int)turn)
                                {
                                    enemyCell = k;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < enemyCell; k++)
                            {
                                cellArray[v + k, h].cellStateNum = (int)turn;
                                cellArray[v + k, h].StateChange(cellArray[v + k, h]);
                                turnChange = true;
                            }
                        }
                    }
                }
                if (h != 7)
                {
                    if (cellArray[v + 1, h + 1].cellStateNum != (int)turn && cellArray[v + 1, h + 1].isBlack != CellState.None)
                    {
                        int enemyCell = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                for (int k = 2; k < 8; k++)
                                {
                                    if (v + k > cellArray.GetLength(0) - 1 || h + k > cellArray.GetLength(1) - 1 || cellArray[v + k, h + k].isBlack == CellState.None) { break; }
                                    if (cellArray[v + k, h + k].cellStateNum == (int)turn)
                                    {
                                        enemyCell = k;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < enemyCell; k++)
                                {
                                    cellArray[v + k, h + k].cellStateNum = (int)turn;
                                    cellArray[v + k, h + k].StateChange(cellArray[v + k, h + k]);
                                    turnChange = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return turnChange;
    }
}
