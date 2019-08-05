using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public GameObject prefab;

	float bit4 = 4;
	float bit8 = 8;
	float bit16 = 16;
    // Start is called before the first frame update
    void Start()
    {
		Instantiate(prefab);
		float width = prefab.transform.localScale.x;
		float height = prefab.transform.localScale.y;

		float noteWidth = width / bit16;
		float noteHeight = height / bit16;

		Debug.Log(width + " " + height + " " + noteWidth + " ");
	}

    // Update is called once per frame
    void Update()
    {
		

    }
}
