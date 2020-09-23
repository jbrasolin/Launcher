using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ConfigData{
    public string configName;
    public float[] configFloats;
    public bool[] configBools;
}

public class Launcher : MonoBehaviour
{
    [SerializeField]
    protected string execName;
    
    [SerializeField]
    protected string execPath;

    [SerializeField]
    TMP_InputField nameField;

    [SerializeField]
    TMP_InputField floatsField;

    [SerializeField]
    TMP_InputField boolsField;

    public void Launch(){
        // var configFloats = floatsField.text.Split(","[0]);
        // var configBools = boolsField.text.Split(","[0]);

        ///////////////////////////////////////////////////////////////////CONFIG
        var config = new ConfigData();
        config.configName = nameField.text;
        config.configFloats = Array.ConvertAll<string,float>(floatsField.text.Split(','), float.Parse);//boolsField.text.Split(","[0]);
        config.configBools = Array.ConvertAll<string,bool>(boolsField.text.Split(','), bool.Parse);//boolsField.text.Split(","[0]);

        string configJson = JsonUtility.ToJson(config);
        System.IO.File.WriteAllText(Application.dataPath + "/../" +"launcher.cfg",configJson);
        ///////////////////////////////////////////////////////////////////

        if(execPath.Length > 0){
             System.Diagnostics.Process.Start(execPath);
             Application.Quit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string appDataPath = Application.dataPath + "/../";
        //Debug.Log(appDataPath);
        execPath = Application.dataPath + "/../" + execName;
        System.IO.File.WriteAllText(appDataPath+"verif","");
        //System.IO.File.WriteAllText(Application.dataPath + "/../" +"verif",Application.dataPath);
        System.IO.File.SetAttributes(appDataPath+"verif", System.IO.FileAttributes.Hidden);

       

        
    }
}
