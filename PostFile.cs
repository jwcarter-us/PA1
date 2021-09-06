using System;
using System.Collections.Generic;
using System.IO;
namespace PA6
{
    public class PostFile
    {
        public static List<Post> GetPosts(){
            List <Post> tempPosts=new List<Post>();
            StreamReader inFile=new StreamReader("posts.txt");
            string line=inFile.ReadLine();//priming read
            while(line!=null){
                string[] temp=line.Split("#");
                int tempID=int.Parse(temp[0]);
                tempPosts.Add(new Post(){PostID=tempID,PostText=temp[1],TimeStamp=temp[2]});
                line=inFile.ReadLine();
            }
            inFile.Close();
            tempPosts.Sort(Post.CompareByID);
            PostUtils.UpdatePosts(tempPosts);

            return tempPosts;
        }
    }
}