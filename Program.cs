using System;
using System.Collections.Generic;
using System.IO; //required for exceptions
namespace PA6
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput=GetMenuChoice();
            while(userInput!="4"){
                Route(userInput);
                userInput=GetMenuChoice();
            }
        }
        public static string GetMenuChoice(){
            DisplayMenu();
            string userInput=Console.ReadLine();
            while (!ValidMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                DisplayMenu();
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static void DisplayMenu(){
            Console.Clear();
            Console.WriteLine("1:   Show all posts");
            Console.WriteLine("2.   Add a post");
            Console.WriteLine("3:   Delete a post by ID");
            Console.WriteLine("4:   Exit");
        }

        public static bool ValidMenuChoice(string userInput){
            if(userInput=="1"||userInput=="2"||userInput=="3"||userInput=="4"){
                return true;
            }
            else{
                return false;
            }
        }
        public static void Route(string userInput){
            if(userInput=="1"){//Show all Posts
                PostUtils.PrintAllPosts();
                Console.ReadKey();
            }
            if(userInput=="2"){//Add a post
                AddPost();

            }
            if(userInput=="3"){//Delete a post
                DeletePost();
            }
        }
        public static void AddPost(){
            Console.WriteLine("What would you like your post to say?:");
            string text=Console.ReadLine();
            int id=PostUtils.GetID();
            StreamWriter outFile=File.AppendText("posts.txt");
            DateTime now = DateTime.Now; 
            outFile.Write(id+"#"+text+"#");
            outFile.Write(now);
            outFile.Close();

        }
        public static void DeletePost(){
            Console.Clear();
            Console.WriteLine("What is the ID of the post you want deleted?");
            int id=int.Parse(Console.ReadLine());
            List <Post> tempPost=PostFile.GetPosts();
            int index=0;
            foreach(Post post in tempPost){
                
                if(post.PostID==id){
                    Console.WriteLine(post+"\nIs this the post you want deleted? \n1. Yes\n2. No");
                    if(Console.ReadLine()=="1"){
                        tempPost.RemoveAt(index);
                    }
                    break;
                }
                index++;
            }
            PostUtils.UpdatePosts(tempPost);
        }
    }
}
