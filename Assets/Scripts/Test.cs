﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public GameObject prefab;
	public GameObject notePrefab;


	SMParser sm = new SMParser();


	int bit4 = 4;
	int bit8 = 8;
	int bit12 = 12;
	int bit16 = 16;

	RectTransform prefabRT;

	// Start is called before the first frame update
	void Start()
	{


		List<List<string>> chartData = new List<List<string>>();
		chartData = sm.getNoteData();
		
		//for (int j = 0; j < noteData.Count; j++)
		//{
		//	Instantiate(prefab);
		//	prefab.transform.position = new Vector3(0, j * 8, 0);
		//}


		float width = prefab.transform.localScale.x;
		float height = prefab.transform.localScale.y;

		float noteWidth = width;
		Debug.Log(width + " " + height + " " + noteWidth + " ");
		notePrefab.transform.position = new Vector3(0, 0 , 0);
		for (int i = 0; i < chartData.Count; i++)
		{
			prefab.transform.position = new Vector3(0, i * 8, 0);
			Instantiate(prefab);

			if (chartData[i].Count == bit4)
			{
				setNote(bit4, i);
			}
			else if (chartData[i].Count == bit8)
			{
				setNote(bit8, i);
			}
			else if (chartData[i].Count == bit12)
			{
				setNote(bit12, i);
			}
			else if (chartData[i].Count == bit16)
			{
				setNote(bit16, i);
			}

		

			

			//for (int j = 0; j < bit4; j++)
			//{
			//	Instantiate(notePrefab);
			//	notePrefab.transform.position = new Vector3(0, ((j - 1) * (noteHeight)) - 1, 0);
			//}
		}

		// Update is called once per frame
	}
	void setNote(int bits, int index)
	{
		float noteHeight = prefab.transform.localScale.y / bits;
		notePrefab.transform.localScale = new Vector3(prefab.transform.localScale.x , noteHeight,0);
		//notePrefab.transform.localScale = new Vector3(0, index * 8, 0);
		//notePrefab.transform.Translate(new Vector3(0, 8, 0));
		for(int i = 0; i<bits; i++)
		{

			//notePrefab.transform.position = new Vector3(0, ((index * 8)-3) + (noteHeight * i), 0);
			Instantiate(notePrefab);
			notePrefab.transform.Translate(new Vector3(0,  noteHeight, 0));
			
		}
	}
}
