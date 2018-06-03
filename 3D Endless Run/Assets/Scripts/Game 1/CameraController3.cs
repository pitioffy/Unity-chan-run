using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3 : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 moveVector;

    [SerializeField]
    private float transition = 0f;
    private float animationDuration = 2f;
    private float animationDuration2 = 2.3f;
    private float preAnimationDuration = 3.2f; 
    private Vector3 animationOffset = new Vector3(0, 3, 3);
    private float StartTime;

    [SerializeField]
    private float transition2 = 0f;
    public int animationFlag;
    private Vector3 animationOffset1 = new Vector3(0, -2, 5);
    private Vector3 animationOffset2 = new Vector3(2, -2, 3);


    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        moveVector = player.transform.position + offset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (animationFlag == 0)
        {
            if (transition > 1f)
            {
                transform.position = moveVector;
            }
            else
            {
                // Aniamtion at the start of the game
                transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
                transition += Time.deltaTime * 1 / animationDuration;
                transform.LookAt(player.transform.position + Vector3.up * 2);
            }
        }
        else
        {
            if(Time.time - StartTime < preAnimationDuration)
            {
                transform.position = Vector3.Lerp(moveVector + animationOffset1, moveVector + animationOffset2, 0);
                transform.LookAt(player.transform.position + Vector3.up);
                return;
            }

            if (transition > 2f)
            {
                transform.position = moveVector;
            }
            else if (transition > 1f)
            {
                // Aniamtion at the start of the game
                transform.position = Vector3.Lerp(moveVector + animationOffset2, moveVector, transition2);
                transition += Time.deltaTime * 1 / animationDuration2;
                transition2 += Time.deltaTime * 1 / animationDuration2;
                transform.LookAt(player.transform.position + Vector3.up);
            }
            else
            {
                // Aniamtion at the start of the game
                transform.position = Vector3.Lerp(moveVector + animationOffset1, moveVector + animationOffset2, transition);
                transition += Time.deltaTime * 1 / animationDuration;
                transform.LookAt(player.transform.position + Vector3.up);
            }
        }

    }
}
