namespace Exercises.Classes
{ // this is how you create a class
    public class Elevator
    {
       
        public int CurrentLevel { get; private set; } = 1;
        public int NumberOfLevels { get; private set; }
        public bool DoorIsOpen { get; private set; }

        public Elevator(int numberOfLevels)
        {
            this.NumberOfLevels = numberOfLevels;
        }
        // methods are below
        public void OpenDoor()
        {
            DoorIsOpen = true;
        }
        public void CloseDoor()
        {
            DoorIsOpen = false;
        }
        public void GoUp(int desiredFloor)
        {
            // if door is closed
            // if desired floor is less than or equal to the top floor
            // if desired floor is greater than current floor
            if (!DoorIsOpen && desiredFloor <= NumberOfLevels && desiredFloor > CurrentLevel)
            {
                CurrentLevel = desiredFloor;
            }
        }
        public void GoDown(int desiredFloor)
        {
            if (!DoorIsOpen && desiredFloor>= 1 && desiredFloor < CurrentLevel)
            {
                CurrentLevel = desiredFloor;
            }
        }




    }
}
