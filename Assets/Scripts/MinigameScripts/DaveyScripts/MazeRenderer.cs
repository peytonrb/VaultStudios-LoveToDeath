using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [Range(1, 50)]
    public int width = 10;

    [Range(1, 50)]
    public int height = 10;
    public Transform wallPrefab;
    private float cellSize = 1f;

    void Start()
    {
        WallState[,] maze = MazeGenerator.Generate(width, height);
        draw(maze);
    }

    private void draw(WallState[,] maze)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = maze[i, j];
                Vector3 position = new Vector3(-width/2 + i, 0, -height/2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, cellSize / 2);
                    topWall.localScale = new Vector3(cellSize, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-cellSize / 2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                    leftWall.localScale = new Vector3(cellSize, leftWall.localScale.y, leftWall.localScale.z);
                }

                if (i == width - 1) // last row
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(cellSize / 2, 0, 0);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                        rightWall.localScale = new Vector3(cellSize, rightWall.localScale.y, rightWall.localScale.z);
                    }
                }

                if (j == 0) // first row
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -cellSize / 2);
                        bottomWall.localScale = new Vector3(cellSize, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}
