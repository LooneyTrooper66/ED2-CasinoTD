
using System.Collections.Generic;

using UnityEngine;

public class RowRandomiser : MonoBehaviour
{
    public GameObject tile0;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    //public GameObject entrance;
    // public GameObject exit;

    //public List<GameObject> tiles;
    public List<Vector3> tilepos;

    public List<TileMove> tileMoves;

    public bool lastRoll;

    public RowRandomiser nextRow;
    public Slot_Manager sM;

    private float placehold = 4.5f;
    private float placeholdper;

    public float rowSpeed;
    public bool slowing;
    public bool stop;

    public int rowhostint;
    private TileMove tilemovesample;
    public bool reset;
    // Start is called before the first frame update
    void Awake()
    {
        tilepos.Add(tile0.transform.position);
        tilepos.Add(tile1.transform.position);
        tilepos.Add(tile2.transform.position);
        tilepos.Add(tile3.transform.position);

        tileMoves.Add(tile0.GetComponent<TileMove>());
        tileMoves.Add(tile1.GetComponent<TileMove>());
        tileMoves.Add(tile2.GetComponent<TileMove>());
        tileMoves.Add(tile3.GetComponent<TileMove>());

        StartRolls();


    }

    // Update is called once per frame
    void Update()
    {
        //debug tool remove i think?
        if (lastRoll)
        {
            lastRoll = false;
            tileMoves[rowhostint].stopSpin = true;
              
        }
        if (reset)
        {
            reset = false;
            VauleRest();
        }

        if (slowing)
        {
            Slowdown();
        }
    }

    public void StartRolls()
    {
        //currentdecl = 0;
        placehold = 4.5f;
        slowing = false;
        //resets the vaules of the tiles to prepair them for their next roll
        //resets the tile order
        //RandomiseTileOrder();
        RandomiseTileOrder();
    }

    public void VauleRest()
    {
        for (int i = 0; i < tileMoves.Count; i++)
        {
            tileMoves[i].speed = rowSpeed;
            tileMoves[i].stopSpin = false;
            tileMoves[i].stop = false;

        }
        StartRolls();
    }


    /// <summary>
    /// change the goal position of each tile to then larp then into position like a slot machine :3
    /// </summary>
    public void RandomiseTileOrder()
    {
        int i = Random.Range(0, 3);
        //Debug.Log(i);
        switch (i)
        {
            case 0: //w c m y
                //tiles[0].transform.position = tilePos0;
                //tiles[1].transform.position = tilePos1;
                //tiles[2].transform.position = tilePos2;
                RollTile(0, 1, 2, 3);
                tileMoves[3].rowHost = true;
                rowhostint = 3;
                break;
            case 1://y w c m
                //tiles[2].transform.position = tilePos0;
                //tiles[0].transform.position = tilePos1;
                //tiles[1].transform.position = tilePos2;
                RollTile(3, 0, 1, 2);
                tileMoves[2].rowHost = true;
                rowhostint = 2;
                break;
            case 2://m y w c
                //tiles[1].transform.position = tilePos0;
                //tiles[2].transform.position = tilePos1;
                //tiles[0].transform.position = tilePos2;
                /*  RollTile(2, 3, 0, 1);
                  tileMoves[1].rowHost = true;
                  rowhostint = 1;*/
                RollTile(1, 2, 3, 0);
                tileMoves[0].rowHost = true;
                rowhostint = 0;
                break;
           /* case 3://c m y w
                RollTile(1, 2, 3, 0);
                tileMoves[0].rowHost = true;
                rowhostint = 0;
                break;*/
            default:
                Debug.Log("ERROR");
                break;
        }
        stop = false;
        //run function to begin lerp
    }

    /// <summary>
    /// lerp every tile in a row to the exit then back to the entrance. once enough loops of that are done the next time the move back to the entracnce they will loop to the position defined in the RandomiseTileOrder()
    /// dont lerp as the didtance would = weird movement wat i need to do is make it move fixed speed then on hitting tyhe exit tp back to the entrance 
    /// </summary>
    public void RollTile(int w, int c, int m, int y) //each corrispond to a tile
    {
        tileMoves[0].slotPos = tilepos[w];
        tileMoves[1].slotPos = tilepos[c];
        tileMoves[2].slotPos = tilepos[m];
        tileMoves[3].slotPos = tilepos[y];

    }

    public void Stop()
    {
        stop = true;
        // VauleRest();
        tileMoves[rowhostint].rowHost = false;
        for (int o = 0; o < tileMoves.Count; o++)
        {
            tileMoves[o].transform.position = tileMoves[o].slotPos;
        }

        if (nextRow == null)
        {
            GeneratePath();
            sM.JackpotCheck();
        }
        else
        {
            //nextRow.StartRolls();
            nextRow.lastRoll = true;
        }
    }

    public void Slowdown()
    {
        //  6 -= speed = n
        //  n/6 = % 
        //  speed = normspeed * %
        placehold -= Time.deltaTime / 2;
        placehold = Mathf.Clamp(placehold, 0.2f,1);
        placeholdper = (placehold + 0.5f) / 3.5f;
        //placeholdper = Mathf.Clamp((placeholdper), 0.1f, 1);
        //placehold/6

        //currentdecl += distance to goal - distance current / total distance 
        for (int o = 0; o < tileMoves.Count; o++)
        {
            tileMoves[o].speed = rowSpeed * placeholdper;
        }

    }

    //
    void GeneratePath()
    {
        Debug.Log(":3");
    }

}
