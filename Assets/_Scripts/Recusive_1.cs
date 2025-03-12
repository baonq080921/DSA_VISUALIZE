using System.Collections;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    [SerializeField] GameObject _ceilPrefabs;
    [SerializeField] int rows;
    [SerializeField] int cols;
    private GameObject [,] grid;

    void Awake()
    {
        CreateGrid();
        StartCoroutine(FindPath(0,0));
        
    }


    void CreateGrid(){
        grid = new GameObject[rows,cols];
        for(int i = 0 ; i < rows;i++){
            for(int j  = 0; j < cols; j++){
                Vector3 pos = new Vector3(j,-i,0);
                GameObject cell = Instantiate(_ceilPrefabs,pos,Quaternion.identity);
                grid[i,j] = cell;
            }
        }
    }

    IEnumerator FindPath(int r, int c){
        if(r >= rows || c >= cols) yield break;
        if(r == rows -1 && c == cols -1){
            grid[r,c].GetComponent<Renderer>().material.color = Color.red; // To mau o vach dich
            yield break;
        }


        grid[r,c].GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(1.5f);

        if(r+1 < rows){
            yield return StartCoroutine(FindPath(r+1,c));
        }else{
            yield return StartCoroutine(FindPath(r,c+1));
        }
    }

}
