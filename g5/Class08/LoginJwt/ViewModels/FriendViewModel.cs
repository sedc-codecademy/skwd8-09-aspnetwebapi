namespace ViewModels
{
    public class FriendViewModel
    {
        public string Name { get; set; }
        public int FriendOfUserId { get; set; }

        public FriendViewModel()
        {
            
        }

        public FriendViewModel(string name, int friendOfUserId)
        {
            Name = name;
            FriendOfUserId = friendOfUserId;
        }
    }
}
