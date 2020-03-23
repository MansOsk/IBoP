using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardRules : GameState
{
    public List<Snap> Player1 = new List<Snap>(), Player2 = new List<Snap>();
}
