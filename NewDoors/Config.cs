namespace NewDoors
{
    using System.ComponentModel;

    public class Config
    {
        [Description("Should use 1 door?")]
        public bool IsEnabledDoor1 { get; set; } = true;

        [Description("Should use 2 door?")]
        public bool IsEnabledDoor2 { get; set; } = true;

        [Description("Should use 3 door?")]
        public bool IsEnabledDoor3 { get; set; } = true;

        [Description("Should use 4 door?")]
        public bool IsEnabledDoor4 { get; set; } = true;
    }
}
