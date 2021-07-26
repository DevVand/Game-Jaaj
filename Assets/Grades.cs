using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grades : MonoBehaviour
{
    public string[] A;
    public string[] B;
    public string[] C;
    public string[] D;

    public string gradeRandom()
    {
        float r = Random.value;
        string s = "";
        if (r>.75f)
            s = D[Random.Range(0, D.Length)];
        else if (r>.50f)
            s = C[Random.Range(0, C.Length)];
        else if (r > .25f)
            s = B[Random.Range(0, B.Length)];
        else
            s = A[Random.Range(0, A.Length)];
        return s;
    }
    public string gradeA() {
        return A[Random.Range(0,A.Length)];
    }
    public string gradeB()
    {
        return B[Random.Range(0, B.Length)];
    }
    public string gradeC()
    {
        return C[Random.Range(0, C.Length)];
    }
    public string gradeD()
    {
        return D[Random.Range(0, D.Length)];
    }
}
