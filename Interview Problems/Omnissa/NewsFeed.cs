namespace DSARoadmap.InterviewProblems.Omnissa
{
    /// <summary>
    /// Represents a post containing textual content and an associated timestamp.
    /// </summary>
    /// <remarks>Use the Post class to encapsulate information about a single post, including its content and
    /// the time it was created or published. This class can be used in scenarios such as messaging, blogging, or event
    /// logging where posts are tracked with their creation time.</remarks>
    public class Post
    {
        public string _content;
        public int _time;

        public Post(string content, int time)
        {
            _content = content;
            _time = time;
        }
    }

    /// <summary>
    /// Represents a news feed system where publishers can publish content, 
    /// users can subscribe to publishers,
    /// and users can retrieve recent news from their subscribed publishers.
    /// </summary>
    public class NewsFeed
    {
        private Dictionary<string, List<Post>> publisherPosts;
        private Dictionary<string, List<string>> userSubscriptions;
        private int timeStamp;

        /// <summary>
        /// Constructs a new instance of the NewsFeed class, 
        /// initializing the necessary data structures for managing publishers, posts, 
        /// and user subscriptions.
        /// </summary>
        public NewsFeed()
        {
            publisherPosts = new Dictionary<string, List<Post>>();
            userSubscriptions = new Dictionary<string, List<string>>();
            timeStamp = 0;
        }

        /// <summary>
        /// Records a new post from a publisher with the given content.
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="content"></param>
        // publish(publisherId, content)
        public void Publish(string publisherId, string content)
        {
            if (!publisherPosts.ContainsKey(publisherId))
            {
                publisherPosts[publisherId] = new List<Post>();
            }

            publisherPosts[publisherId].Add(new Post(content, timeStamp++));
        }

        /// <summary>
        /// Registers a user's subscription to a publisher, allowing the user to receive 
        /// updates from that publisher in their news feed.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publisherId"></param>
        // subscribe(userId, publisherId)
        public void Subscribe(string userId, string publisherId)
        {
            if (!userSubscriptions.ContainsKey(userId))
            {
                userSubscriptions[userId] = new List<string>();
            }

            if (!userSubscriptions[userId].Contains(publisherId))
            {
                userSubscriptions[userId].Add(publisherId);
            }
        }

        /// <summary>
        /// Removes a user's subscription to a publisher, preventing the user from receiving the publisher's updates in their news feed.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="publisherId"></param>
        // unsubscribe(userId, publisherId)
        public void Unsubscribe(string userId, string publisherId)
        {
            if (userSubscriptions.ContainsKey(userId))
            {
                userSubscriptions[userId].Remove(publisherId);
            }
        }

        /// <summary>
        /// To retrieve the most recent news for a user, this method collects all posts 
        /// from the publishers the user is subscribed to, sorts them by their timestamp 
        /// in descending order, and returns the content of the top k posts.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        // getRecentNews(userId, k)
        public List<string> GetRecentNews(string userId, int k)
        {
            List<Post> allPosts = new List<Post>();
            List<string> result = new List<string>();

            if (!userSubscriptions.ContainsKey(userId))
                return result;

            List<string> pubs = userSubscriptions[userId];

            // Collect all posts
            for (int i = 0; i < pubs.Count; i++)
            {
                string pub = pubs[i];
                if (publisherPosts.ContainsKey(pub))
                {
                    List<Post> posts = publisherPosts[pub];
                    for (int j = 0; j < posts.Count; j++)
                    {
                        allPosts.Add(posts[j]);
                    }
                }
            }

            // Manual Bubble Sort (Descending by _time)
            for (int i = 0; i < allPosts.Count - 1; i++)
            {
                for (int j = 0; j < allPosts.Count - i - 1; j++)
                {
                    if (allPosts[j]._time < allPosts[j + 1]._time)
                    {
                        Post temp = allPosts[j];
                        allPosts[j] = allPosts[j + 1];
                        allPosts[j + 1] = temp;
                    }
                }
            }

            // Take first k
            int count = Math.Min(k, allPosts.Count);

            for (int i = 0; i < count; i++)
            {
                result.Add(allPosts[i]._content);
            }

            return result;
        }
    }
}
