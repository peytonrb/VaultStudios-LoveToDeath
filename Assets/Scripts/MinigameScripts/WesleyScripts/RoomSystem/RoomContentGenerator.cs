// using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RoomContentGenerator : MonoBehaviour
{
    [SerializeField]
    private RoomGenerator playerRoom, defaultRoom;

    List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private GraphTest graphTest;

    public Transform itemParent;

    // [SerializeField]
    // private CinemachineVirtualCamera cinemachineCamera;

    public UnityEvent RegenerateLab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in spawnedObjects)
            {
                Destroy(item);
            }
            RegenerateLab?.Invoke();
        }
    }
    public void GenerateRoomContent(LabData labData)
    {
        foreach (GameObject item in spawnedObjects)
        {
            DestroyImmediate(item);
        }
        spawnedObjects.Clear();

        SelectPlayerSpawnPoint(labData);

        foreach (GameObject item in spawnedObjects)
        {
            if(item != null)
                item.transform.SetParent(itemParent, false);
        }
    }

    private void SelectPlayerSpawnPoint(LabData labData)
    {
        int randomRoomIndex = UnityEngine.Random.Range(0, labData.roomsDictionary.Count);
        Vector2Int playerSpawnPoint = labData.roomsDictionary.Keys.ElementAt(randomRoomIndex);

        graphTest.RunDijkstraAlgorithm(playerSpawnPoint, labData.floorPositions);

        Vector2Int roomIndex = labData.roomsDictionary.Keys.ElementAt(randomRoomIndex);

        List<GameObject> placedPrefabs = playerRoom.ProcessRoom(
            playerSpawnPoint,
            labData.roomsDictionary.Values.ElementAt(randomRoomIndex),
            labData.GetRoomFloorWithoutCorridors(roomIndex)
            );

        // FocusCameraOnThePlayer(placedPrefabs[placedPrefabs.Count - 1].transform);

        spawnedObjects.AddRange(placedPrefabs);

        labData.roomsDictionary.Remove(playerSpawnPoint);
    }

    // private void FocusCameraOnThePlayer(Transform playerTransform)
    // {
    //     cinemachineCamera.LookAt = playerTransform;
    //     cinemachineCamera.Follow = playerTransform;
    // }
}
