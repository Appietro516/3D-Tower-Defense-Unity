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
	public static void saveLeaderboard(){
		int[] save = {PlayerBehaviors.wave, PlayerBehaviors.enemiesKilled};

		FileStream fs = new FileStream("Save.dat", FileMode.Create);
		StreamWriter writer = new StreamWriter(fs);

		try{
		   string json = JsonUtility.ToJson(save);
		   writer.Write(json);
		}
		catch (SerializationException e){
		   throw;
		}
		finally{
		   fs.Close();
		}
	}
	public static void loadLeaderBoard(){
		FileStream fs = new FileStream("Save.dat", FileMode.Open);
		try{
			string str;
			using (StreamReader reader = new StreamReader(fs)){
	   			str = reader.ReadToEnd();
				int[] objs = JsonUtility.FromJson<int[]>(str);


				if (objs != null){
					LeaderBoard.wave = objs[0];
					LeaderBoard.enemyDeaths = objs[1];
				}
   			}

		}
		catch (SerializationException e){
		   throw;
	   }
	   finally{
		   fs.Close();
		}
	}

}
