using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public RoadFixer roadFixer;

    public List<Vector3Int> temporaryPlacementPositions = new List<Vector3Int>();
    public List<Vector3Int> roadPositionsToRecheck = new List<Vector3Int>();

    private void Start()
    {
        roadFixer = GetComponent<RoadFixer>();
    }

    public void PlaceRoad(Vector3Int position)
    {
        //Überprüfung der ausgewählten Position
        if (!placementManager.CheckIfPositionInBound(position)) return;
        if (!placementManager.CheckIfPositionIsFree(position)) return;

        temporaryPlacementPositions.Clear();
        roadPositionsToRecheck.Clear();
        temporaryPlacementPositions.Add(position);
        placementManager.PlaceTemporaryStructure(position, roadFixer.deadEnd, CellType.Road); // Base-Prefab
        FixRoadPrefabs();
    }

    private void FixRoadPrefabs()
    {
        foreach(var temporaryPosition in temporaryPlacementPositions)
        {
            roadFixer.FixRoadAtPosition(placementManager, temporaryPosition);
            var neighbours = placementManager.GetNeighboursOfTypeFor(temporaryPosition, CellType.Road);
            foreach (var roadposition in neighbours)
            {
                roadPositionsToRecheck.Add(roadposition);
            }
        }

        foreach (var positionToFix in roadPositionsToRecheck)
        {
            roadFixer.FixRoadAtPosition(placementManager, positionToFix);
        }
    }
}
