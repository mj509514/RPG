using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointHandler : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(GetAimDir);
    }



    public Vector3 GetAimDir;
    
}
