using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;
    public TileBase floorTile;
    public Tilemap wallTilemap;
    public TileBase wallTop;

    public void paintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        paintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void paintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            paintSingleTile(tilemap, tile, position);
        }
    }

    public void paintSingleBasicWall(Vector2Int position)
    {
        paintSingleTile(wallTilemap, wallTop, position);
    }

    private void paintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePos = tilemap.WorldToCell((Vector3Int) position);
        tilemap.SetTile(tilePos, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
