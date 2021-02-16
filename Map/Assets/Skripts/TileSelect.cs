using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(TileMap))]

public class TileSelect : MonoBehaviour
{
    Tilemap _tileMap;
    Vector3 currentTileCoord;



    // Start is called before the first frame update
    void Start()
    {
        _tileMap= GetComconent<TileMap>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
        //Debug.Log(coordinate);

        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(GetComponent<collider>.Raycast(ray,out hitInfo, Mathf.infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x);
            int z = Mathf.FloorToInt(hitInfo.point.z);
            Debug.log("Tile:" + x + ',' * z);

            currentTileCoord.x = x;
            currentTileCoord.z = z;
        }
        else
        {

        }
        if (Input.GetMouseButtonDown(1) && selectedUnit != null)
        {
            selectUnit.MovetToCoord(currentTileCoord.x, currentTileCoord.z);
        }
    }
}
