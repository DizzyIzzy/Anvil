using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFormation : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 followPosition;
  
    public float speed = 15.0f;

    public GameObject[] followUnits;

    public int spreadDistance = 5;

    public bool inFormation = false;

    void Start()
    {


        followUnits = GameObject.FindGameObjectsWithTag("Follow");


        foreach (GameObject child in followUnits)
        {
            child.transform.parent = this.transform;
        }


        //followUnitts = GameObject.child
        //followUnits = GetComponentsInChildren<GameObject>();
    }

    void Update()
    {
        //followUnits = GetComponentsInChildren<GameObject>();
        //  if (!inFormation)
        //  {
        // Vformation();
        //FingerFourFormation();
        //FourSquareFormation();
        //Echelon();
        //SpreadFormation();
        // TrailFormation();
        //FluidFour();
        //    inFormation = true;
        // }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TrailFormation();
            FluidFour();
        }

    }



    public void TrailFormation()
    {
        for (int i = 0; i < followUnits.Length; i++)
        {
            followPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - ((i + 1) * spreadDistance));
            followUnits[i].transform.position = followPosition; // Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
            followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
        }
    }




    public void FluidFour()
    {
        for (int i = 0; i < followUnits.Length; i++)
        {
            if (i == 0)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (1 * spreadDistance), transform.position.y, transform.position.z);
                // followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.position = Vector3.Lerp(followUnits[i].transform.position, followPosition, 1);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 1)
            {
                followPosition = new Vector3(transform.position.x - spreadDistance, transform.position.y, followTarget.transform.position.z - spreadDistance);
                // followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.position = Vector3.Lerp(followUnits[i].transform.position, followPosition, 1);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 2)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (2 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                // followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.position = Vector3.Lerp(followUnits[i].transform.position, followPosition, 1);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
        }
    }




    public void FingerFourFormation()
    {

        for (int i = 0; i < followUnits.Length; i++)
        {
            if (i == 0)
            {
                followPosition = new Vector3(followTarget.transform.position.x - (1 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 1)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (1 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 2)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (2 * spreadDistance), transform.position.y, followTarget.transform.position.z - (2 * spreadDistance));
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
        }


    }

    public void FourSquareFormation()
    {
        for (int i = 0; i < followUnits.Length; i++)
        {
            if (i == 0)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (1 * spreadDistance), transform.position.y, transform.position.z);
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 1)
            {
                followPosition = new Vector3(transform.position.x, transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
            if (i == 2)
            {
                followPosition = new Vector3(followTarget.transform.position.x + (1 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
            }
        }
    }



    public void Echelon()
    {
        for (int i = 0; i < followUnits.Length; i++)
        {
            followPosition = new Vector3(followTarget.transform.position.x + ((i + 1) * spreadDistance), transform.position.y, transform.position.z + ((i + 1) * -spreadDistance));
            followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
            followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
        }
    }


    public void SpreadFormation()
    {
        for (int i = 0; i < followUnits.Length; i++)
        {
            followPosition = new Vector3(followTarget.transform.position.x + ((i + 1) * spreadDistance), transform.position.y, transform.position.z);
            followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
            followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
        }
    }





    public void Vformation()
    {
        //This is a little ugly but it keeps track of the positions of up to 8 followers, if more are needed the pattern can easily be added to

        Debug.Log("V formation");

        for (int i = 0; i < followUnits.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (i == 0)
                {
                    followPosition = new Vector3(followTarget.transform.position.x - (1 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 2)
                {
                    followPosition = new Vector3(followTarget.transform.position.x - (2 * spreadDistance), transform.position.y, followTarget.transform.position.z - (2 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 4)
                {
                    followPosition = new Vector3(followTarget.transform.position.x - (3 * spreadDistance), transform.position.y, followTarget.transform.position.z - (3 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 6)
                {
                    followPosition = new Vector3(followTarget.transform.position.x - (4 * spreadDistance), transform.position.y, followTarget.transform.position.z - (4 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 8)
                {
                    followPosition = new Vector3(followTarget.transform.position.x - (5 * spreadDistance), transform.position.y, followTarget.transform.position.z - (5 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
            }
            else if (i % 2 == 1)
            {

                if (i == 1)
                {
                    followPosition = new Vector3(followTarget.transform.position.x + (1 * spreadDistance), transform.position.y, followTarget.transform.position.z - (1 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 3)
                {
                    followPosition = new Vector3(followTarget.transform.position.x + (2 * spreadDistance), transform.position.y, followTarget.transform.position.z - (2 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 5)
                {
                    followPosition = new Vector3(followTarget.transform.position.x + (3 * spreadDistance), transform.position.y, followTarget.transform.position.z - (3 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 7)
                {
                    followPosition = new Vector3(followTarget.transform.position.x + (4 * spreadDistance), transform.position.y, followTarget.transform.position.z - (4 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
                else if (i == 9)
                {
                    followPosition = new Vector3(followTarget.transform.position.x + (5 * spreadDistance), transform.position.y, followTarget.transform.position.z - (5 * spreadDistance));
                    followUnits[i].transform.position = Vector3.MoveTowards(followUnits[i].transform.position, followPosition, speed * Time.deltaTime);
                    followUnits[i].transform.rotation = Quaternion.Lerp(followUnits[i].transform.rotation, transform.rotation, 1);
                }
            }
        }
    }






}
