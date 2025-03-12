using UnityEngine;

public class SumVisualize : MonoBehaviour
{

    [SerializeField] int n;
    [SerializeField] GameObject prefabs;
    [SerializeField] float forceUp = 2f;
    public float explosiveFloat = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int total = Sum(n);
        Debug.Log(total);
         InstantiateBall(total);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBall(Sum(n));
       
    }

    int Sum(int n){
        if(n == 0){
            return 0;
        }else{
            return n + Sum(n-1);
        }
    }

    void InstantiateBall(int totalBall){
        for(int i = 0; i < totalBall; i++){
            // float x = -(i / col) * 1.5f;
            // float y = (i % col) * 1.5f;
            GameObject ball = Instantiate(prefabs,transform.position*-1.5f,Quaternion.identity);
            Rigidbody newRb = ball.GetComponent<Rigidbody>();
            newRb.AddForce(Vector3.up * explosiveFloat,ForceMode.Impulse);
            Destroy(ball,2f);

        }
    }
}