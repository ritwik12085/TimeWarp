#pragma strict

function Start () {

}


//Type the name of the scene to load in the inspector.

var SceneToPlay : String ;

var hit: RaycastHit;

function Update (){

var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

if (Input.GetMouseButtonDown(0)){

if (Physics.Raycast (ray, hit , Mathf.Infinity)){

if (hit.collider.name == "Play") { Application.LoadLevel("testScene"); }

} } }