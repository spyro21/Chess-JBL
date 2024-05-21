using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class UserController : MonoBehaviour
{
    private static Mutex mut = new Mutex();
    private Transform dragging = null;
    private Vector3 prevPosition;
    private Piece currentPiece;
    private Vector3 offset;

    public ChessControl chessControl;


    // Update is called once per frame
    void Update()
    {   
        handleMouseControl();
    }
    private Vector3 getClosest(Vector3 position) {
        Vector3 newVector = new Vector3(0, 0, 0);
        if(position.x - math.floor(position.x) >= 0.5) {
            newVector.x = math.ceil(position.x);
        } else {
            newVector.x = math.floor(position.x);
        }

        if(position.y - math.floor(position.y) >= 0.5) {
            newVector.y = math.ceil(position.y);
        } else {
            newVector.y = math.floor(position.y);
        }
        return newVector;
    }

    private void handleMouseControl() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                            float.PositiveInfinity, LayerMask.GetMask("Movable"));

        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("mouse down");
            if(hit) {
                dragging = hit.transform;

                prevPosition = getClosest(dragging.position);
                currentPiece = dragging.gameObject.GetComponent<Piece>();

                //float over top other pieces
                hit.transform.GetComponent<SpriteRenderer>().sortingOrder = 3;

                //get offset
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        } else if (Input.GetMouseButtonUp(0)) {
            Debug.Log("mouse up");
            if(dragging && currentPiece) {
                dragging.position = getClosest(dragging.position);
                if(!chessControl.checkPosition(currentPiece, dragging.position, prevPosition)) {
                    dragging.position = prevPosition;
                    Debug.Log("ILLEGAL");
                } else {
                    chessControl.movePiece(currentPiece, dragging.position);
                    Debug.Log("LEGAL");
                }
                
                hit.transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
                dragging = null;
            }
        }

        if(dragging != null) {
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}


