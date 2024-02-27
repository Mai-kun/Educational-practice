namespace Exercise_15
{
    class Tpike : TFish
    {
        public Tpike(double xCoordinate, double yCoordinate, double speed, double size, string color, string direction) 
            : base(xCoordinate, yCoordinate, speed, size, color, direction)
        {
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
