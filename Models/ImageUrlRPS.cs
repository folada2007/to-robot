using HackM.Models.Enums;
using HackM.Services.Interfaces;
using System;

namespace HackM.Models
{
    public class ImageUrlRPS: IImageUrlRPS
    {
        public string GetImageUrl(string Move) =>
        
            Move switch
            {
                "Rock" => "~/img/tombstone_28is48nfbaek_128.png",
                "Paper" => "~/img/toilet_paper_1q9xf9mjmbhg_128.png",
                "Scissors" => "~/img/scissors_jpv07xaac5ep_128.png",
                _ => string.Empty
            };
        
    }
}
