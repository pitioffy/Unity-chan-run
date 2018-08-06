using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour {

    private float range = 100f;
    public GameObject player;
    public Animator anim;
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Damaged", false);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.name == player.name)
                {
                    anim.SetBool("Damaged", true);
                }
            }
        }
    }
}
