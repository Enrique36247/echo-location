using UnityEngine;

using System.Collections.Generic;



public class MazeGenerator : MonoBehaviour

{

    [Header("Configuración del Laberinto")]

    public int width = 30; // He subido un poco el tamaño para que el camino luzca más

    public int depth = 30;

    public float spacing = 2f;

    [Range(0, 1)]

    public float wallDensity = 0.45f; 



    [Header("Referencias")]

    public GameObject wallPrefab;

    public GameObject goalPrefab;

    public Transform playerTransform;



    [Header("Seguridad")]

    public float playerSafeRadius = 4f;

    public float goalSafeRadius = 4f;



    private Vector3 goalPos;

    private HashSet<Vector2Int> pathCells = new HashSet<Vector2Int>();



    void Start()

    {

        goalPos = new Vector3((width - 2) * spacing, 1f, (depth - 2) * spacing);

        CreateDrunkenPath(); // Nuevo algoritmo de camino serpenteante

        GenerateMaze();



        if (goalPrefab != null)

        {

            GameObject goal = Instantiate(goalPrefab, goalPos, Quaternion.identity);

            goal.tag = "Goal";

        }

    }



    void CreateDrunkenPath()

    {

        Vector2Int current = new Vector2Int(2, 2);

        Vector2Int target = new Vector2Int(width - 2, depth - 2);

        

        pathCells.Add(current);



        int maxSteps = 2000; // Límite para evitar bucles infinitos

        int steps = 0;



        while (current != target && steps < maxSteps)

        {

            steps++;



            // Elegimos una dirección al azar de las 4 posibles

            Vector2Int direction = Vector2Int.zero;

            float r = Random.value;



            if (r < 0.25f) direction = Vector2Int.up;

            else if (r < 0.50f) direction = Vector2Int.down;

            else if (r < 0.75f) direction = Vector2Int.left;

            else direction = Vector2Int.right;



            Vector2Int nextStep = current + direction;



            // Comprobamos que el paso no se salga del laberinto (respetando bordes)

            if (nextStep.x > 1 && nextStep.x < width - 2 && nextStep.y > 1 && nextStep.y < depth - 2)

            {

                // Para que no sea un caos total, le damos un "empujoncito" hacia la meta

                // Si el paso aleatorio nos aleja mucho, a veces lo ignoramos para reorientarnos

                float distOld = Vector2.Distance(current, target);

                float distNew = Vector2.Distance(nextStep, target);



                // Si el nuevo paso nos acerca, o si tenemos "suerte" (30% de probabilidad de alejarnos)

                if (distNew < distOld || Random.value < 0.3f)

                {

                    current = nextStep;

                    pathCells.Add(current);

                }

            }

        }

    }



    void GenerateMaze()

    {

        for (int x = 0; x < width; x++)

        {

            for (int z = 0; z < depth; z++)

            {

                Vector3 currentPos = new Vector3(x * spacing, 1.5f, z * spacing);

                Vector2Int cell = new Vector2Int(x, z);



                // 1. MUROS EXTERIORES

                if (x == 0 || x == width - 1 || z == 0 || z == depth - 1)

                {

                    SpawnWall(currentPos);

                    continue;

                }



                // 2. CAMINO GARANTIZADO (Aquí no habrá pared)

                if (pathCells.Contains(cell))

                {

                    continue; 

                }



                // 3. SEGURIDAD JUGADOR Y META

                float distToPlayer = Vector3.Distance(currentPos, playerTransform.position);

                float distToGoal = Vector3.Distance(currentPos, goalPos);



                if (distToPlayer > playerSafeRadius && distToGoal > goalSafeRadius)

                {

                    // 4. RELLENO DE PAREDES ALEATORIAS

                    if (Random.value < wallDensity)

                    {

                        SpawnWall(currentPos);

                    }

                }

            }

        }

    }



    void SpawnWall(Vector3 position)

    {

        if (wallPrefab != null)

        {

            Instantiate(wallPrefab, position, Quaternion.identity, transform);

        }

    }

}