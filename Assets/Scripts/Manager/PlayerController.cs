using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera _cam;
    RaycastHit hit;
    public bool isDragging = false;
    //Local Variable
    Vector3 startPos;
    Rect selectionBox;
    private void Awake() {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Detect if mouse is down
        if(Input.GetMouseButtonDown(0)){
            //Create a ray to space
            var camRay = _cam.ScreenPointToRay(Input.mousePosition);

            //Shoot the ray and get the hit data
            if(Physics.Raycast(camRay, out hit)){
                if(hit.transform.CompareTag("PlayerUnit")){
                    //Select Unit
                    RTS_Manager.instance.SelectUnit(hit.transform.gameObject, Input.GetKey(KeyCode.LeftShift));
                }
                else if(hit.transform.CompareTag("BaseTerrain")){
                    //Deselect Unit
                    isDragging = true;
                    DragSelection();
                    RTS_Manager.instance.DeSelectAll();
                }
            }
        }

        if(Input.GetMouseButtonUp(0)){
            RTS_Manager.instance.DeSelectAll();
            foreach(var selectableObject in FindObjectsOfType<BoxCollider>()){
                if(IsInsideSelectionBox(selectableObject.transform)){
                    RTS_Manager.instance.SelectUnit(selectableObject.gameObject, true);
                }
            }
            isDragging = false;
        }

        if(Input.GetMouseButtonDown(1) && RTS_Manager.instance.SelectedUnitsCount > 0){
            var camRay = _cam.ScreenPointToRay(Input.mousePosition);

            //Shoot the ray to get data
            if(Physics.Raycast(camRay, out hit)){{
                if(hit.transform.CompareTag("BaseTerrain")){
                    RTS_Manager.instance.MoveUnits(hit.point);
                }
            }}
        }
    }

    private void DragSelection()
    {
        startPos  = Input.mousePosition;
    }

    private void OnGUI() {
        if(isDragging){
            selectionBox = ScreenHelper.GetScreenRect(startPos, Input.mousePosition);
            ScreenHelper.DrawScreenRect(selectionBox, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(selectionBox, 0.5f, Color.green);
        }
       
    }

    bool IsInsideSelectionBox(Transform transform){
        if(!isDragging){
            return false;
        }
        var viewPortBounds = ScreenHelper.GetViewportBounds(_cam, startPos, Input.mousePosition);
        return viewPortBounds.Contains(_cam.WorldToViewportPoint(transform.position));
    }
 
}
