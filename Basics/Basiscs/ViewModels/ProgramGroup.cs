using System;

namespace App1.ViewModels
{

    public class ProgramGroup
    {
        public string persianDate { get; set; }
        public string displayDate { get; set; }
        public string date { get; set; }
        public Program[] programs { get; set; }
    }

    public class Program
    {
        public int id { get; set; }
        public string title { get; set; }
        public int duration { get; set; }
        public string cover { get; set; }
        public DateTime startAt { get; set; }
        public DateTime streamStartAt { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public bool isLive { get; set; }
        public bool isFeatured { get; set; }
        public int layout { get; set; }
        public DateTime creationDate { get; set; }
        public string thumbnail { get; set; }
        public Layoutdata layoutData { get; set; }
        public bool _lock { get; set; }
        public string sportName { get; set; }
        public string upperTitle { get; set; }
        public bool isDisplayTimer { get; set; }
        public object shaparakFee { get; set; }
        public int remainingToStart { get; set; }
        public object descendants { get; set; }
    }

    public class Layoutdata
    {
        public string hostName { get; set; }
        public string hostLogo { get; set; }
        public string guestName { get; set; }
        public string guestLogo { get; set; }
    }
}