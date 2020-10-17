using System.Collections.Generic;
using ViewModels;

namespace LoginJwt.StaticData
{
    public static class FriendsList
    {
        public static List<FriendViewModel> Friends = new List<FriendViewModel>()
        {
            new FriendViewModel("Vlatko", 1),
            new FriendViewModel("Petko", 1),
            new FriendViewModel("Ognen", 2)
        };
    }
}
