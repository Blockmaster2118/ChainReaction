using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject SampleTile;

    public GameObject[,] Tiles = new GameObject[6, 10];
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                Tiles[x, y] = Instantiate(SampleTile);
                Tiles[x, y].GetComponent<Tile>().pos = new Vector2(x, y);
                Tiles[x, y].SetActive(true);
                Tiles[x, y].transform.position = new Vector3(x - Tiles.GetLength(0)/2 + 0.5F,
                    0,
                    y - Tiles.GetLength(1)/2 + 0.5F);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
