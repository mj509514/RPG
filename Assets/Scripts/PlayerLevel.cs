using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    public float Level = 1;

    public GameObject Player;
    public PlayerController Controller;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Controller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Important Note! If you are changing a float a lot and you rely on other things needing to know when that happens,
    // make a function for changing it so you can branch it out to other things!

    public void LevelUp()
    {
        Level += 1;
        Controller.OnLevelUp();
    }
}
