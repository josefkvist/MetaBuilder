namespace MetaBuilder.Core
{
    public class KeyGenerator
    {
        private static int _currentKey = 0;

        public static int GetKey
        {
            get
            {
                _currentKey++;
                return _currentKey;
            }
        }
    }
}