using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeRules : GameState
{
    public List<Snap> Player1 = new List<Snap>(), Player2 = new List<Snap>();
    public int xStart, yStart, xEnd, yEnd, winLength, winner = -1;
    public GameObject grid;
    public Material red, blue, white;
    // Start is called before the first frame update
    void Start()
    {

    }
    public int[][] LastMap;

    // Update is called once per frame
    void Update()
    {
        int[][] map = new int[xEnd - xStart][];
        for (int k = 0; k < map.Length; k++)
            map[k] = new int[yEnd - yStart];
        LastMap = map;
        foreach (Snap p in Player1)
        {
            if (p != null)
                if (p.X < xEnd && p.Z < yEnd && p.X > xStart && p.Z > yStart)
                    map[p.X - xStart][p.Z - yStart] += 1;
        }
        foreach (Snap p in Player2)
        {
            if (p != null)
                if (p.X < xEnd && p.Z < yEnd && p.X > xStart && p.Z > yStart)
                    map[p.X - xStart][p.Z - yStart] += 2;
        }

        for (int player = 1; player <= 2; player++)
        {
            for (int k = xStart; k < xEnd; k++)
            {
                for (int i = yStart; i < yEnd; i++)
                {
                    if (k + winLength <= xEnd)
                    {
                        bool win = true;
                        for (int q = 0; q < winLength; q++)
                        {
                            if (map[k - xStart + q][i - yStart] != player)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            setWinner(player);
                            return;
                        } else
                        {
                            resetBoard();
                        }
                    }
                    if (i + winLength <= yEnd)
                    {
                        bool win = true;
                        for (int q = 0; q < winLength; q++)
                        {
                            if (map[k - xStart][i - yStart + q] != player)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            setWinner(player);
                            return;
                        }
                        else
                        {
                            resetBoard();
                        }
                    }
                    if (i + winLength <= yEnd && k + winLength <= xEnd)
                    {
                        bool win = true;
                        for (int q = 0; q < winLength; q++)
                        {
                            if (map[k - xStart + q][i - yStart + q] != player)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            setWinner(player);
                            return;
                        }
                        else
                        {
                            resetBoard();
                        }
                    }
                    if (i - yStart >= winLength - 1 && k + winLength <= xEnd)
                    {
                        bool win = true;
                        for (int q = 0; q < winLength; q++)
                        {
                            if (map[k - xStart + q][i - yStart - q] != player)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            setWinner(player);
                            return;
                        }
                        else
                        {
                            resetBoard();
                        }
                    }
                }
            }
        }
    }
    public override int[] GetState() => new int[] { winner };

    void setWinner(int player)
    {
        winner = player;
        print("Player " + player + " won!");
        if (player == 1)
        {
            grid.GetComponent<MeshRenderer>().material = red;
        }
        else
        {
            grid.GetComponent<MeshRenderer>().material = blue;
        }
    }

    void resetBoard()
    {
        grid.GetComponent<MeshRenderer>().material = white;
    }
}
