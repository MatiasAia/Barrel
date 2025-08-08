using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Encargado de cargar y guardar el progreso del juego del disco
public class ProgressManager : MonoBehaviour
{
    public PlayerData playerData;

    public enum Data
    {
        WallHealt,
        Money,
        CannonProgress,
        CannonLevel,
        GorilaLevel,
        BarrelsLevel,
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");

        PlayerData data = new PlayerData();

        data.wallHealt = playerData.wallHealt;
        data.money = playerData.money;
        data.cannonProgress = playerData.cannonProgress;
        data.cannonLevel = playerData.cannonLevel;
        data.gorilaLevel = playerData.gorilaLevel;
        data.barrelsLevel = playerData.barrelsLevel;
        data.weaponsInfo[PlayerData.WeaponType.Pistol] = playerData.weaponsInfo[PlayerData.WeaponType.Pistol];
        data.weaponsInfo[PlayerData.WeaponType.SubFusil] = playerData.weaponsInfo[PlayerData.WeaponType.SubFusil];


        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerData.wallHealt = data.wallHealt;
            playerData.money = data.money;
            playerData.cannonProgress = data.cannonProgress;
            playerData.cannonLevel = data.cannonLevel;
            playerData.gorilaLevel = data.gorilaLevel;
            playerData.barrelsLevel = data.barrelsLevel;
            playerData.weaponsInfo[PlayerData.WeaponType.Pistol] = data.weaponsInfo[PlayerData.WeaponType.Pistol];
            playerData.weaponsInfo[PlayerData.WeaponType.SubFusil] = data.weaponsInfo[PlayerData.WeaponType.SubFusil];

        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public int wallHealt;
        public int money;
        public int cannonProgress;
        public int cannonLevel;
        public int gorilaLevel;
        public long barrelsLevel;

        public enum WeaponType
        {
            Pistol,
            SubFusil
        }

        public Dictionary<WeaponType, int> weaponsInfo = new Dictionary<WeaponType, int>
        {
            {WeaponType.Pistol, 1},
            {WeaponType.SubFusil, 1 }
        };
    }
}
