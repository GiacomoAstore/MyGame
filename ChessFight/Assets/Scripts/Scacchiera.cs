using System;
using UnityEngine;

public class Scacchiera : MonoBehaviour{

    private GameObject[,] caselle;

    [SerializeField]
    private Material matCaselle;

    [SerializeField]
    private int xCount = 8;
    [SerializeField]
    private int yCount = 8;
    [SerializeField]
    private int sizeCasella = 1;

    private const string LAYER_CASELLA = "Casella";
    private const string LAYER_HOVER = "Hover";

    private void Awake() {

        caselle = new GameObject[xCount, yCount];

        for (int i = 0; i < xCount; ++i) {
            for (int j = 0; j < yCount; ++j) {
                caselle[i, j] = generaCasella(sizeCasella, i, j);
            }
        }

        
    }

    private GameObject generaCasella(int sizeCasella, int i, int j) {

        GameObject casella = new GameObject(i.ToString()+ j.ToString());

        //servono per renderizzare la casella
        Mesh mesh = new Mesh();
        casella.AddComponent<MeshFilter>().mesh = mesh;
        casella.AddComponent<MeshRenderer>().material = matCaselle;

        //adesso i vertici per il posizionamento
        Vector3[] vertici = new Vector3[4];

        vertici[0] = new Vector3(i*sizeCasella,0,j*sizeCasella);
        vertici[1] = new Vector3(i * sizeCasella, 0, (j+1) * sizeCasella);
        vertici[2] = new Vector3((i+1) * sizeCasella, 0, j * sizeCasella);
        vertici[3] = new Vector3((i+1) * sizeCasella, 0, (j+1) * sizeCasella);

        int[] triangoli = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertici;
        mesh.triangles = triangoli;
        mesh.RecalculateNormals();

        casella.AddComponent<BoxCollider>();

        //ogni casella appartiene alla scacchiera
        casella.transform.parent = transform;
        return casella;
    }
}
