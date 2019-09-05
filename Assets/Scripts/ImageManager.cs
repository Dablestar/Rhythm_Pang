using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
	SMParser sm = new SMParser();
	string path1;
	string path2;
	Image bg;

    // Start is called before the first frame update
    void Start()
    {
		path1 = sm.getBannerPath();
		path2 = sm.getBgPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
