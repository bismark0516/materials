namespace Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; private set; }

        public int TotalFirstClassSeats { get; private set; }

        public int BookedFirstClassSeats { get; private set; }

        public int AvailableFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }

        public int TotalCoachSeats { get; private set; }

        public int BookedCoachSeats { get; private set; }

        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }
        }
        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass)
            {

                if (totalNumberOfSeats <= AvailableFirstClassSeats)
                {
                    BookedFirstClassSeats = totalNumberOfSeats + BookedFirstClassSeats;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                if (totalNumberOfSeats <= AvailableCoachSeats)
                {
                    BookedCoachSeats = totalNumberOfSeats + BookedCoachSeats;
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
}
