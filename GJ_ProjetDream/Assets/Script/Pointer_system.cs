using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PointerSystem : MonoBehaviour
{

    //Camera camera;
    Vector3 mousepos;
    Vector3 mousePosForward;
    private Vector2 cursorHotSpot;
    public Texture2D[] textureArrayNigthmare;
    public Texture2D[] textureArrayDream;
    private Texture2D[] textureArrayUsed;
    private bool isUsableItem;

    void Start()
    {
        //camera = Camera.main;
        mousepos = Input.mousePosition;
        mousepos.z = 0;
        mousePosForward = mousepos;
        mousePosForward.z = 100000;
        if (true)  // à modifier avec valeurchangement monde
        {
            textureArrayUsed = textureArrayDream;
        }
        else
        {
            textureArrayUsed = textureArrayNigthmare;
        }
        cursorHotSpot = new Vector2 (textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
        Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
    }

    void Update()
    {
        mousepos = Input.mousePosition;
        mousepos.z = 0;
        mousePosForward = mousepos;
        mousePosForward.z = 100000;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);            
        if (Physics.Raycast(ray, out hit, 10000))
        {
            if(hit.transform.GetComponent<Item>() != null) 
            {
                if (hit.transform.GetComponent<Item>().isUsable)
                {
                    switch (hit.transform.GetComponent<Item>().item_SO.objectType)
                    {
                         case ObjectType.interactible:
                             cursorHotSpot = new Vector2(textureArrayUsed[1].width / 2, textureArrayUsed[1].height / 2);
                             Cursor.SetCursor(textureArrayUsed[1], cursorHotSpot, CursorMode.Auto);
                             break;
                         case ObjectType.talkable:
                             cursorHotSpot = new Vector2(textureArrayUsed[3].width / 2, textureArrayUsed[3].height / 2);
                             Cursor.SetCursor(textureArrayUsed[3], cursorHotSpot, CursorMode.Auto);
                             break;
                         case ObjectType.sceneChangeEast:

                             break;
                         case ObjectType.sceneChangeWest:

                             break;
                         case ObjectType.sceneChangeSouth:

                             break;
                         case ObjectType.sceneChangeNorth:
                             cursorHotSpot = new Vector2(textureArrayUsed[4].width / 2, textureArrayUsed[4].height / 2);
                             Cursor.SetCursor(textureArrayUsed[4], cursorHotSpot, CursorMode.Auto);
                             break;
                         case ObjectType.defaultType:
                             cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
                             Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
                             break;
                         default:
                            cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
                            Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
                            break;
                    }
                }
                else
                {
                    cursorHotSpot = new Vector2(textureArrayUsed[2].width / 2, textureArrayUsed[2].height / 2);
                    Cursor.SetCursor(textureArrayUsed[2], cursorHotSpot, CursorMode.Auto);
                }
                Debug.Log("UnderMouse: " + hit.transform.GetComponent<Item>().item_SO.name);
            }
            else
            {
                cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
                Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Clickhit;
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(clickRay, out Clickhit, 10000))
            {
                Debug.Log("Clicked: " + Clickhit.rigidbody.name);
                if (Clickhit.collider.gameObject.layer.Equals(0)) //"Displacement_area"
                {
                    //spriteArray[0];
                }
                if (Clickhit.collider.gameObject.layer.Equals(1)) //= "Interactible_object"
                {
                    //spriteArray[1];
                }
                if (Clickhit.collider.gameObject.layer.Equals(2)) //"See_object"
                {
                    //spriteArray[2];
                }
            }  
        }
    }

    private void CursorChange()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit, 10000))
        {
            return;
        }

        if (hit.transform.GetComponent<Item>() == null)
        {
            cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
            Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
            return;
        }


        if (!hit.transform.GetComponent<Item>().isUsable)
        {
            cursorHotSpot = new Vector2(textureArrayUsed[2].width / 2, textureArrayUsed[2].height / 2);
            Cursor.SetCursor(textureArrayUsed[2], cursorHotSpot, CursorMode.Auto);
            return;
        }



        switch (hit.transform.GetComponent<Item>().item_SO.objectType)
        {
            case ObjectType.interactible:
                cursorHotSpot = new Vector2(textureArrayUsed[1].width / 2, textureArrayUsed[1].height / 2);
                Cursor.SetCursor(textureArrayUsed[1], cursorHotSpot, CursorMode.Auto);
                break;
            case ObjectType.talkable:
                cursorHotSpot = new Vector2(textureArrayUsed[3].width / 2, textureArrayUsed[3].height / 2);
                Cursor.SetCursor(textureArrayUsed[3], cursorHotSpot, CursorMode.Auto);
                break;
            case ObjectType.sceneChangeEast:

                break;
            case ObjectType.sceneChangeWest:

                break;
            case ObjectType.sceneChangeSouth:

                break;
            case ObjectType.sceneChangeNorth:
                cursorHotSpot = new Vector2(textureArrayUsed[4].width / 2, textureArrayUsed[4].height / 2);
                Cursor.SetCursor(textureArrayUsed[4], cursorHotSpot, CursorMode.Auto);
                break;
            case ObjectType.defaultType:
                cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
                Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
                break;
            default:
                cursorHotSpot = new Vector2(textureArrayUsed[0].width / 2, textureArrayUsed[0].height / 2);
                Cursor.SetCursor(textureArrayUsed[0], cursorHotSpot, CursorMode.Auto);
                break;
        }

        Debug.Log("UnderMouse: " + hit.transform.GetComponent<Item>().item_SO.name);


    }

}

//cursorHotSpot = new Vector2(textureArrayUsed[2].width / 2, textureArrayUsed[2].height / 2);
//Cursor.SetCursor(textureArrayUsed[2], cursorHotSpot, CursorMode.Auto);