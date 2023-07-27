using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class generateChunks : MonoBehaviour
{
    public GameObject tilePrefab;   // Reference to the tile prefab
    public int worldSize = 10;      // Initial size of the world (number of tiles in one direction)

    private Transform player;       // Reference to the player's Transform
    private Vector2 lastPlayerPosition; // Last position of the player
    private Vector2Int currentPlayerTile; // Current tile coordinates of the player

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has a "Player" tag
        lastPlayerPosition = player.position;
        GenerateInitialWorld();
    }

    private void Update()
    {
        Vector2 playerMovement = (Vector2)player.position - lastPlayerPosition;

        // Check if player has moved to a new tile
        if (playerMovement.magnitude >= 1f)
        {
            Vector2Int playerTile = new Vector2Int(Mathf.RoundToInt(player.position.x), Mathf.RoundToInt(player.position.y));
            if (playerTile != currentPlayerTile)
            {
                GenerateNewTiles(playerTile);
                currentPlayerTile = playerTile;
            }
        }

        lastPlayerPosition = player.position;
    }

    private void GenerateInitialWorld()
    {
        for (int x = -worldSize; x <= worldSize; x++)
        {
            for (int y = -worldSize; y <= worldSize; y++)
            {
                Vector2Int tilePosition = new Vector2Int(x, y);
                Vector2 tp = tilePosition;
                Instantiate(tilePrefab, tp, Quaternion.identity, transform);
            }
        }
    }

    private void GenerateNewTiles(Vector2Int playerTile)
    {
        // Calculate the bounds of the new tiles to be generated
        int minX = playerTile.x - worldSize;
        int maxX = playerTile.x + worldSize;
        int minY = playerTile.y - worldSize;
        int maxY = playerTile.y + worldSize;

        // Destroy tiles that are outside the new bounds
        foreach (Transform tile in transform)
        {
            Vector2Int tilePos = new Vector2Int(Mathf.RoundToInt(tile.position.x), Mathf.RoundToInt(tile.position.y));
            if (tilePos.x < minX || tilePos.x > maxX || tilePos.y < minY || tilePos.y > maxY)
            {
                Destroy(tile.gameObject);
            }
        }

        // Generate new tiles within the bounds
        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                Vector2Int tilePosition = new Vector2Int(x, y);
                if (transform.Find(tilePosition.ToString()) == null) // Check if a tile already exists at this position
                {
                    Vector2 tp = tilePosition;
                    Instantiate(tilePrefab, tp, Quaternion.identity, transform);
                }
            }
        }
    }
}