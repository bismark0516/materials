namespace Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; } = false;
        public int CurrentChannel { get; private set; } = 3;

        public int CurrentVolume { get; private set; } = 2;


        public void TurnOff()
        {
            IsOn = false;
        }
        public void TurnOn()
        {
            IsOn = true;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }
        public void ChangeChannel(int newChannel)
        {
            if (IsOn == true && newChannel >= 3 && newChannel <= 18)
            {
                CurrentChannel = newChannel;
            }
        }
        public void ChannelUp()
        {
            if (IsOn == true)
            {
                CurrentChannel++;
                if (CurrentChannel > 18)
                {
                    CurrentChannel = 3;
                }
            }
            else;


        }
        public void ChannelDown()
        {
            if (IsOn == true)
            {
                CurrentChannel--;
                if (CurrentChannel < 3)
                {
                    CurrentChannel = 18;
                }
            }
            else;
        }
        public void RaiseVolume()
        {
            if (IsOn && CurrentVolume <= 10)
            {
                CurrentVolume++;
            }
        }
        public void LowerVolume()
        {
            if (IsOn && CurrentVolume > 0)
            {
                CurrentVolume--;
            }
        }
    }
}
