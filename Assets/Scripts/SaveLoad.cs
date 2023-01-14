using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
 
    public static void SaveData(PlayerHealth PlayerSaveData )
    {
        Debug.Log("SaveData Location:"+Application.persistentDataPath );

        BinaryFormatter formatter = new BinaryFormatter();
        string saveFilename = "GameSaveData.save";
        string path = Application.persistentDataPath + "/" +saveFilename;


        FileStream fstream = new FileStream(path, FileMode.Create);

        PlayerHealth clonePxData = new PlayerHealth(PlayerSaveData);
    }


    public static PlayerHealth LoadData()
    {

        return null;
    }

}
