using System;
using System.Collections.Generic;
using System.IO;
namespace PA6
{
    public class Post : IComparable<Post>
    {
        public int PostID {get; set;}
        public string PostText{get; set;}
        public string TimeStamp {get; set;}
        public int CompareTo(Post temp){
            return this.TimeStamp.CompareTo(temp.TimeStamp);
        }
        public static int CompareByID(Post x, Post y){
            return x.PostID.CompareTo(y.PostID);
        }
        public override string ToString()
        {
            return "ID: "+this.PostID+"\n\""+this.PostText+"\"\n"+this.TimeStamp;
        }
    }
}