namespace LedDisplay.Graphics.Controller
{
    public class Display
    {
        private readonly ILedDisplayDriver driver;

        public Display(ILedDisplayDriver driver)
        {
            this.driver = driver;
        }

        public async Task DisplayFrame(AnimationFrame frame)
        {
            await this.driver.SendDataAsync(frame.Data);
        }

        public async Task PlayAnimation(Animation animation, bool loop)
        {
            for (int i = 0; i < animation.Count; i++)
            {
                await DisplayFrame(animation[i]);
                if (loop && i == animation.Count - 1)
                {
                    i = 0;
                }
            }
        }
    }
}
