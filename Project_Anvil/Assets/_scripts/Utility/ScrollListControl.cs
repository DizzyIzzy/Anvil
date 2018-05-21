using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.Map;
using Mapbox.Unity.Map;

public class ScrollListControl : MonoBehaviour
{

    public Text header;
    public ReadLocationFile readLocationFile;
    public GameObject buttonTemplate;
    [SerializeField]
    private GeoForward geoForward;
    public List<string> locList;
    private int[] intArray;
    public BasicMap basicMap;
    [SerializeField]
    GetHeight getHeight;
    private double prefabHeight;
    GameObject splashCanvas;
    GameObject myMain;
    AISpawner aiSpawner;

    // Use this for initialization
    void Start()
    {
        aiSpawner = GameObject.Find("AISpawner").GetComponent<AISpawner>();
        geoForward = GameObject.Find("GeoForward").GetComponent<GeoForward>();
        splashCanvas = GameObject.Find("SplashCanvas");
        myMain = GameObject.Find("Main Camera");
        myMain.SetActive(false);
        readLocationFile = GameObject.Find("ReadLocationFile").GetComponent<ReadLocationFile>();
        GenerateLocationButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void GenerateLocationButtons()
    // creates the buttons from the location read in from the editable file
    void GenerateLocationButtons()
    {

        locList = readLocationFile.ReadLocation();
        for (int i = 0; i < locList.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText(locList[i]);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }


    // public void ButtonClicked(string textString)
    // the callback method from the buttons
    public void ButtonClicked(string textString)
    {
        geoForward.HandleLocationInput(textString);
        StartCoroutine("CameraSwitch");
    }    
    
    // IEnumerator Camera Switch ()
    // Delays the camera from displaying the game level until everything should have loaded
    IEnumerator CameraSwitch()
    {
        header.text = "Please wait...";
        yield return new WaitForSeconds(2);
        Vector2d myLoc;
        myLoc = geoForward.GetLoc();
        basicMap.Initialize(myLoc, 15);
        yield return new WaitForSeconds(3);
        prefabHeight = getHeight.HeightForPrefab(myLoc.x, myLoc.y, basicMap);
        aiSpawner.BeginPlacing(prefabHeight);
        yield return new WaitForSeconds(2);
        myMain.transform.position = new Vector3(myMain.transform.position.x, myMain.transform.position.y + (float)prefabHeight,
            myMain.transform.position.z);
        myMain.SetActive(true);
        splashCanvas.SetActive(false);
        gameObject.SetActive(false);
    }
}
