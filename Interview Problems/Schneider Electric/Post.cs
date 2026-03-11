using System;
using System.Collections.Generic;
using System.Text;

namespace DSARoadmap.InterviewProblems.SchneiderElectric
{
    //public class Post
    //{
    //    public string CreatePost()
    //    {
    //        return ("Normal Post");
    //    }
    //}

    //public class TagPost : Post
    //{
    //    public string CreateTagPost()
    //    {
    //        return ("Tag Post");
    //    }
    //}

    //public class MentionPost : Post
    //{
    //    public string CreateMentionPost()
    //    {
    //        return ("Mention Post");
    //    }
    //}

    //public class Post
    //{
    //    public virtual string CreatePost()
    //    {
    //        return "Normal Post";
    //    }
    //}

    //public class TagPost : Post
    //{
    //    public override string CreatePost()
    //    {
    //        return "Tag Post";
    //    }
    //}

    //public class MentionPost : Post
    //{
    //    public override string CreatePost()
    //    {
    //        return "Mention Post";
    //    }
    //}

    // Base Class

    public abstract class Post
    {
        public abstract string CreatePost();
    }

    // Derived Class for Tag Post
    public class TagPost : Post
    {
        public override string CreatePost()
        {
            return "Tag Post";
        }
    }

    //  Derived Class for Mention Post
    public class MentionPost : Post
    {
        public override string CreatePost()
        {
            return "Mention Post";
        }
    }

    // Derived Class for Normal Post
    public class NormalPost : Post
    {
        public override string CreatePost()
        {
            return "Normal Post";
        }
    }

    // Factory Class to create Post objects based on the input string
    // Factory Design Pattern is used to create objects without exposing the instantiation logic
    // to the client and refers to the newly created object through a common interface.
    public class PostFactory
    {
        public static Post GetPost(string post)
        {
            if (post.StartsWith("#"))
                return new TagPost();

            if (post.StartsWith("@"))
                return new MentionPost();

            return new NormalPost();
        }
    }
}
