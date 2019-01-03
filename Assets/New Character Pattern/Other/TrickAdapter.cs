using UnityEngine;
using System.Collections;

public class TrickAdapter : MonoBehaviour
{

    Hashtable tricksName = new Hashtable();

    protected const string TTG = "s-9-91";
    protected const string Jumping_name = "s-9-9";
    protected const string Monkey_name = "s9";
    protected const string forward_flip_name = "s1199";
    protected const string rondate_flip_name = "s1199-1";
    protected const string flyag_flip_name = "s19";
    protected const string back_flip_name = "s-1-199";
    protected const string arabh_flip_name = "s11999";
    protected const string screw_flip_name = "s1199-1-1";
    protected const string blansh_flip_name = "s-1-1999";
    protected const string side_flip_name = "s-9-911";
    protected const string to_left = "s-1-1";
    protected const string to_right = "s11";
    protected const string foraward_flip_fall = "s11";

    public TrickAdapter() {

        tricksName.Add(forward_flip_name, "forward_flip");
        tricksName.Add(arabh_flip_name, "arabh_first_stage");
        tricksName.Add(Jumping_name, "arabh_first_stage");


    }

    public void addNewName(string picture, string trickName) {
        tricksName.Add(picture, tricksName);
    }

    public string getNameByPicture(string picture) => (string) tricksName[picture];

}

