using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager _instance;
    public static SaveLoadManager Instance { get { return _instance; } }
    private Dictionary<string, object> fileJson;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() {
        fileJson = new Dictionary<string, object>();
    }

    public void LoadSave(string saveFileName) {
        string filePath = Application.persistentDataPath + "\\" + saveFileName;
        string json = File.ReadAllText(filePath);
        JsonUtility.FromJson<Dictionary<string, object>>(json);
    }

    public void SaveToFile() {
        string file = JsonUtility.ToJson(fileJson);
        Debug.Log(file);
    }

    public void UpdateSaveState(string key, object objectState) {
        fileJson.Add(key, objectState);
    }
}
