using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject WOPrefab;

    public void VisualizeGrid(int width, int length)
    {
        Vector3 position = new Vector3(width / 2f, 0, length / 2f);
        Quaternion rotation = Quaternion.Euler(90, 0, 0);
        var board = Instantiate(groundPrefab, position, rotation);
        board.transform.localScale = new Vector3(width, length, 1);
    }

    public void VisualizeCells(MapGrid grid)
    {
        foreach (Cell c in grid.CellGrid)
        {
            if (c.IsTaken)
            {
                Vector3 position = new Vector3(c.X-0.5f, 0.001f, c.Z-0.5f);
                Quaternion rotation = Quaternion.Euler(90, 0, 0);

                switch (c.ObjectType)
                {
                    case CellObjectType.Road:
                        var board = Instantiate(WOPrefab, position, rotation);
                        board.transform.localScale = new Vector3(1, 1, 1);
                        break;
                    default:
                        break;
                }
            }
        }

            

    }
}
