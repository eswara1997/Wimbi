using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityEngine.UI;
using System;
using Leap.Unity.Attributes;
using Leap;
using TMPro;



public class GestureManager : MonoBehaviour {
    /// <summary>
    /// This class will manage all gestures and track the current state of the interface
    /// </summary>
    /// 

    private bool isPinching;

    public bool pinkyBent = false;
    public bool ringBent = false;
    public bool middleBent = false;
    public bool indexBent = false;
    public GameObject leftPalm;
    public GameObject rightPalm;

    public GameObject width;
    public GameObject height;
    public GameObject depth;
    public string selectedObject;
    public GameObject sloth;
    public GameObject wwyph;
    public GameObject tooLarge;

    private bool settingX = true;
    private bool settingY = true;
    private bool settingZ = true;
    private bool setX = false;
    private bool setY = false;
    private bool setZ = false;

    public GameObject searchResultsUI;


    public GameObject cube;

    public GameObject candles;
    public GameObject smallCandle;
    public GameObject mediumCandle;
    public GameObject largeCandle;


    public GameObject artwork;
    public GameObject smallArt;
    public GameObject mediumArt;
    public GameObject largeArt;


    public GameObject vases;
    public GameObject smallVase;
    public GameObject mediumVase;
    public GameObject largeVase;




    public bool measuring = false;

    //////Database objects
    private Dictionary<string, Vector3> objectDatabase = new Dictionary<string, Vector3>();






    // Use this for initialization
    void Start () {
        StartCoroutine(measureWatch());
        objectDatabase.Add("smallCandle", new Vector3(.05f, .2f, .05f));
        objectDatabase.Add("mediumCandle", new Vector3(.2f, .5f, .2f));
        objectDatabase.Add("largeCandle", new Vector3(.3f, 1f, .3f));


        //TODO figure out sizes
        objectDatabase.Add("smallArt", new Vector3(.05f, .1f, .01f));
        objectDatabase.Add("mediumArt", new Vector3(.3f, .4f, .01f));
        objectDatabase.Add("largeArt", new Vector3(1.01f, 1.5f, .3f));

        //TODO figure out sizes
        objectDatabase.Add("smallVase", new Vector3(.05f, .2f, .01f));
        objectDatabase.Add("mediumVase", new Vector3(.3f, .3f, .07f));
        objectDatabase.Add("largeVase", new Vector3(1.01f, 1.5f, .3f));

    }

    public void selectObject(string selected){
        Debug.Log("anything");
        if (selected == "candle")
        {
            measuring = true;
            selectedObject = "candle";
            Debug.Log("selected Candle");

        }

        if (selected == "artwork")
        {
            measuring = true;
            selectedObject = "artwork";

        }
    }

    public void resetMeasurements()
    {
        searchResultsUI.SetActive(false);

        measuring = false;
        cube.transform.localScale = new Vector3(0f, 0f, 0f);
        measuring = true;

         settingX = true;
         settingY = true;
         settingZ = true;
         setX = false;
         setY = false;
         setZ = false;
        selectedObject = "";

        width.GetComponent<TextMeshProUGUI>().text = "Width: " + cube.transform.localScale.x.ToString();
        depth.GetComponent<TextMeshProUGUI>().text = "Depth: " + cube.transform.localScale.z.ToString();
        height.GetComponent<TextMeshProUGUI>().text = "Height: " + cube.transform.localScale.y.ToString();
        wwyph.SetActive(true);
        sloth.SetActive(false);
        tooLarge.SetActive(false);

        smallCandle.SetActive(false);
        smallVase.SetActive(false);
        smallArt.SetActive(false);


        mediumCandle.SetActive(false);
        mediumVase.SetActive(false);
        mediumArt.SetActive(false);



        largeCandle.SetActive(false);
        largeVase.SetActive(false);
        largeArt.SetActive(false);


    }


    public void unlockMeasurements()
    {
        settingX = true;
        settingY = true;
        settingZ = true;
        setX = false;
        setY = false;
        setZ = false;
    }


