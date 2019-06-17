using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAssigner : MonoBehaviour {
	[SerializeField]
	Texture2D[] sheetsNormal;
	[SerializeField]
	GameObject RoomObj;
    public GameObject enemy1;
    public GameObject enemy2;
    private Vector2 roompos;
    public Vector2 roomDimensions = new Vector2(16*17,16*9);
	public Vector2 gutterSize = new Vector2(16*9,16*4);
    public int maxNumOfEnemies=3;
    public int minNumOfEnemies=2;
    public void Assign(Room[,] rooms)
    {
        bool firstFor = true;

        for (int i = 0; i < rooms.GetLength(0); i++)
        {
            for (int j = 0; j < rooms.GetLength(1); j++)
            {


                //foreach (Room room in rooms){

                //skip point where there is no room
                if (rooms[i,j] == null)
                {
                    continue;
                }
                //pick a random index for the array
                int index = Mathf.RoundToInt(Random.value * (sheetsNormal.Length - 1));
                //find position to place room
                Vector3 pos = new Vector3(rooms[i, j].gridPos.x * (roomDimensions.x + gutterSize.x), rooms[i, j].gridPos.y * (roomDimensions.y + gutterSize.y), 0);
                RoomInstance myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<RoomInstance>();


                myRoom.Setup(sheetsNormal[index], rooms[i, j].gridPos, rooms[i, j].type, rooms[i, j].doorTop, rooms[i, j].doorBot, rooms[i, j].doorLeft, rooms[i, j].doorRight);
                if (firstFor)
                {
                    firstFor = false;

                }
                else
                {
                    roompos = pos;
                    spawnEnemy();
                }

            }
        }
    }


    void spawnEnemy()
    {
        Random random = new Random();
        int numOfEnemies = Random.Range(minNumOfEnemies, maxNumOfEnemies);
        
        for (int i = 0; i<numOfEnemies; i++)
        {
            int whichEnemy = Random.Range(1, 3);
            Vector2 vec = new Vector2(Random.Range(-80f,80f), Random.Range(-60f, 60f));
            if (whichEnemy == 1)
            {
                GameObject a = Instantiate(enemy1) as GameObject;
                a.transform.position = roompos + vec;
            }
            if(whichEnemy == 2)
            {
                GameObject a = Instantiate(enemy2) as GameObject;
                a.transform.position = roompos + vec;
            }

        }

    }
}
