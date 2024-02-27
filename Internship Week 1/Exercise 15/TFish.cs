namespace Exercise_15
{
    class TFish
    {
        protected double xCoordinate;
        protected double yCoordinate;
        protected double speed;
        protected double size;
        protected string color;
        protected string direction;

        public TFish(double xCoordinate, double yCoordinate, double speed, double size, string color, string direction)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.speed = speed;
            this.size = size;
            this.color = color;
            this.direction = direction;
        }

        public void Init()
        {

        }
        public virtual void Draw() { }
        
        public void Look()
        {

        }
        public void Run()
        {

        }
    } 
}
