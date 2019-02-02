﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // ----- Grid related
    private RectTransform rt;                               // RectTransform Component of Grid to get width and height
    private int MAX_X, MAX_Y;                               // Max index in height and width (its twice+1 Tiles) depending on screensize and tileSize.

    [SerializeField] private Vector2 size;                  // Number of Tiles in X and Y direction. Should be later changeable for user
    private float tileSize = 32.0f;                         // Fix number from Sprite resolution indexSize * 2 +1. could be variable and get size from sprite himself maybe

    // ----- Tile related
    [SerializeField]
    private Tile tile;

    //Array of Tiles for weight
    private Tile[,] tileArray;

    //---------------------- Header END ----------------------

    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        GenerateGrid();
    }

    ///<summary> Initialze the Grid with the correct width and height </summary>
    void GenerateGrid()
    {
        // has to be a multiple of 32*32 so that the indexArray fit in
        MAX_X = (int)(rt.rect.width / tileSize);
        MAX_Y = (int)(rt.rect.height / tileSize);

        //init tileArray[][]
        tileArray = new Tile[MAX_X, MAX_Y];

        //for Debuging purpose only right now
        size.x = MAX_X;
        size.y = MAX_Y;


        //Forloop to instantiate Tiles
        for (int x = 0; x < MAX_X; x++)
        {
            for (int y = 0; y < MAX_Y; y++)
            {
                //Index
                Tile tileTmp = Instantiate<Tile>(tile, new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                tileTmp.xPos = x;
                tileTmp.yPos = y;
                tileArray[x, y] = tileTmp;
            }
        }
    }

    public Tile MyTileArray(int x, int y)
    {
        return tileArray[x, y];
    }


    ///<summary> Reset Grid if you want to restart Level OR make new one etc </summary>
    void ResetGrid()
    {

    }

}
