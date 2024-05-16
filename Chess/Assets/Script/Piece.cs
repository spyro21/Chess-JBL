using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    string pieceType;
    (int x, int y) position;
    int team;

    public Piece(int team, string pieceType, (int x, int y) position)
    {
        this.pieceType = pieceType;
        this.position = position;
        this.team = team;
    }

    
}
