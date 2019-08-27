using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroll : MonoBehaviour
{
	NoteGenerator ng;
	float bpm;
	float multiple;
	// Start is called before the first frame update
	void Start()
    {
		
		ng.setMeta(bpm, multiple);
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(new Vector3(0, -(bpm / 60) * multiple) * Time.deltaTime);
	}
}
