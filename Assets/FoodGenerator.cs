using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading;
using System;

public class FoodGenerator : MonoBehaviour
{
    public Tilemap mainTilemap;
    public Tilemap foodPlacementTilemap;
    public Tile foodTile;

    public List<Vector2Int> availablePlacements = new List<Vector2Int>();
    private void Start()
    {
        for (int y = foodPlacementTilemap.origin.y; y < (foodPlacementTilemap.origin.y + foodPlacementTilemap.size.y); y++)
        {
            for (int x = foodPlacementTilemap.origin.x; x < (foodPlacementTilemap.origin.x + foodPlacementTilemap.size.x); x++)
            {
                Tile tile = foodPlacementTilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    if (tile == foodTile)
                    {
                        availablePlacements.Add(new Vector2Int(x, y));
                        foodPlacementTilemap.SetTile(new Vector3Int(x, y, 0), null);
                    }
                }
            }
        }
    }
    public void PlaceFood()
    {
        Shuffle(availablePlacements);
        foreach (var item in availablePlacements)
        {
            Vector3Int position = new Vector3Int(item.x, item.y, 0);
            if (mainTilemap.GetTile(position) == null)
            {
                mainTilemap.SetTile(position, foodTile);
                return;
            }
        }
    }

    public void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        System.Random rnd = new System.Random();
        for (int i = 0; i < n; i++)
        {
            int next = rnd.Next(n);
            T temp = list[i];
            list[i] = list[next];
            list[next] = temp;
        }
    }
}
