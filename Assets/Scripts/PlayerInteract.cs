using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{


    public float castDist;

    GameManager myManager;

    bool pressedMouse = false;

    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedMouse = true;
        }
        else
        {
            pressedMouse = false;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        //Vector3 rayStart = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        Vector3 rayStart = transform.position;


        if (Physics.SphereCast(rayStart, 1, Camera.main.transform.forward, out hit, castDist))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Character" && pressedMouse)
            {
                //Debug.Log(hit.transform.gameObject.GetComponent<CharacterDialogue>().characterLine);
                string newDialogue = hit.transform.gameObject.GetComponent<CharacterDialogue>().characterLine;
                myManager.SetDialogueText(newDialogue);
            }
        }

        Debug.DrawRay(rayStart, Camera.main.transform.forward * castDist, Color.red);
    }
}
