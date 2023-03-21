using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    private bool slicing;

    public Vector3 direction { get; private set; }
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private void Awake() {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            slicing = true;
            bladeTrail.Clear();
        } else if (Input.GetMouseButtonUp(0)){
            slicing = false;
        }
        
        bladeCollider.enabled = slicing;
        bladeTrail.enabled = slicing;
        Slicing();
    }

    private void Slicing(){
        if(!slicing) return;

        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
}