using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;

    [Range(2, 20)]
    public int width = 8, length = 8;
    private MapGrid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new MapGrid(width, length);
        grid.SetCell(2, 1, CellObjectType.Road, true);
        gridVisualizer.VisualizeGrid(width, length);
        gridVisualizer.VisualizeCells(grid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
