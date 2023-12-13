using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragPieces : MonoBehaviour
{
    public AudioClip clip;
    public GameObject clueText;
    private int queens=8;

    [System.Serializable]
    public struct rowData{ //struct creates a 2D array of game objects in inspector
        public GameObject[] columns; //List is initially empty
    }
    public rowData[] rows=new rowData[8];//creates 8 instances
    [System.Serializable]
    public struct isValid{
        public bool[] snapPoints;// struct creates a 2D array of boolean values in inspector
    }
    public isValid[] points=new isValid[8]; //creates 8 instances
    [System.Serializable]
    public struct queenPosition{
        public bool[] position;
    }
    public queenPosition[] queen=new queenPosition[8];
    public Camera tableCamera;
    private float snapSensitivity=0.2f;
    GameObject objectSelected =null;
    void Start(){
        AudioSource audio = GetComponent<AudioSource>();
        for(int i=0; i<8; i++){
            for(int j=0; j<8; j++){
                points[i].snapPoints[j]=true; //initializes all boolean values to true
            }
        }
        clueText.SetActive(false);//clue text is hidden
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ //when left mouse button is clicked
            //check if object is clicked on
            CheckHitObject();
        }
        if(Input.GetMouseButton(0) && objectSelected!=null && objectSelected.CompareTag("Drag")){
            //drag an object
            DragObject();
        }
        if(Input.GetMouseButtonUp(0) && objectSelected!=null){
            //drop object
            DropObject();
        }
        if(queens<=0){
            queens=10;
            GetComponent<AudioSource>().Play();
            clueText.SetActive(true);
        }
    }
    public void CheckHitObject(){
        if (objectSelected==null){
            RaycastHit hit;
            Ray ray = tableCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                objectSelected=hit.transform.gameObject;
            }
        }

    }
    public void DragObject(){
        for(int i=0; i<8; i++){
            for (int j=0; j<8; j++){
                if((objectSelected.transform.position.x==rows[i].columns[j].transform.position.x) &&
                (objectSelected.transform.position.z==rows[i].columns[j].transform.position.z)){
                    ValidateRow(i);
                    ValidateColumn(j);
                    ValidateDiagonals(i, j);
                    queen[i].position[j]=false;
                    queens=queens+1;
                    //Debug.Log("Number of queens: " + queens);
                }
            }
        /*for(int i=7; i>=0; i--){
            bool breakingLoop=false;
            for (int j=7; j>=0; j--){
                if(objectSelected.transform.position.x==rows[i].columns[j].transform.position.x){
                    ValidateRow(i);
                    ValidateColumn(j);
                    ValidateDiagonals(i, j);
                    breakingLoop=true;
                    break;
                }
            }
            if (breakingLoop){
                break;
            }*/
        }
        objectSelected.transform.position=tableCamera.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, 4.5f));
    }
    public void DropObject(){
        for (int i=0; i<8; i++){
            for (int j=0; j<8; j++){
                if((Vector3.Distance(rows[i].columns[j].transform.position, 
                    objectSelected.transform.position)< snapSensitivity) && points[i].snapPoints[j]){
                        objectSelected.transform.position=new Vector3(
                        rows[i].columns[j].transform.position.x,     
                        rows[i].columns[j].transform.position.y-0.3f, 
                        rows[i].columns[j].transform.position.z);
                        InvalidateRow(i);
                        InvalidateColumn(j);
                        InvalidateDiagonals(i, j);
                        queen[i].position[j]=true;
                        queens=queens-1;
                        //Debug.Log("Number of queens: " + queens);
                }

            }
        }
        objectSelected=null;
    }
    private void InvalidateRow(int row){
        for (int i = 0; i < 8; i++){
            points[row].snapPoints[i] = false;
        }
    }

    private void InvalidateColumn(int column){
        for (int i = 0; i < 8; i++){
            points[i].snapPoints[column] = false;
        }
    }

    private void InvalidateDiagonals(int row, int column){
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++){
                if (Mathf.Abs(row - i) == Mathf.Abs(column - j)){
                    points[i].snapPoints[j] = false;
                }
            }
        }
    }
    private void ValidateRow(int row){
        for (int i = 0; i < 8; i++){
            if(!queen[row].position[i]){
                points[row].snapPoints[i] = true;
            }
        }
    }
    private void ValidateColumn(int column){
        for (int i = 0; i < 8; i++){
            //if(!queen[i].position[column]){
                points[i].snapPoints[column] = true;
            //}
        }
    }
    private void ValidateDiagonals(int row, int column){
        for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++){
                if (Mathf.Abs(row - i) == Mathf.Abs(column - j)){
                    points[i].snapPoints[j] = true;
                }
            }
        }
    }
}