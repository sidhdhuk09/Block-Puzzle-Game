using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))] //to call audiosource component in each block asset 

public class Drag : MonoBehaviour
{
    public GameObject block;
    private bool isDragging;        //bool is used to tell us it the play is holding the mouse or he has let go of it
    private string blockpiece = "   "; //string is used in this context in order to assign the block piece to a socket
    public string checkplace= " "; //checkplace is used to tell the game whether the blockpiece is in a free flowing state or it is locked in a socket
    private float mousex;   //to determine and manipulate the position of the gameobject 
    private float mousey;   
    private Vector3 resetpos;      //to reset the position of all game objects to their original coordinates
    public string piecestate = "Idle";  //in order to facilitate the use of Onmousdown. This means that the gameobject at first is in idle state. On calling OnMousedown, the state of the gameobject will change
    private AudioSource playsound;  //in order to trigger a sound on placing the puzzle pieces

    void Start()
    {
        playsound = GetComponent<AudioSource>();    
         resetpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); //to assign the default values of all gameobjects
       
    }
    public void OnMouseDown()
    {
       
        
        isDragging = true;  //allows the user to drag the gameobjects to their intended destinations
    }

    public void OnMouseUp()
    {
       

        isDragging = false; //isdragging=false; so that the user can drag the object by holding the mouse button.

        
        /*if (Mathf.Abs(this.transform.position.x - block.transform.position.x) <= 0.1f && //mathf.abs means absolute value. This means that even if the position of the gameobject were in the negative, it would automatically turn into a positive number as absolute value by defination means: the distance of a number from 0
            Mathf.Abs(this.transform.position.y - block.transform.position.y) <= 0.1f) //mathf.Abs was used in this context in order to convert any negative values into positive values. In case the gameobject is out of bounds, it would return back to it's original position  
        {
            

            //this.transform.position = new Vector3(block.transform.position.x, block.transform.position.y, block.transform.position.z);
            
        }
        else
        {
            
            this.transform.position = new Vector3(resetpos.x, resetpos.y, resetpos.z);
           
        }*/
        
    //Unofrtunately mathf.Abs is not working. The idea was to reset the object position if the user places the object anywhere other than the given slot
}
    

    void Update()
    {
        
        if (blockpiece != "locked") //if the gameobject is not locked, it'll still be able to move
        {
            if (isDragging)
            {
                Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 objPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = objPosition;
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                checkplace = "y"; //if the gameobject is inserted into the correct slot then the checkplace state turns into yes and the gameobject will then be slotted into the socket
                
            }
            if(Input.GetMouseButtonDown(1))
            {
                gameObject.transform.position = resetpos; //on cliking the rightmousebutton; all the objects will reset into their original positions
            }
        }
    }
    
        

    void OnTriggerStay2D(Collider2D obj) //stay is used in order to trigger a collision effect between the gameobjects and the sockets 
    {
       

        if ((obj.gameObject.name == gameObject.name) && (checkplace == "y")) //if the gameobject finds the correct socket, it will automatically be assigned into the socket. The socket names and objectnames are identical, hence why this line of code works
        {
          
            transform.position = obj.transform.position;
            blockpiece = "locked";  //after the object is locked, it cannot be moved
            checkplace = "n";
            playsound.Play();
          

        }
      

        if ((obj.gameObject.name!=gameObject.name) && ( checkplace=="y")) //if the gameobject's name does not match the socket's name and even if the state changes to yes, the object will not be placed into the socket as the object name does not match the socket's name
        {
            checkplace = "n"; //this allows the user to resume dragging and placing the object into the correct socket.
          

        }
      
    }

}
    






