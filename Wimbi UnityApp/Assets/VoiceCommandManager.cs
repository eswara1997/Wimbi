using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;
using System;
using System.Reflection;
using TMPro;


public class VoiceCommandManager : MonoBehaviour {


    public System.Action<PhraseRecognizedEventArgs> onPhraseRecognized;

    private KeywordRecognizer _keywordRecognizer = null;
    public List<string> commandList = new List<string>();
    public GestureManager gestManager;
    private bool selected = false;
    public GameObject label;

    // Use this for initialization
    void Start () {

        commandList.Add("candle");
        commandList.Add("artwork");
        commandList.Add("flower vase");
        commandList.Add("reset");
        commandList.Add("search");
        commandList.Add("unlock");

        StartCoroutine(debug());


        // Tell the KeywordRecognizer about our keywords.
        _keywordRecognizer = new KeywordRecognizer(commandList.ToArray());


        // Register a callback for the KeywordRecognizer and start recognizing!
        _keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        _keywordRecognizer.Start();
    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.text) && args.confidence != ConfidenceLevel.Rejected)
        {

            if (args.text.Contains("candle"))
            {
                Debug.Log("candle");
                if (!selected)
                {
                    gestManager.selectedObject = "candle";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "candle";
                }
                
            }

            if (args.text.Contains("artwork"))
            {
                Debug.Log("artwork");
                if (!selected)
                {
                    gestManager.selectedObject = "artwork";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "Artwork";
                    
                }
            }

            if (args.text.Contains("flower vase"))
            {
                Debug.Log("vase");

                if (!selected)
                {
                    gestManager.selectedObject = "flower vase";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "Flower Vase";
                }
        }

            if (args.text.Contains("reset"))
            {
                Debug.Log("reset");
                selected = false;
                gestManager.resetMeasurements();

                label.GetComponent<TextMeshProUGUI>().text = "Select an Object";

            }

            if (args.text.Contains("search"))
            {
                Debug.Log("search");
                gestManager.showSearchResults();
                gestManager.measuring = false;
            }

            if (args.text.Contains("unlock"))
            {
                gestManager.unlockMeasurements();

            }


        }
		
	}

    private IEnumerator debug()
    {
        while (true)
        {
            if (Input.GetKey("c"))
            {
                Debug.Log("candle");
                if (!selected)
                {
                    gestManager.selectedObject = "candle";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "candle";
                }

            }

            if (Input.GetKey("a"))
            {
                Debug.Log("artwork");
                if (!selected)
                {
                    gestManager.selectedObject = "artwork";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "Artwork";

                }
            }

            if (Input.GetKey("f"))
            {
                Debug.Log("vase");

                if (!selected)
                {
                    gestManager.selectedObject = "flower vase";
                    selected = true;
                    gestManager.measuring = true;
                    label.GetComponent<TextMeshProUGUI>().text = "Flower Vase";
                }
            }

            if (Input.GetKey("r"))
            {
                Debug.Log("reset");
                selected = false;
                gestManager.resetMeasurements();

                label.GetComponent<TextMeshProUGUI>().text = "Select an Object";

            }

            if (Input.GetKey("s"))
            {
                Debug.Log("search");
                gestManager.showSearchResults();
                gestManager.measuring = false;
            }

            yield return new WaitForSeconds(.1f);


        }
    }
}
