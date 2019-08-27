using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
	public GameObject prefab;
	public GameObject notePrefab;
	public GameObject guideNotePrefab;
	public Transform noteGenerator;

	SMParser sm = new SMParser();


	int bit4 = 4;
	int bit8 = 8;
	int bit12 = 12;
	int bit16 = 16;
	public float bpm;
	public int multiple;
	List<List<string>> chartData = new List<List<string>>();
	// Start is called before the first frame update
	void Start()
	{

		bpm = 185.0f;
		multiple = 2;
		chartData = sm.getNoteData();
		
		//for (int j = 0; j < noteData.Count; j++)
		//{
		//	Instantiate(prefab);
		//	prefab.transform.position = new Vector3(0, j * 8, 0);
		//}


		float width = prefab.transform.localScale.x;
		float height = prefab.transform.localScale.y;

		float noteWidth = width/2;
		Debug.Log(width + " " + height + " " + noteWidth + " ");
		transform.position = new Vector3(0, height * chartData.Count, 0);
		notePrefab.transform.position = new Vector3(0, height * chartData.Count * multiple, 0);
		guideNotePrefab.transform.position = new Vector3(0, height * chartData.Count * multiple, 0);
		for (int i = 0; i < chartData.Count; i++)
		{
			//prefab.transform.position = new Vector3(0, i * 8, 0);
			//Instantiate(prefab);

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
	void setNote(int bits , int index)
	{
		float phraseHeight = prefab.transform.localScale.y;
		float noteWidth = notePrefab.transform.localScale.x;
		float noteHeight = notePrefab.transform.localScale.y;
		notePrefab.transform.localScale = new Vector3(noteWidth, noteHeight,0);
		guideNotePrefab.transform.localScale = new Vector3(noteWidth, noteHeight, 0);
		//notePrefab.transform.localScale = new Vector3(0, index * 8, 0);
		//notePrefab.transform.Translate(new Vector3(0, 8, 0));
		for (int i = 0; i < bits; i++)
		{
			//notePrefab.transform.position = new Vector3(0, ((index * 8)-3) + (noteHeight * i), 0);
			
			if (chartData[index][i].Equals("01"))
			{
				notePrefab.transform.Translate(new Vector3(2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(2, 0, 0));
				Instantiate(notePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
			}
			//오른쪽 일반노트
			else if(chartData[index][i].Equals("10"))
			{
				notePrefab.transform.Translate(new Vector3(-2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, 0, 0));
				Instantiate(notePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(2, -phraseHeight / bits * multiple, 0));
			}
			//왼쪽 일반노트
			else if(chartData[index][i].Equals("11"))
			{
				notePrefab.transform.Translate(new Vector3(-2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, 0, 0));
				Instantiate(notePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(4, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(4, 0, 0));
				Instantiate(notePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
			}
			//동타 일반노트
			else if (chartData[index][i].Equals("0F"))
			{
				notePrefab.transform.Translate(new Vector3(2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(2, 0, 0));
				Instantiate(guideNotePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
			}
			//오른쪽 가이드노트
			else if (chartData[index][i].Equals("F0"))
			{
				notePrefab.transform.Translate(new Vector3(-2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, 0, 0));
				Instantiate(guideNotePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(2, -phraseHeight / bits * multiple, 0));
			}
			//왼쪽 가이드노트
			else if (chartData[index][i].Equals("FF"))
			{
				notePrefab.transform.Translate(new Vector3(-2, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, 0, 0));
				Instantiate(guideNotePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(4, 0, 0));
				guideNotePrefab.transform.Translate(new Vector3(4, 0, 0));
				Instantiate(guideNotePrefab);
				transform.SetParent(noteGenerator);
				notePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(-2, -phraseHeight / bits * multiple, 0));
			}
			//동타 가이드노트
			else
			{
				notePrefab.transform.Translate(new Vector3(0, -phraseHeight / bits * multiple, 0));
				guideNotePrefab.transform.Translate(new Vector3(0, -phraseHeight / bits * multiple, 0));
			}
			//공백처리
			
			
		}
	}
	private void Update()
	{
		
	}
	public void setMeta(float bpm, float multiple)
	{
		bpm = sm.bpm;
		multiple = this.multiple;
	}
}
