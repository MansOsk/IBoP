using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vikingGameRules : BoardRules
{
    private int[][] board;
    public int redPieces, bluePieces;
    public int xStart, yStart, xEnd, yEnd, winner = -1;
    public GameObject king;
    public Material red, green, blue;
    public SnapObjectList SnapObjects;
    //public GameObject VikingGrid;

    // Start is called before the first frame update
    void Start()
    {






    }

    // Update is called once per frame
    void Update()
    {
        //Creates the X lenght of the board
        board = new int[xEnd - xStart][];
        
        //Creates the Y lenght of the board
        for (int k = 0; k < board.Length; k++)
            board[k] = new int[yEnd - yStart];

        foreach (Snap p in Player1) //red pieces has value 1
        {
            if (p != null)
                if (p.X < xEnd && p.Z < yEnd && p.X > xStart && p.Z > yStart)
                    board[p.X - xStart][p.Z - yStart] = 1;
        }

        foreach (Snap p in Player2) //blue pieces has value 2
        {
            if (p != null)
                if (p.X < xEnd && p.Z < yEnd && p.X > xStart && p.Z > yStart)
                {
                    string[] tag = p.tag.Split(',');
                    if (tag.Length >= 2)
                    {
                        if (tag[1] == "King")
                        {
                            board[p.X - xStart][p.Z - yStart] = 3;
                        }
                        else
                        {
                            board[p.X - xStart][p.Z - yStart] = 2;
                        }
                    }
                    else
                    {
                        board[p.X - xStart][p.Z - yStart] = 2;
                    }
                }
        }

        //Here the all rules are checked
        for (int player = 1; player <= 2; player++)
        {
            for (int x = 0; x < xEnd - xStart; x++)
            {
                for (int y = 0; y < yEnd - yStart; y++)
                {

                    if (board[x][y] == 3 && KingSurrounded(x, y))
                    {
                        SetWinner(1);
                        return;
                    }
                   


                    if (KingAtCorner())
                    {
                        SetWinner(2);
                        return;
                    }
                   



                    if (GamePieceSurrounded(x, y))
                    {
                        
                        for (int k = 0; k < SnapObjects.Snaps.Count; k++)
                        {
                            if (SnapObjects.Snaps[k].X == x-5  && SnapObjects.Snaps[k].Z == y-5 )
                            {       
                                    Destroy(SnapObjects.Snaps[k].gameObject);
                                    SnapObjects.Snaps.RemoveAt(k);
                                    break;

                     
                            }
                        }
                        

                        if (player == 1)
                        {
                            redPieces--;
                        }
                        else
                        {
                            bluePieces--;
                        }

                        if (redPieces == 0)
                        {
                            SetWinner(2);
                            return;
                        }
                        else if (bluePieces == 0)
                        {
                            SetWinner(1);
                            return;
                        }
                       
                    }
                }
            }
        }
    }

    bool KingSurrounded(int x, int y)
    {

        if (x == 1)
        {
            int north = board[x][y - 1];
            int south = board[x][y + 1];
            int east = board[x + 1][y];
            if (north == 1 && south == 1 && east == 1) // surrounded on 3 sides + left border
            {
                return true;
            }
        }
        else if (x == xEnd - xStart-1)
        {
            int north = board[x][y - 1];
            int south = board[x][y + 1];
            int west = board[x - 1][y];
            if (north == 1 && south == 1 && west == 1) // surrounded on 3 sides + right border
            {
                return true;
            }
        }
        else if (y == 1)
        {
            int south = board[x][y + 1];
            int west = board[x - 1][y];
            int east = board[x + 1][y];
            if (east == 1 && south == 1 && west == 1) // surrounded on 3 sides + top border
            {
                return true;
            }
        }
        else if (y == yEnd - yStart-1)
        {
            int north = board[x][y - 1];
            int west = board[x - 1][y];
            int east = board[x + 1][y];
            if (east == 1 && north == 1 && west == 1) // surrounded on 3 sides + bottom border
            {
                return true;
            }
        }
        else
        {
            int north = board[x][y - 1];
            int south = board[x][y + 1];
            int east = board[x + 1][y];
            int west = board[x - 1][y];
            if (north == 1 && south == 1 && east == 1 && west == 1)
            {
                return true;
            }
        }
        return false;
    }

    bool KingAtCorner()
    {
        if (board[1][1] == 3 || board[xEnd-xStart-1][1] == 3 || board[1][yEnd - yStart-1] == 3 || board[xEnd - xStart-1][yEnd - yStart-1] == 3)
        {
            return true; 
        }
        else
        {
            return false;
        }
    }

    bool GamePieceSurrounded(int x, int y)
    {
        if (board[x][y] == 1)
        {
            if (board[x][y - 1] == 2 && board[x][y + 1] == 2) //check north and south
                {
                    return true;
                }
                else if (board[x - 1][y] == 2 && board[x + 1][y] == 2) //check west and east
                {
                    return true;
                }
        } else if (board[x][y] == 2)
        {
            if (board[x][y - 1] == 1 && board[x][y + 1] == 1) //check north and south
            {
                return true;
            }
            else if (board[x - 1][y] == 1 && board[x + 1][y] == 1) //check west and east
            {
                return true;
            }
        }
        return false;
    }

    public override int[] GetState() => new int[] { winner };

    void SetWinner(int player)
    {
        winner = player;
        print("Player " + player + " won!");
        if (player == 1)
        {
            
            //king.GetComponent<MeshRenderer>().material = red;
            //VikingGrid.SetActive(false);

        }
        else
        {
            //Destroy(king);
            //king.GetComponent<MeshRenderer>().material = blue;
            //VikingGrid.SetActive(false);

        }
    }

    

}