namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str.Substring(0, 1) == "x")
                {
                    result = result + str.Substring(0, 1);
                }
                else if (str.Substring(i, 1) != "x")
                {
                    result = result + str.Substring(i, 1);
                }
                else if (i == str.Length-1 && str.Substring(str.Length-1, 1) == "x")
                {
                    result = result + str.Substring(str.Length - 1, 1);
                }
            }
            return result;
        }
    }
}
