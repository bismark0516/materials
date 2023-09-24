using System.Runtime.CompilerServices;

namespace Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            this.TypeOfFruit = typeOfFruit;
            this.PiecesOfFruitLeft = startingPiecesOfFruit;
        }
        public bool PickFruit(int numberOfPiecesToRemove)
        {
            // if it is possible to continue to remove fruit return true otherwise return false
            if (PiecesOfFruitLeft >= numberOfPiecesToRemove)
            {
                PiecesOfFruitLeft = PiecesOfFruitLeft - numberOfPiecesToRemove;
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
