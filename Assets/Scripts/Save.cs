using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


public static class Save {
	public static void saveGame(){
		System.Object[] save = {CreatePath.enemies, CreatePath.towers, PlayerBehaviors.money, PlayerBehaviors.health, PlayerBehaviors.wave, PlayerBehaviors.enemiesKilled};

		FileStream fs = new FileStream("Save.dat", FileMode.Create);
		BinaryFormatter formatter = new BinaryFormatter();

		try{
		   formatter.Serialize(fs, save);
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
			BinaryFormatter formatter = new BinaryFormatter();
			objs = (Object[]) formatter.Deserialize(fs);

			CreatePath.enemies = (ArrayList<Enemy>) objs[0];
			CreatePath.enemies = (ArrayList<AbstracTower>) objs[1];

			PlayerBehaviors.money = objs[2];
			PlayerBehaviors.health = objs[3];
			PlayerBehaviors.wave = objs[4];
			PlayerBehaviors.enemiesKilled = objs[5];
		}
		catch (SerializationException e){
		   throw;
	   }
	   finally{
		   fs.Close()
	}

}
