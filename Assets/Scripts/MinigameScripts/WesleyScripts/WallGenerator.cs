using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        var cornerWallPosition = FindWallsInDirections(floorPositions, Direction2D.diagonalDirectionsList);
        createBasicWall(tilemapVisualizer, basicWallPositions, floorPositions);
        createCornerWalls(tilemapVisualizer, cornerWallPosition, floorPositions);
    }

    private static void createBasicWall(TileVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPosition)
    {
        foreach (var position in basicWallPositions)
        {
            string neighborsBinaryValue = "";
            
            foreach (var direction in Direction2D.cardinalDirectionsList)
            {
                var neighborPosition = position + direction;
                
                if (floorPosition.Contains(neighborPosition))
                {
                    neighborsBinaryValue += "1";
                }
                else
                {
                    neighborsBinaryValue += "0";
                }
            }

            tilemapVisualizer.paintSingleBasicWall(position, neighborsBinaryValue);
        }
    }

    private static void createCornerWalls(TileVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPosition)
    {
        foreach (var position in cornerWallPositions)
        {
            string neighborBinaryType = "";

            foreach (var direction in Direction2D.eightDirectionList)
            {
                var neighborPosition = position + direction;

                if (floorPosition.Contains(neighborPosition))
                {
                    neighborBinaryType += "1";
                }
                else
                {
                    neighborBinaryType += "0";
                }
            }

            tilemapVisualizer.paintSingleCornerWall(position, neighborBinaryType);
        }
    }


    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();

        foreach(var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighborPosition = position + direction;

                if (!floorPositions.Contains(neighborPosition))
                {
                    wallPositions.Add(neighborPosition);
                }
            }
        }

        return wallPositions;
    }
}
