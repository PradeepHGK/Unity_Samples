using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Class1 : MonoBehaviour
{
    protected Class1(string filename)
    {
        this.filename = filename;
    }

    public int velocity { get; set; }
    public string filename { get; set; }

    public abstract void LoadTexture(string files);
}

public class ChildClass : Class1
{
    public ChildClass(string filename) : base(filename)
    {

    }


    public override void LoadTexture(string files) 
    {
        
    }
}

public class ThirdClass : Class1
{
    public ThirdClass(string filename) : base(filename)
    {

    }

    public override void LoadTexture(string files)
    {
       
    }
}
