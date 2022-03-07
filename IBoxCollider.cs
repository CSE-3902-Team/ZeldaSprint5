namespace Sprint0
{
    public interface IBoxCollider
    {
        /*
         * The instance variables that represent TopLeft and BottomRight must
         * be readonly or else the references stored in the objects and collision
         * won't be same
         */
        public TopLeft TopLeft { get; }

        public BottomRight BottomRight { get; }
    }
}
