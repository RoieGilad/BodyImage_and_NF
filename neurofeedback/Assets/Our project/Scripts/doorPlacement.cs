using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class doorPlacement : MonoBehaviour
{

    List<Transform> doorParts;
    List<float> doorsArr;
    public float DoorWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize doors for session correspond the participant width
        List<float> ratios = new List<float> { 1.3f, 1.25f, 1.22f, 1.1f, 3f, 1.15f, 1.05f, 0.01f, 1.4f, 1.2f };
        doorsArr = ratios.Select(x => globalVariables.ParticipantWidth * x).ToList();
        DoorWidth = doorsArr[globalVariables.doorNum];
        // Gets all parts of the door in list
        doorParts = GetChildren(transform);
        SetDoor(DoorWidth);

    }


    // Update is called once per frame
    void Update()
    {
        DoorWidth = checksUpdate();
    }

    // The function return list of all Door's children - each component of Door.
    List<Transform> GetChildren(Transform Door)
    {
        List<Transform> doorParts = new List<Transform>();
        foreach (Transform doorPart in Door)
        {
            doorParts.Add(doorPart);
        }
        return doorParts;
    }

    // The function sets the door size and position
    public void SetDoor(float doorWidth)
    {
        // Sets door size based on the participant size and random num for changing the door width
        // each trail
        float door_width = doorWidth + Random.Range(0.1f, 0.5f);
        float ParticipantHight = globalVariables.ParticipantHight;
        doorParts[1].localScale = new Vector3(door_width, 0.1f, 0.1f);
        doorParts[0].localScale = new Vector3(0.1f, ParticipantHight + 0.2f, 0.1f);
        doorParts[2].localScale = new Vector3(0.1f, ParticipantHight + 0.2f, 0.1f);
        // Sets door position at the start of the trail
        doorParts[1].position = new Vector3(0, ParticipantHight + 0.225f, 4);
        doorParts[0].position = new Vector3(-1 * (door_width / 2) - 0.05f, (ParticipantHight + 0.15f) / 2 + 0.1f, 4);
        doorParts[2].position = new Vector3((door_width / 2) + 0.05f, (ParticipantHight + 0.15f) / 2 + 0.1f, 4);
    }

    public float checksUpdate()
    {
        if (doorParts[0].position.z < 0 && doorParts[1].position.z < 0 && doorParts[2].position.z < 0)
        {
            if (globalVariables.doorNum <= 10)
            {
                globalVariables.doorNum++;
                DoorWidth = doorsArr[globalVariables.doorNum];
                SetDoor(DoorWidth);
                globalVariables.changeRoomColor = true;
            }
            else
            {
                Application.Quit();
            }
        }
        return DoorWidth;
    }
}
