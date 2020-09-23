using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LauncherCheck : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI usernameText;

    [SerializeField]
    private GameObject boolGroup, floatGroup;

    private ConfigData config;

    public GameObject textPrefab; 

    void Start()
    {
        string appDataPath = Application.dataPath + "/../";
        string path = appDataPath+"verif";
        bool exists = System.IO.File.Exists(path);
        if (!exists){ 
            Debug.Log("launcher did not found verif file!");
            Application.Quit();
        };
        System.IO.File.Delete(path);

        ///////////////////////////////CONFIG
        string configPath = Application.dataPath + "/../" +"launcher.cfg";
        bool configExists = System.IO.File.Exists(configPath);
        if (!configExists){ 
            Debug.Log("launcher did not found Config file!");
            Application.Quit();
        };
        var source=new System.IO.StreamReader(configPath);
        var fileContents=source.ReadToEnd();
        source.Close();
        config = JsonUtility.FromJson<ConfigData>(fileContents);
        usernameText.text = config.configName;
        foreach(bool b in config.configBools){
            var e = Instantiate(textPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            e.GetComponent<TextMeshProUGUI>().text = b.ToString();
            e.transform.SetParent(boolGroup.transform);
        }
        foreach(float f in config.configFloats){
            var e = Instantiate(textPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            e.GetComponent<TextMeshProUGUI>().text = f.ToString();
            e.transform.SetParent(floatGroup.transform);
        }

    }
}
