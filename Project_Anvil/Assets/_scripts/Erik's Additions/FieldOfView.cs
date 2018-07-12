using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : AnvilSystem {

	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	//For what we want to target
	public LayerMask targetMask;
	//For what gets in our way
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	

	//This is how accurate you want the edges to be
	public int edgeResolveIterations;
	//For when 2 rays hit something but there is empty space between them
	public float edgeDstThreshold;


	//Things to handle the mesh drawing
	public MeshFilter viewMeshFilter;
	Mesh viewMesh;
	public float meshResolution;


	//The active AnvilHuman this script is with
	public AnvilHuman anvilHuman;



	void Start() {
	//	viewMesh = new Mesh ();
	//	viewMesh.name = "View Mesh";
	//	viewMeshFilter.mesh = viewMesh;

		anvilHuman = GetComponent<AnvilHuman>();

		//This will call the function every .05f seconds
		//StartCoroutine ("FindTargetsWithDelay", .05f);
	}


	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void LateUpdate() {

		//	DrawFieldOfView ();
		//Improve performance take take this out and uncomment the StartCoroutine
		FindVisibleTargets();

	}

	void FindVisibleTargets() {
		visibleTargets.Clear ();
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

		//This checks for enemies in the radius
		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius [i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;

			//This checks for enemies in the angle
			if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
				float dstToTarget = Vector3.Distance (transform.position, target.position);
				if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
					visibleTargets.Add (target);

					//This add an enemy to the agents memeory
					anvilHuman.addEnemy(target.gameObject);

					//This will do damage to the opponent
					//target.GetComponent<AnvilHuman>().doDamage(20);

					Debug.Log ("Get off my turff or I'll shoot!");
				}
			}
		}
	}











	//This handles drawing the field of view, everything below this is for drawing
	void DrawFieldOfView() {
		int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new List<Vector3> ();
		ViewCastInfo oldViewCast = new ViewCastInfo ();
		for (int i = 0; i <= stepCount; i++) {
			float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
			ViewCastInfo newViewCast = ViewCast (angle);

			//This handles the edges of obstacles to make it look nicer
			if (i > 0) {
				bool edgeDstThresholdExceeded = Mathf.Abs (oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
				if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded)) {
					EdgeInfo edge = FindEdge (oldViewCast, newViewCast);
					if (edge.pointA != Vector3.zero) {
						viewPoints.Add (edge.pointA);
					}
					if (edge.pointB != Vector3.zero) {
						viewPoints.Add (edge.pointB);
					}
				}

			}
			viewPoints.Add (newViewCast.point);
			oldViewCast = newViewCast;
		}


		//These handle the vertices and triangles for the mesh we want to show
		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount-2) * 3];

		vertices [0] = Vector3.zero;
		for (int i = 0; i < vertexCount - 1; i++) {
			vertices [i + 1] = transform.InverseTransformPoint(viewPoints [i]);

			if (i < vertexCount - 2) {
				triangles [i * 3] = 0;
				triangles [i * 3 + 1] = i + 1;
				triangles [i * 3 + 2] = i + 2;
			}
		}

		viewMesh.Clear ();

		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMesh.RecalculateNormals ();
	}

	//This checks the distance between 2 vectors and tries to find the edge of an obstacle
	EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast) {
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
		Vector3 minPoint = Vector3.zero;
		Vector3 maxPoint = Vector3.zero;

		//This handles the rays for inbetween the shot out rays
		for (int i = 0; i < edgeResolveIterations; i++) {
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInfo newViewCast = ViewCast (angle);

			bool edgeDstThresholdExceeded = Mathf.Abs (minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
			if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded) {
				minAngle = angle;
				minPoint = newViewCast.point;
			} else {
				maxAngle = angle;
				maxPoint = newViewCast.point;
			}
		}

		return new EdgeInfo (minPoint, maxPoint);
	}


	ViewCastInfo ViewCast(float globalAngle) {
		Vector3 dir = DirFromAngle (globalAngle, true);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, dir, out hit, viewRadius, obstacleMask)) {
			return new ViewCastInfo (true, hit.point, hit.distance, globalAngle);
		} else {
			return new ViewCastInfo (false, transform.position + dir * viewRadius, viewRadius, globalAngle);
		}
	}


	//Gets the direction of an object from its angle
	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	public struct ViewCastInfo {
		public bool hit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle) {
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
		}
	}

	public struct EdgeInfo {
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 _pointA, Vector3 _pointB) {
			pointA = _pointA;
			pointB = _pointB;
		}
	}

}