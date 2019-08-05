using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
	SMParser sm = new SMParser();

	Image bg;

    // Start is called before the first frame update
    void Start()
    {
		string path1 = sm.getBannerPath();
		string path2 = sm.getBgPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
