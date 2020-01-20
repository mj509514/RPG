using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    public GameObject ContainerObject;
    public SpriteRenderer ContainerBox;
    public GameObject Player;
    public PlayerLevel Playerlevel;

    bool isInChestZone;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Playerlevel = Player.GetComponent<PlayerLevel>();
        ContainerObject = GameObject.Find("ContainerObject");
        ContainerBox = ContainerObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        isInChestZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        isInChestZone = false;
    }

    void Update()
    {
        if (isInChestZone)
        {

            Debug.Log("In the zone!");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Playerlevel.LevelUp();
                ContainerBox.color = Color.black;
                Debug.Log("Is this thing on?");
            }
        }
    }
}
