using System;
using System.ComponentModel.DataAnnotations;

namespace Vk
{
    public enum MessageReadState
    {
        [Display(Name="Непрочтено")]
        Unread = 0,
        [Display(Name = "Прочтено")]
        Read = 1
    }

    public enum MessageDirection
    {
        [Display(Name = "Исходящие")]
        Out=0,
        [Display(Name = "Входящие")]
        In=1
    }


    public enum UserRelation
    {
        [Display(Name = "Не женат/Не замужем")]
        NotMeried = 1,
        [Display(Name = "Есть друг/подруга")]
        HasFriend = 2,
        [Display(Name = "Помолвлен/Помолвлена")]
        Engaged = 3,
        [Display(Name = "Женат/Замужем")]
        Merried = 4,
        [Display(Name = "Все сложно")]
        AllComplicated = 5,
        [Display(Name = "В активном поиске")]
        ActiveSearch = 6,
        [Display(Name = "Влюблен/Влюблена")]
        FallInLove = 7

    }


}
