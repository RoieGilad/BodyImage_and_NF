using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_avatars : MonoBehaviour
{
    // Array of avatars
    public GameObject[] avatars;

    // Variable to store the feedback value
    [Range(0.0f, 1.0f)]
    public float feedback;
    public int index;

    // Use this for initialization
    void Start()
    {
        // Enable the initial avatar based on the feedback value
        UpdateAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the avatar based on the feedback value
        UpdateAvatar();
    }

    // Update the active avatar based on the feedback value
    void UpdateAvatar()
    {
        // Calculate the index based on the feedback value
        index = Mathf.Min(Mathf.FloorToInt(feedback * avatars.Length), avatars.Length - 1);

        // Activate the selected avatar and deactivate others
        SetAvatarStates(index);
    }

    // Set the active state of avatars
    void SetAvatarStates(int activeIndex)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            bool isActive = (i == activeIndex);
            avatars[i].SetActive(isActive);
        }
    }
}
