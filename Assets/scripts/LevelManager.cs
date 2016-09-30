﻿using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 30;
    public int rows = 200;
    public int spaceBetween = 2;
    public Count barrierCount = new Count(20, 25);
    public Count lightCount = new Count(10, 15);
    public GameObject OuterWall;
    public GameObject barrier;
    public GameObject lightRay;
    public GameObject player;

    private Transform levelHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    void LevelSetup()
    {
        levelHolder = new GameObject("Level").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                if (x == -1 || x == columns)
                {
                    GameObject toInstantiate = OuterWall;
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0.0f), Quaternion.identity) as GameObject;

                    instance.transform.SetParent(levelHolder);
                }
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    //bool CheckSurroundings(int _index, int _height, int _width)
    //{
    //    //Debug.Log("Hi!");
    //    for (int y = -_height / 2; y < _height/2; y++)
    //    {
    //        //Debug.Log("Loop!");
    //        for (int x = -_width / 2; x < _width/2; x++)
    //        {
    //            int newIndex = _index + ((rows * y) + ((y * -2) - 1) - ((y + 1) * rows) + (-1 + ((y + 1) * 3)) + (rows * (x + 1)) + ((x * -2) - 1));

    //            if (newIndex <= gridPositions.Count && newIndex >= 0)
    //            {
    //                //string log = "New Index: " + newIndex + "   Index: " + _index;
    //                //Debug.Log(log);

    //                Vector3 currentPosition = gridPositions[_index];
    //                Vector3 newPosition = new Vector3(currentPosition.x + x, currentPosition.y + y, 0.0f);

    //                string log = "New Index: " + newIndex + "   Index: " + _index + "\nNew Vector: " + newPosition.x + ", " + newPosition.y
    //                    + " Current Vector: " + currentPosition.x + ", " + currentPosition.y + " Check Vector: " + gridPositions[newIndex].x + ", " + gridPositions[newIndex].y;
    //                Debug.Log(log);

    //                if (gridPositions[newIndex] != newPosition)
    //                {
    //                    //Debug.Log("Too Close!");
    //                    return false;
    //                }
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //    }

    //    return true;
    //}

    void LayoutObjectAtRandom(GameObject tile, int minimum, int maximum, int _height, int _width)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            CreateClump(tile, randomPosition, _height, _width);
        }
    }

    void CreateClump(GameObject tile, Vector3 _currentPosition, int _width, int _height)
    {
        for (int y = 0; y < _height; y++)
        {
            //Debug.Log("Loop!");
            for (int x = 0; x < _width; x++)
            {
                Vector3 newPosition = new Vector3(_currentPosition.x + x, _currentPosition.y + y, 0.0f);
                if(newPosition.x >= 0 && newPosition.x <= columns)
                {
                    Instantiate(tile, newPosition, Quaternion.identity);
                }
            }
        }
    }


    public void SetupScene()
    {
        LevelSetup();
        InitialiseList();
        Instantiate(player, new Vector3((columns / 2) - 1.0f, 1.0f, 0.0f), Quaternion.identity);
        LayoutObjectAtRandom(barrier, barrierCount.minimum, barrierCount.maximum, 5, 2);
        LayoutObjectAtRandom(lightRay, lightCount.minimum, lightCount.maximum, 1, 10);
    }
}