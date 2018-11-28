using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;




public static class Save {
	public static void saveGame(){
		System.Object[] save = {CreatePath.enemies, CreatePath.towers, PlayerBehaviors.money, PlayerBehaviors.health, PlayerBehaviors.wave, PlayerBehaviors.enemiesKilled};

		FileStream fs = new FileStream("Save.dat", FileMode.Create);
		StreamWriter writer = new StreamWriter(fs);

		try{
		   string json = JsonUtility.ToJson(CreatePath.enemies);
		   Debug.Log(json);
		   writer.Write(json);
		}
		catch (SerializationException e){
		   throw;
		}
		finally{
		   fs.Close();
		}
	}
	public static void loadGame(){
		FileStream fs = new FileStream("Save.dat", FileMode.Open);
		try{
			string str;
			using (StreamReader reader = new StreamReader(fs)){
	   			str = reader.ReadToEnd();
   			}

			System.Object[] objs = JsonUtility.FromJson<System.Object[]>(str);



			CreatePath.enemies = (List<GameObject>) objs[0];
			CreatePath.enemies = (List<GameObject>) objs[1];

			PlayerBehaviors.money = (int)objs[2];
			PlayerBehaviors.health = (int)objs[3];
			PlayerBehaviors.wave = (int)objs[4];
			PlayerBehaviors.enemiesKilled = (int)objs[5];
		}
		catch (SerializationException e){
		   throw;
	   }
	   finally{
		   fs.Close();
		}
	}

}
