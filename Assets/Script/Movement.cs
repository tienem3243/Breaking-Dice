using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField]private Controller controller;
    [SerializeField] private Camera mainCam;
    // Start is called before the first frame update
    bool dash;
    //input click
    [SerializeField] Transform desPos;
    Vector2 movementClick;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //movement input
     
        //mouse
        
        if (Input.GetMouseButtonDown(0))
        {
            desPos.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
            movementClick = (desPos.position - transform.position).normalized;
          
            Debug.Log(movementClick);
            controller.AMove(movementClick);
        }
        if (Vector2.Distance(desPos.position, transform.position) < 0.1f)
        {
            controller.AMove(Vector2.zero);
        }
     
    }

}
