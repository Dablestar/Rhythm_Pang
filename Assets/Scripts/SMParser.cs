	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class SMParser : MonoBehaviour
{
	public string smFilePath;

	public string title;



	public struct Metadata
	{

		public bool valid;


		public string title;
		public string artist;

		public string bannerPath;
		public string musicPath;
		public string bgPath;

		public float offset;
		public float bpm;
		public string difficulty;
		public List<List<string>> noteData;
	}
	public struct Notes
	{
		public char left;
		public char right;
	}
	private void Start()
	{
		smFilePath = @".\Assets\Steps\" + title + @"\" + title + @".sm";
		Debug.Log(title + " " + smFilePath);
		Metadata m = ParseMeta(smFilePath);
		List<List<string>> getData = m.noteData;

	}
	public Metadata ParseMeta(string newFilePath)
	{

		newFilePath = smFilePath;
		Debug.Log(smFilePath + " " + newFilePath);

		if (string.IsNullOrWhiteSpace(newFilePath))
		{
			Metadata temp = new Metadata();
			temp.valid = false;
			return temp;
		}
		bool noteExist = false;
		Metadata songData = new Metadata();
		songData.valid = true;
		songData.noteData = new List<List<string>>();
		List<string> fileData = File.ReadAllLines(newFilePath).ToList();
		List<string> noteChart = new List<string>();
		string fileDir = Path.GetDirectoryName(newFilePath);
		string sTemp = "";

		for (int i = 0; i < fileData.Count; i++)
		{
			
			string line = fileData[i].Trim();
			if (line.StartsWith("#"))
			{
				string key = line.Substring(0, line.IndexOf(':')).Trim('#').Trim(':');
				switch (key.ToUpper())
				{
					case "TITLE":
						songData.title = line.Substring(line.IndexOf(':')).Trim(':').Trim(';');
						break;
					case "ARTIST":
						songData.artist = line.Substring(line.IndexOf(':')).Trim(':').Trim(';');
						break;
					case "BANNER":
						songData.bannerPath = fileDir + @"\" + line.Substring(line.IndexOf(':')).Trim(':').Trim(';');
						break;
					case "MUSIC":
						songData.musicPath = fileDir + @"\" + line.Substring(line.IndexOf(':')).Trim(':').Trim(';');
						if (string.IsNullOrWhiteSpace(songData.musicPath) || !File.Exists(songData.musicPath))
						{
							//No music file found!
							songData.musicPath = null;
							songData.valid = false;
						}
						break;
					case "BACKGROUND":
						songData.bgPath = songData.musicPath = fileDir + @"\" + line.Substring(line.IndexOf(':')).Trim(':').Trim(';');
						break;
					case "OFFSET":
						songData.offset = float.Parse(line.Substring(line.IndexOf(':')).Trim(':').Trim(';'));
						if (!float.TryParse(line.Substring(line.IndexOf(':')).Trim(':').Trim(';'), out songData.offset))
						{
							//Error Parsing
							songData.offset = 0.0f;
						}
						break;
					case "DISPLAYBPM":
						songData.bpm = float.Parse(line.Substring(line.IndexOf(':')).Trim(':').Trim(';'));
						if (!float.TryParse(line.Substring(line.IndexOf(':')).Trim(':').Trim(':'), out songData.bpm))
						{
							songData.valid = false;
						}
						break;
					case "NOTES":
						noteExist = true;
						break;
					default:
						break;
				}

			}

			if (noteExist)
			{
				if (line.ToLower().Contains("beginner") ||
				   line.ToLower().Contains("easy") ||
				   line.ToLower().Contains("medium") ||
				   line.ToLower().Contains("hard") ||
				   line.ToLower().Contains("challenge") ||
				   line.ToLower().Contains("edit"))
				{
					songData.difficulty = line.Trim().Trim(':');
				}
				if (line.EndsWith(":"))
				{
					continue;
				}
				else if (line.Contains(","))
				{
					songData.noteData.Add(noteChart);
					noteChart = new List<string>();
					//noteChart.Add(sTemp);
					//sTemp = null;
				} /*else if (line.Contains(";"))
				{
					songData.noteData.Add(noteChart);
				}*/
				else if (line.Contains(";")||line.Contains("//"))
				{
					continue;
				}
				
				else
				{
					sTemp += line.Substring(0, 2);
					//sTemp += line.Substring(0,2)+ "\n";
					noteChart.Add(sTemp);
					sTemp = null;
				}
				
				
			}
			if (line.EndsWith(";"))
			{
				noteExist = false;
			}
		}

		return songData;
	}

	
	public string getBgPath()
	{
		string path = @".\Assets\Steps\" + title + @"\" + title + @".sm";
		Metadata imgPath = ParseMeta(path);
		return imgPath.bgPath;
	}
	public string getBannerPath()
	{
		string path = @".\Assets\Steps\" + title + @"\" + title + @".sm";
		Metadata imgPath = ParseMeta(path);
		return imgPath.bannerPath;
	}
	




}
//내가 짠거 시발
