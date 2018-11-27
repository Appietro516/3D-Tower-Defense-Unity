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


}
