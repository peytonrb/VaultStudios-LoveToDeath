using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallState
{
    LEFT = 1, // 0001 <- bit numbers, disregard
    RIGHT = 2, // 0010
    UP = 4, // 0100
    DOWN = 8, // 1000 <- first bit
    VISITED = 128, // 1000 0000 
}

// keeps track of where recursion is happening in the maze
public struct Position
{
    public int x;
    public int y;
}

public struct Neighbor
{
    public Position Position;
    public WallState SharedWall;
}

public static class MazeGenerator
{
    private static WallState getOppositeWall(WallState wall)
    {
        switch(wall)
        {
            case WallState.RIGHT: return WallState.LEFT;
            case WallState.LEFT: return WallState.RIGHT;
            case WallState.DOWN: return WallState.UP;
            case WallState.UP: return WallState.DOWN;
            default: return WallState.LEFT;
        }
    }

    private static WallState[,] applyRecursiveBacktracker(WallState[,] maze, int width, int height)
    {
        var rng = new System.Random(/*seed?*/); // used var bc conflict between System and UnityEngine
        var positionStack = new Stack<Position>();
        Position position = new Position{ x = rng.Next(0, width), y = rng.Next(0, height) };

        maze[position.x, position.y] |= WallState.VISITED; // 1000 1111
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            List<Neighbor> neighbors = getUnvisitedNeighbors(current, maze, width, height);

            if (neighbors.Count > 0)
            {
                positionStack.Push(current);
                int randomIndex = rng.Next(0, neighbors.Count);
                Neighbor randomNeighbor = neighbors[randomIndex];
                Position nPosition = randomNeighbor.Position;
                maze[current.x, current.y] &= ~randomNeighbor.SharedWall;
                maze[nPosition.x, nPosition.y] &= ~getOppositeWall(randomNeighbor.SharedWall);

                maze[nPosition.x, nPosition.y] |= WallState.VISITED;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    private static List<Neighbor> getUnvisitedNeighbors(Position p, WallState[,] maze, int width, int height)
    {
        List<Neighbor> list = new List<Neighbor>();

        if (p.x > 0) // checking left
        {
            if (!maze[p.x - 1, p.y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbor
                        {
                            Position = new Position
                            {
                                x = p.x - 1,
                                y = p.y
                            },
                            SharedWall = WallState.LEFT
                        });
            }
        }

        if (p.y > 0) // checking down
        {
            if (!maze[p.x, p.y - 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbor
                        {
                            Position = new Position
                            {
                                x = p.x,
                                y = p.y - 1
                            },
                            SharedWall = WallState.DOWN
                        });
            }
        }

        if (p.y < height - 1) // checking up
        {
            if (!maze[p.x, p.y + 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbor
                        {
                            Position = new Position
                            {
                                x = p.x,
                                y = p.y + 1
                            },
                            SharedWall = WallState.UP
                        });
            }
        }

        if (p.x < width - 1) // checking right
        {
            if (!maze[p.x + 1, p.y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbor
                        {
                            Position = new Position
                            {
                                x = p.x + 1,
                                y = p.y
                            },
                            SharedWall = WallState.RIGHT
                        });
            }
        }

        return list;
    }

    public static WallState[,] Generate(int width, int height)
    {
        WallState[,] maze = new WallState[width, height];
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;
        var rng = new System.Random(/*seed?*/); // used var bc conflict between System and UnityEngine

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                maze[i, j] = initial; // 1111
            }
        }

        maze[0, rng.Next(0, height)] &= ~WallState.LEFT; // Remove left wall of leftmost cell
        maze[width - 1, rng.Next(0, height)] &= ~WallState.RIGHT; // Remove right wall of rightmost cell
        // finish always ends up on -x axis

        return applyRecursiveBacktracker(maze, width, height);
    }
}
