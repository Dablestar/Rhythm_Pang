using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
	GameObject obj;
	NoteGenerator ng;
	public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
		ng = GameObject.Find("NoteGenerator").GetComponent<NoteGenerator>();
		startPos = ng.setStartPos(startPos);

		transform.position = new Vector3(0, startPos.y + 20, -1);
		
	}

    // Update is called once per frame
    void Update()
    {
		
    }
}
