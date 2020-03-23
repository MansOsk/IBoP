using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Snap för vikingGame
///ärver detta från snap
///public SnapObjectList SnapObjectList;
///public bool SnapTo = true;
///public float size = 0.6666666666666667f;
///public float snapSpeed = 16f, offset = 0;
///const int s = 1;
///public int X, Y, Z;
/// </summary>
public class SnapVikingGame : Snap
{
    //Used at startUp to be alble to bypass some rules
    private bool FollowedRule;
    private int NumberOfSnapObjects = 0;
    
    // Update is called once per frame
    protected override void Update()
    {

        // Snap
        if (Input.touchCount <= 0)
        {
            int x = (int)Mathf.Round((transform.localPosition.x - offset) / size);
            int y = (int)Mathf.Round((transform.localPosition.y - offset) / size);
            int z = (int)Mathf.Round((transform.localPosition.z - offset) / size); // Hittar vart vi ska snapa
            
            bool insideOfborders = x < SnapObjectList.XMax && x > SnapObjectList.XMin && y < SnapObjectList.YMax && y > SnapObjectList.YMin 
                && z < SnapObjectList.ZMax && z > SnapObjectList.ZMin;

            
            if (NumberOfSnapObjects < SnapObjectList.Snaps.Count)
            {//Makes sure that every object affected by snap gets placed before a game starts.
                NumberOfSnapObjects++;
                FollowedRule = true;
            }
            else if(FollowedRule)
            {
                FollowedRule = checkMoveRules(x, y, z);
            }

            

            //Här sätts den nya positionen
            if (insideOfborders && FollowedRule)
            {
                this.X = x;
                this.Y = 0; //Makes it so that it always snaps to the level of the board.
                this.Z = z;
            }

            //Flyttar till gamla eller nya positionen
            Vector3 vec = new Vector3(X * size + offset, Y * size + offset, Z * size + offset);
            vec -= transform.localPosition;
            vec *= snapSpeed; // Snap fart

            Vector3 trans = new Vector3( // skalar från local till world
                vec.x * transform.localScale.x,
                vec.y * transform.localScale.y,
                vec.z * transform.localScale.z);
            gameObject.transform.Translate(trans); // Flyttar till mitten av rutan

            if (this.X == x && this.Z == z)
            {
                FollowedRule = true;
            }


        }
        // Snap end
    }

    private bool checkMoveRules(int x, int y, int z)
    {
        if (this.X != x && this.Z != z)
        {
            return false;
        }

        //snap.X och snap.Z är de "gammala" kordinaterna
        foreach (SnapVikingGame snap in SnapObjectList.Snaps)
        {
            if (snap.X == x && snap.Z == z && snap.gameObject != gameObject)// Kollar om det står en pjäs på den positionen.
            {
                return false;
            }

            if (snap.X == this.X && ((z > snap.Z && snap.Z > this.Z) || (snap.Z < this.Z && snap.Z > z )) )
            {
                return false;
            }

            if (snap.Z == this.Z && ((snap.X < x && snap.X > this.X) || (snap.X > x && snap.X < this.X)) )
            {
                return false;
            }
            
            /*
            if ((snap.Z > (x+1) || (x-1) > snap.Z) && (snap.X > (x+1) || (x-1) > snap.X))
            {
                return false;
            }
            */
        }

        return true;
    }
}
