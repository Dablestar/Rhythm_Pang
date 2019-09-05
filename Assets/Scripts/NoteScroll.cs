using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroll : MonoBehaviour
{
	NoteGenerator ng;
	float bpm;
	int multiple;

	// Start is called before the first frame update
	void Start()
    {
		ng = gameObject.GetComponent<NoteGenerator>();

		bpm = ng.bpm ;
		multiple = ng.multiple;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(new Vector3(0, (bpm / 60) * 2 * multiple) * Time.deltaTime);
	}
}
