using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCode : MonoBehaviour
{

    //public int boardType;// = 0;
    public GameObject ballPrefab;
    public GameObject ballPrefab_invisible;
    private Vector3 hareketEdecekOlan;
    private Vector3 hareketEdilecekYer;
    public Text m_MyText,endOfGameText;
    private bool isTouchedABallBefore = false;
    private int score = 0;
    public SoundController soundController;

    private int[,] arr2d;
    private int[,] Narr2d;
    private List<List<Vector3>> points = new List<List<Vector3>>();
    private List<List<Vector3>> plates = new List<List<Vector3>>();

    public int _capacity;
    public int row;
    public int column;
    private const String save_arr2d = "Assets/Saved_Arr2d.txt";
    private const String saveOthers = "Assets/saveOthers.txt";
    
    void Start()
    {
        m_MyText.text = "Score: ";
        if (Menu.loadGame == true)
        {
            LoadGameFromFile();
            Menu.loadGame = false;
        }
        else StartGame();
    }
    //in update function i check if mouse clicked to balls or not
    void Update()
    {

        if (Input.GetMouseButtonDown(0) )
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {

                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        /*if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("loaded!!");
            LoadGameFromFile();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("saved!!");
            SaveArraysAndLists();
        }*/
                //Save();

    }
    //fills arr2d according to the saved arr2d
    private void takeArr2dValues()
    {
        for(int i=0; i<row; ++i)
        {
            for(int k=0; k<column; ++k)
            {
                arr2d[i, k] = Narr2d[i,k];
            }
        }
    }
    //this funciton will create and initialize 2d board array: arr2d 
    public void StartGame()
    {
        //classic board
        if ( Menu.boardType == 0)
        {
            this._capacity = 48;
            this.row = 7;
            this.column = 7;
            arr2d = new int[7, 7]{
                                {-1,-1, 1,1,1, -1,-1},
                                {-1,-1, 1,1,1, -1,-1},
                                {1, 1,  1,1,1,  1, 1},
                                {1, 1,  1,0,1,  1, 1},
                                {1, 1,  1,1,1,  1, 1},
                                {-1,-1, 1,1,1, -1,-1},
                                {-1,-1, 1,1,1,  -1,-1}
                            };
            if(Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        //diamond 
        else if (Menu.boardType == 2)
        {
            this._capacity = 48;
            this.row = 7;
            this.column = 7;
            arr2d = new int[7, 7]{
                                {-1,-1,-1,  1,  -1,-1,-1},
                                {-1,-1,  1, 1, 1,  -1,-1},
                                {-1,  1, 1, 1, 1, 1, -1},
                                {1, 1,  1,0,1,  1, 1},
                                {-1,  1, 1, 1, 1, 1, -1},
                                {-1,-1,  1, 1, 1,  -1,-1},
                                {-1,-1,-1,  1,  -1,-1,-1}
                            };
            if (Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        else if (Menu.boardType == 3)
        {
            this._capacity = 80;
            this.row = 9;
            this.column = 9;
            arr2d = new int[9,9 ]{
                                {-1,-1,-1, 1,1,1, -1,-1,-1},
                                {-1,-1,-1, 1,1,1, -1,-1,-1},
                                {-1,-1,-1, 1,1,1, -1,-1,-1},
                                {1,1, 1,  1,1,1,  1, 1,1},
                                {1,1, 1,  1,0,1,  1, 1,1},
                                {1,1, 1,  1,1,1,  1, 1,1},
                                {-1,-1,-1, 1,1,1, -1,-1,-1},
                                {-1,-1,-1, 1,1,1,  -1,-1,-1},
                                {-1,-1,-1, 1,1,1,  -1,-1,-1}
                            };
            if (Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        //arrow
        else if ( Menu.boardType == 4)
        {
            this._capacity = 48;
            this.row = 7;
            this.column = 7;
            arr2d = new int[7, 7]{
                                {-1,-1,-1,  1,  -1,-1,-1},
                                {-1,-1,  1, 1, 1,  -1,-1},
                                {-1,  1, 1, 1, 1, 1, -1},
                                {1, 1,  1,0,1,  1, 1},
                                {1, 1,  1,1,1,  1, 1},
                                {-1,-1, 1,1,1, -1,-1},
                                {-1,-1, 1,1,1,  -1,-1}
                            };
            if (Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        //pyramid
        else if (Menu.boardType == 5)
        {
            this._capacity = 48;
            this.row = 7;
            this.column = 7;
            arr2d = new int[7, 7]{
                                {-1,-1,-1,  1,  -1,-1,-1},
                                {-1,-1,  1, 1, 1,  -1,-1},
                                {-1,  1, 1, 1, 1, 1, -1},
                                {1, 1,  1,0,1,  1, 1},
                                {-1, -1,  -1,-1,-1,  -1, -1},
                                {-1, -1,  -1,-1,-1,  -1, -1},
                                {-1, -1,  -1,-1,-1,  -1, -1},
                            };
            if (Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        //diamond2
        else if (Menu.boardType == 6)
        {
            this._capacity = 48;
            this.row = 7;
            this.column = 7;
            arr2d = new int[7, 7]{
                                {-1, -1, 1, 1, 1, -1, -1},
                                {-1, 1, 1, 1, 1, 1, -1},
                                {1, 1, 1, 0, 1, 1, 1},
                                {1, 1, 1, 1, 1, 1, 1},
                                {1, 1, 1, 1, 1, 1, 1},
                                {-1, 1, 1, 1, 1, 1, -1},
                                {-1, -1, 1, 1, 1, -1, -1}
                            };
            if (Menu.loadGame == true)
            {
                takeArr2dValues();
            }
        }
        instantiateBoard(0);
        instantiateBallPrefabs();
        instantiateLittleBallPrefabs();

    }

    //AI will make movement
    //this function will look empty plates and its around. If possible movement exist, will do that randomly
    public void AI_turn()
     {
        List<Vector3> possibleMoves = new List<Vector3>();
        List<Vector3> objects = new List<Vector3>();

        int size = 0;
        for(int i=0; i<row; ++i)
         {
            if (size > 8) break;
            for (int k=0; k< column; ++k)
             {
                
                 if (arr2d[i, k] == 0)
                 {
                    if (k + 1 < column && arr2d[i, k + 1] == 1)
                    {
                        if (k + 2 <column && arr2d[i, k + 2] == 1)
                        {
                            objects.Add(points[i][k + 2]);
                            possibleMoves.Add(plates[i][k]);
                            size++;
                        }

                    }
                    if (k - 1 >= 0 && arr2d[i, k - 1] == 1)
                    {
                        if (k -2 >= 0 && arr2d[i, k - 2] == 1)
                        {
                            objects.Add(points[i][k - 2]);
                            possibleMoves.Add(plates[i][k]);
                            size++;
                        }

                    }
                    if (i + 1 < row && arr2d[i + 1, k] == 1)
                    {
                        if (i +2<row && arr2d[i +2, k] == 1)
                        {
                            objects.Add(points[i+2][k]);
                            possibleMoves.Add(plates[i][k]);
                            size++;
                        }

                    }
                    if (i - 1 >= 0 && arr2d[i - 1, k] == 1)
                    {
                        if (i -2 >= 0 && arr2d[i -2, k] == 1)
                        {
                            objects.Add(points[i-2][k]);
                            possibleMoves.Add(plates[i][k]);
                            size++;
                        }

                    }
                }
             }
         }
       
        System.Random rnd = new System.Random();
        int num=0;
        if (size > 0)
            num = rnd.Next(0,size-1);

        CurrentClickedGameObject(objects[num], possibleMoves[num]);
    }
    
    //these 2 functions determine which ball and plate clicked
    //for player
    public bool CurrentClickedGameObject(GameObject gameObject)
    {
        bool f=false;
        if (gameObject.name == "Sphere")
        {
            isTouchedABallBefore = true;
            hareketEdecekOlan = gameObject.transform.position;
            f = true;
            soundController.playSounds("moveSound2");
        }

        else if (gameObject.name == "InvisblePlate")
        {
            soundController.playSounds("moveSound2");
            if (isTouchedABallBefore)
            {
                //Debug.Log("moveObj:" + hareketEdecekOlan.x + " - " + hareketEdecekOlan.y + " - " + hareketEdecekOlan.z);
                //Debug.Log("movePoint:" + hareketEdilecekYer.x + " - " + hareketEdilecekYer.y + " - " + hareketEdilecekYer.z);
                if (isItMovable(hareketEdecekOlan, gameObject.transform.position))
                {
                    hareketEdilecekYer = gameObject.transform.position;
                    float[] Killcoordinates = findObjThatWillBeKilled(hareketEdecekOlan, hareketEdilecekYer);

                    DestroyObject(Killcoordinates);
                    score++;
                    m_MyText.text = "Score: " + score.ToString();
                    // SoundController.playSounds("moveSound2");
                    f = true;

                }
            }
            isTouchedABallBefore = false;
            if (isGameOver())
            {
                Debug.Log("gameover");
                //StartCoroutine(WaitAtEndOfGame());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
        }
        //Save();
        return f;
    }
    //for AI
    public void CurrentClickedGameObject(Vector3 moveObj,Vector3 movePoint)
    {
        if (isItMovable(moveObj, movePoint))
        {
            float[] Killcoordinates = findObjThatWillBeKilled(moveObj, movePoint);
            DestroyObject(Killcoordinates);
            // score++;
            m_MyText.text = "Score: " + score.ToString();
            soundController.playSounds("moveSound2");
        }
        else Debug.Log("AI failed");
        
        if (isGameOver())
        {
            Debug.Log("gameover");
            //StartCoroutine(WaitAtEndOfGame());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //Save();
    }
    
    public void instantiateBoard(int _type)
    {
        float x=0, z=0;

        for (int i=0; i<row; ++i)
        {
            List<Vector3> v = new List<Vector3>() { };
            List<Vector3> vPlates = new List<Vector3>() { };

            for (int k =0; k < column; ++k)
            {

                if (arr2d[i, k] == 1)
                {
                    v.Add(new Vector3(x, 1.2f, z));
                    vPlates.Add(new Vector3(x, 0.8f, z));

                }
                else if (arr2d[i, k] == 0)
                {
                    v.Add(new Vector3(x, 1.2f, z));
                    vPlates.Add(new Vector3(x, 0.8f, z));
                }
                else
                {
                    v.Add(new Vector3(x, 1.2f, z));
                    vPlates.Add(new Vector3(x, 0.8f, z));

                }
                x += 1.5f;
            }
            points.Add(v);
            plates.Add(vPlates);
            x = 0;
            z +=1.5f;
        }

        points.Reverse();
        plates.Reverse();
    }


    //hedef noktanın movable olup olmadığına bakar
    bool isItMovable(Vector3 Obje,Vector3 yer) 
    {
        Vector2 hareketEdecekObje = getArr2dCoordinat(Obje);
        Vector2 hareketEdilecekYer = getArr2dCoordinat_Plate(yer);
        bool returnValue = false;
        if ((hareketEdilecekYer.y == hareketEdecekObje.y) &&
            Mathf.Abs(hareketEdilecekYer.x - hareketEdecekObje.x) == 2)
        {
            returnValue = true;
        }
        //yatayda
        else if ((hareketEdilecekYer.x == hareketEdecekObje.x) &&
            Mathf.Abs(hareketEdilecekYer.y - hareketEdecekObje.y) == 2)
        {
            returnValue = true;
        }
        return returnValue;
    }

    /*
     returnArr : float array that contains indexes
                    [0] -> x coordinate in 3d
                    [1] -> z coordinate in 3d
                    [2] -> x coordinate in 2d
                    [3] -> y coordinate in 2d
                    [4] -> x coordinate in 3d
                    [5] -> y coordinate in 3d
     */
    float[] findObjThatWillBeKilled(Vector3 hareketEdecekObje, Vector3 hareketEdilecekYer)
    {
        Vector3 nVec;
        
        nVec.x = (hareketEdilecekYer.x + hareketEdecekObje.x)/ 2;
        nVec.z = (hareketEdilecekYer.z + hareketEdecekObje.z) / 2;
        nVec.y = 1.2f;
        Vector2 hareketEdecek_arr2d = getArr2dCoordinat(hareketEdecekObje);
        Vector2 hareketYeri_arr2d = getArr2dCoordinat_Plate(hareketEdilecekYer);
        for (int i=0; i<row; i++)
        {
            for(int k=0; k<column; ++k)
            {
                if (nVec == points[i][k])
                {
                    return new float[] { i, k, hareketEdecek_arr2d.x, hareketEdecek_arr2d.y, 
                        hareketYeri_arr2d.x, hareketYeri_arr2d.y }; //sends to coordinates of arr
                }
            }
        }
        return null;
    }

    //2d vector3 listindeki elemanların arr2d'de nerde olduğunu verir
    
    private Vector2 getArr2dCoordinat(Vector3 _coordinate)
    {
        Vector2 vec = new Vector2();
        int j=0;
        for(int i=0; i<7; ++i)
        {
            foreach(var x in points[i])
            {
                if(_coordinate == x)
                {
                   // Debug.Log("3d uzaydaki koordinatı: "+_coordinate.x + " - " + _coordinate.z);
                    //Debug.Log("2d Ar2dd'deki koordinatı: " + i +" - "+j);
                    vec.x = i;
                    vec.y = j;
                    break;
                }
                j++;
            }
            j = 0;
        }
        return vec;
    }
    private Vector2 getArr2dCoordinat_Plate(Vector3 _coordinate)
    {
        Vector2 vec = new Vector2();
        int j = 0;
        for (int i = 0; i < 7; ++i)
        {
            foreach (var x in plates[i])
            {
                if (_coordinate == x)
                {
                    //Debug.Log("3d uzaydaki koordinatı: " + _coordinate.x + " - " + _coordinate.z);
                    //Debug.Log("2d Ar2dd'deki koordinatı: " + i + " - " + j);
                    vec.x = i;
                    vec.y = j;
                    break;
                }
                j++;
            }
            j = 0;
        }
        return vec;
    }
    public void instantiateBallPrefabs()
    {
        for (int i=0; i<row; ++i)
        {
            for (int k = 0; k < column; ++k)
            {
                if (arr2d[i, k] == 1)
                {
                    Instantiate(ballPrefab, points[i][k], Quaternion.identity);
                }
                
            }

        }
    }

    
    void DestroyObject(float[] Killcoordinates)
    {
        GameObject[] ballArr;
        ballArr = GameObject.FindGameObjectsWithTag("Finish");
        int i_counter = 0;
        foreach (GameObject  tempObj in ballArr)
        {
            if (tempObj.transform.position == points[(int)Killcoordinates[0]][(int)Killcoordinates[1]])
            {

                GameObject.Destroy(tempObj);
               // _capacity--;
                //arr2d will be updated
                arr2d[(int)Killcoordinates[0],(int)Killcoordinates[1]] = 0;
            }
            //hareket edecek olanı da sil
            if (tempObj.transform.position == points[(int)Killcoordinates[2]][(int)Killcoordinates[3]])
            {
                //kill object that will be moved 
                GameObject.Destroy(tempObj);
                arr2d[(int)Killcoordinates[2], (int)Killcoordinates[3]] = 0;

                //movement proccess
                GameObject temp = Instantiate(ballPrefab, points[(int)Killcoordinates[4]][(int)Killcoordinates[5]], Quaternion.identity);
                ballArr[i_counter] = temp;
                arr2d[(int)Killcoordinates[4], (int)Killcoordinates[5]] = 1;

            }
            i_counter++;
        }
    }
    public void instantiateLittleBallPrefabs()
    {

        for (int i = 0 ; i <row; ++i)
        {
            for (int k = 0; k<column; ++k)
            {
                if (arr2d[i, k] != -1)
                {
                    Vector3 tempVec = points[i][k];
                    //tempVec.y = 0.7f;
                    //Instantiate(liitleBallPrefab, tempVec, Quaternion.identity);
                    tempVec.y = 0.8f;
                    Instantiate(ballPrefab_invisible, tempVec, Quaternion.identity);
                    
                }
                    
            }

            //Debug.Log(i);
        }
    }


    private bool isGameOver()
    {
        bool r_value = true;
        for(int i=0; i<row; ++i)
        {
            for(int k=0; k < column; ++k)
            {
                if (arr2d[i, k] == 1)
                {
                    if(k+1<row && arr2d[i,k+1] == 1)
                    {
                        if (k - 1 >=0 && arr2d[i, k - 1] == 0)
                        {
                            r_value = false;
                            break;
                        }

                    }
                    else if (k - 1 >= 0 && arr2d[i, k - 1] == 1)
                    {
                        if (k + 1 < row && arr2d[i, k + 1] == 0)
                        {
                            r_value = false;
                            break;
                        }

                    }
                    else if (i + 1 < row && arr2d[i+1, k] == 1)
                    {
                        if (i - 1 >= 0 && arr2d[i-1, k ] == 0)
                        {
                            r_value = false;
                            break;
                        }

                    }
                    else if (i - 1 >= 0 && arr2d[i-1, k ] == 1)
                    {
                        if (i + 1 < row && arr2d[i+1, k] == 0)
                        {
                            r_value = false;
                            break;
                        }

                    }
                }
                
            }
        }

        return r_value;
    }

    IEnumerator WaitAtEndOfGame()
    {
        endOfGameText.text = "GAME OVER";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }


    //loads last saved game
    public void LoadGameFromFile()
    {
        StreamReader rd_arr2d = new StreamReader(save_arr2d);
        StreamReader rd_others = new StreamReader(saveOthers);
        String value;
        short result;

        value = rd_others.ReadLine();
        row = Int16.Parse(value);
        value = rd_others.ReadLine();
        column = Int16.Parse(value);
        value = rd_others.ReadLine();
        _capacity = Int16.Parse(value);
        value = rd_others.ReadLine();
        Menu.boardType = Int16.Parse(value);
        Narr2d = new int[row,column];
        int isize = 0;
        for (int i = 0; i < row; ++i)
        {
            for (int k = 0; k < column; ++k)
            {
                value=rd_arr2d.ReadLine();
                if (value != null)
                {
                    //Debug.Log("bura1");
                    //if(Int16.TryParse(value,out result))
                   // {
                     //   Debug.Log("bura2");

                        //arr2d[i, k] = (int)result;
                        result = Int16.Parse(value);
                        Narr2d[i,k]=result;
                        isize++;
                        //Debug.Log("buraya girdibabababa");
                 //   }
                }
                else return;
            }
        }
        StartGame();
    }
    //saves the current game
    public void SaveArraysAndLists()
    {
        StreamWriter writer_arr2d = new StreamWriter(save_arr2d);
        StreamWriter writer_others = new StreamWriter(saveOthers);
        for (int i=0; i<row; ++i)
        {
            for(int k=0; k<column; ++k)
            {
                writer_arr2d.WriteLine(arr2d[i,k].ToString());
            }
        }

        writer_others.WriteLine(row);
        writer_others.WriteLine(column);
        writer_others.WriteLine(_capacity);
        writer_others.Write(Menu.boardType);

        writer_arr2d.Close();
        writer_others.Close();

        Debug.Log("game is saved");
    }


}