    private IEnumerator measureWatch()
    {
        Vector3 startLineCenter = new Vector3(0,0,0);
        

        while (true) {

            if (selectedObject == "artwork")
            {
                setZ = true;
                settingZ = false;
                cube.transform.localScale =  new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, 0.06f);

            }
            if (Input.GetKey("up"))
            {
                

                measuring = true;
                startLineCenter = (rightPalm.transform.position + leftPalm.transform.position) / 2;


            }
            if (Input.GetKey("down"))
            {
                //startMeasuring
                measuring = false;
            }


            //If measuring do this
            if (measuring)

            {

                if (isPinching)
                {
                    Debug.Log("Detected Pinch");
                    if (setX)
                    {

                        settingX = false;
                    }
                    if (setY)
                    {   
                        settingY = false;
                    }
                    if (setZ)
                    {   
                        
                        settingZ = false;
                    }

                    if (settingX == settingY == settingZ == false)
                    {
                       //IF done show hint to search
                    }

                }

                double x = Math.Abs(Math.Round((rightPalm.transform.position.x - leftPalm.transform.position.x), 3));
                double y = Math.Abs(Math.Round((rightPalm.transform.position.y - leftPalm.transform.position.y), 3));
                double z = Math.Abs(Math.Round((rightPalm.transform.position.z - leftPalm.transform.position.z), 3));

                double y2 = Math.Abs(Math.Round((startLineCenter.y - leftPalm.transform.position.y), 3));
                double z2 = Math.Abs(Math.Round((startLineCenter.z - leftPalm.transform.position.z), 3));


                double y3 = Math.Abs(Math.Round((startLineCenter.y - rightPalm.transform.position.y), 3));
                double z3 = Math.Abs(Math.Round((startLineCenter.z - rightPalm.transform.position.z), 3));






                if (settingX)
                {

                    if (x > 0.12)
                    {
                        cube.transform.localScale = new Vector3((float)x, cube.transform.localScale.y, cube.transform.localScale.z);
                        setX = true;
                    }

                }

                //////////////  setting Y     //////////////////////
                if (settingY) { 
                    if (y > 0.1)
                    {
                        cube.transform.localScale = new Vector3(cube.transform.localScale.x, (float)y, cube.transform.localScale.z);
                        if (y > 0.25)
                        {

                            setY = true;
                        }
                    }
                    else if (y2 > 0.1)
                    {
                        cube.transform.localScale = new Vector3(cube.transform.localScale.x, (float)y2, cube.transform.localScale.z);
                        if (y2 > 0.25)
                        {
                            Debug.Log("set Y2");
                            setY = true;
                        }

                    }
                    else if (y3 > 0.1)
                    {
                        cube.transform.localScale = new Vector3(cube.transform.localScale.x, (float)y3, cube.transform.localScale.z);
                        if (y3 > 0.25)
                        {
                            setY = true;
                        }

                    }
                 }

            //////////////  setting Z   /////////////////////

            if (settingZ)
            {


                if (z > 0.1)
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, (float)z);
                        if (z > 0.25)
                        {
                            setZ = true;
                        }

                }

                else if (z2 > 0.1)
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, (float)z2);
                        if (z2 > 0.25)
                        {
                            Debug.Log("set Z");
                            setZ = true;
                        }

                    }

                else if (z3 > 0.1)
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, (float)z3);
                        if (z3 > 0.25)
                        {
                            setZ = true;
                        }
                    }
            }

                isPinching = false;


            }
            double xInch = cube.transform.localScale.x * 39.371;
            double yInch = cube.transform.localScale.y * 39.371;
            double zInch = cube.transform.localScale.z * 39.371;

            width.GetComponent<TextMeshProUGUI>().text = "Width: " + xInch.ToString() + " in.";
            depth.GetComponent<TextMeshProUGUI>().text = "Depth: " + zInch.ToString() + " in.";
            height.GetComponent<TextMeshProUGUI>().text = "Height: " +yInch.ToString() + " in.";

            yield return new WaitForSeconds(.1f);

       }

    }
    

    /// <summary>
    /// Set the x Y and Z so far
    /// </summary>

    public void onPinch()
    {
        isPinching = true;
    }

    public void showSearchResults()
    {
        Debug.Log("showing Search Results");
        //search database of objects 
        //Make results window pop up
        // Should be selectable

        Vector3 box = new Vector3((float)cube.transform.localScale.x, (float)cube.transform.localScale.y, (float)cube.transform.localScale.z);

        List<string> searchResults = new List<String>();

        foreach (var item in objectDatabase)
        {

            var name = item.Key;
            Vector3 size = item.Value;
            if(box.x - size.x > 0)
            {
               if(box.y - size.y > 0)
                {
                    if (box.z - size.z > 0)
                    {
                        searchResults.Add(item.Key);
                    }
                }

            }



        }

       
        

        searchResultsUI.SetActive(true);
        cube.transform.localScale = new Vector3(0f, 0f, 0f);
        if (selectedObject == "candle")
        {
            vases.SetActive(false);
            artwork.SetActive(false);
            candles.SetActive(true);
            if (searchResults.Contains("smallCandle"))
            {
                smallCandle.SetActive(true);
            }
            if (searchResults.Contains("mediumCandle"))
            {
                mediumCandle.SetActive(true);
            }

            if (searchResults.Contains("largeCandle"))
            {
                largeCandle.SetActive(true);
            }
        }
        

        else if (selectedObject == "artwork")
        {
            vases.SetActive(false);
            artwork.SetActive(true);
            candles.SetActive(false);
            if (searchResults.Contains("smallArt"))
            {
                smallArt.SetActive(true);
                sloth.SetActive(true);
                 wwyph.SetActive(false);
                tooLarge.SetActive(false);
            }
            if (searchResults.Contains("mediumArt"))
            {
                mediumArt.SetActive(true);
                sloth.SetActive(false);
                tooLarge.SetActive(true);
            }

            if (searchResults.Contains("largeArt"))
            {
                largeArt.SetActive(true);
                tooLarge.SetActive(true);
            }
        }

        else if (selectedObject == "flower vase")
        {
            vases.SetActive(true);
            artwork.SetActive(false);
            candles.SetActive(false);

            if (searchResults.Contains("smallVase"))
            {
                smallVase.SetActive(true);
            }
            if (searchResults.Contains("mediumVase"))
            {
                mediumVase.SetActive(true);
            }

            if (searchResults.Contains("largeVase"))
            {
                largeVase.SetActive(true);
            }
        }






    }
    
}
