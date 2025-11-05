public class LinkedNode{
    public int tweetId;
    public DateTime timestamp;
    public LinkedNode nextTweet;
}

public class Twitter {
    Dictionary<int, HashSet<int>>following;
    Dictionary<int, HashSet<int>>followed;
    Dictionary<int, LinkedNode>tweets;

    public Twitter() {
        following = new Dictionary<int, HashSet<int>>();
        followed = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, LinkedNode>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!tweets.Keys.Contains(userId))
        {
            LinkedNode temp = new LinkedNode();
            temp.tweetId = tweetId;
            temp.timestamp = DateTime.Now;
            temp.nextTweet = null;
            tweets.Add(userId, temp);
        }
        else
        {
            LinkedNode temp = new LinkedNode();
            temp.tweetId = tweetId;
            temp.timestamp = DateTime.Now;
            temp.nextTweet = tweets[userId];
            tweets[userId] = temp;
        }
    }
    
    public IList<int> GetNewsFeed(int userId) {
        List<LinkedNode>buffer=new List<LinkedNode>();

        if(following.Keys.Contains(userId))
        {
            foreach(var v in following[userId])
            {
                if(!tweets.Keys.Contains(v))
                    continue;

                LinkedNode current = tweets[v];
                for(int i=0; i<10; i++)
                {
                    buffer.Add(current);
                    if(current.nextTweet!=null)
                        current = current.nextTweet;
                    else
                        break;
                }
            }            
        }


        if(tweets.Keys.Contains(userId))
        {
            LinkedNode current = tweets[userId];
            for(int i=0; i<10; i++)
            {
                 buffer.Add(current);
                 if(current.nextTweet!=null)
                    current = current.nextTweet;
                 else
                    break;
            }           
        }

        var result = buffer.OrderByDescending(x=>x.timestamp).Select(x=>x.tweetId).Take(10).ToList();

        return result;     
    }
    
    public void Follow(int followerId, int followeeId) {
        //process following
        if(!following.Keys.Contains(followerId))
        {
            HashSet<int>temp = new HashSet<int>();
            following.Add(followerId, temp);
        }

        if(!following[followerId].Contains(followeeId))
        {
            following[followerId].Add(followeeId);
        }

        //process followed
        if(!followed.Keys.Contains(followeeId))
        {
            HashSet<int>temp = new HashSet<int>();
            followed.Add(followeeId, temp);
        }

        if(!followed[followeeId].Contains(followerId))
        {
            followed[followeeId].Add(followerId);
        }
    }
    
    public void Unfollow(int followerId, int followeeId) {
        //process following
        if(following.Keys.Contains(followerId) && following[followerId].Contains(followeeId))
        {
            following[followerId].Remove(followeeId);
        }

        //process followed
        if(followed.Keys.Contains(followeeId) && followed[followeeId].Contains(followerId))
        {
            followed[followeeId].Remove(followerId);
        }        
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */