using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder;



public class Room_Manager : MonoBehaviour{
    public Material[] wall_colors;
    Renderer rend;
    int index = -1;




    // Start is called before the first frame update
    void Start(){
       rend = GetComponent<Renderer>();
       rend.enabled = true;
    }

    // Update is called once per frame
    void Update(){

        if (globalVariables.changeRoomColor) {
            update_walls();
            globalVariables.changeRoomColor = false;
        }
    }

public void update_walls(){
        index = (index + 1) % wall_colors.Length;
        rend.sharedMaterial = wall_colors[index];
    }
}
