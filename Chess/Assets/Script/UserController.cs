using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UserController : MonoBehaviour
{

    private Transform dragging = null;
    private Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                                            //float.PositiveInfinity, LayerMask.GetMask("Movable"));

            if(hit) {
                dragging = hit.transform;
                hit.transform.GetComponent<SpriteRenderer>().sortingOrder = 3;
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //offset.x = math.floor(offset.x);
                //offset.y = math.floor(offset.y);
            }
        } else if (Input.GetMouseButtonUp(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            dragging.position = getClosest(dragging.position);
            hit.transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
            dragging = null;
        }

        if(dragging != null) {
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
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
}
