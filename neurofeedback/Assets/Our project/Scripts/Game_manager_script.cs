using UnityEngine;

public class Game_manager_script : MonoBehaviour
{
    bool passedDoor = false;
    public float TrailMaxTime = 10f;
    public float TimePassed = 0f;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        TimePassed += Time.deltaTime;
        if (passedDoor || TimePassed > TrailMaxTime){
            TriggerNextTrail(true);	//TODO change to passedDoor
            passedDoor = false;	
            TimePassed = 0f;
        }
    }
    
    void TriggerNextTrail(bool passed){
        if (passed){
            FindObjectOfType<Score_update>().update_score();
        }
    }
}
