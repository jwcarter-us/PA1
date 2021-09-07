using System;
using System.Collections.Generic;
using System.IO;
namespace PA6
{

    public class PostUtils
    {
        public static void PrintAllPosts(){//Prints all post from "posts.txt" to console
            Console.Clear();
            Console.WriteLine("Posts listed in decending TimeStamp Order.");
            List <Post> tempPost=PostFile.GetPosts();
            tempPost.Sort();
            foreach(Post post in tempPost){
                Console.WriteLine(post);
            }
        }
        public static void UpdatePosts(List <Post> temp){//Updates "posts.txt" with the data from List temp
            StreamWriter outFile=new StreamWriter("posts.txt");
            foreach(Post post in temp){
                string stemp=post.PostID+"#"+post.PostText+"#"+post.TimeStamp;
                outFile.WriteLine(stemp);
            }
            outFile.Close();

        }

        public static int GetID(){//Returns a random ID for posts.
            Random a=new Random();
            int MyNumber=0;
            MyNumber=a.Next(0,10000);
            List <Post> tempPost=PostFile.GetPosts();
            foreach(Post post in tempPost){
                if(post.PostID==MyNumber){
                    MyNumber=a.Next(0,10000);
                }
            }
            return MyNumber;

        }
        public static bool CheckID(int id){
            List <Post> tempPost=PostFile.GetPosts();
            foreach(Post post in tempPost){
                if(post.PostID==id){
                    return true;
                }
            }
            return false;
        }        
        
    }
}