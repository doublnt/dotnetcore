namespace EventDemo.ButtonDemo {
    public class MyButton {
        public delegate void ClickHandler (object sender, ButtonClickArgs e);

        public event ClickHandler OnClick;

        public void Click () {
            var buttonClickArgs = new ButtonClickArgs {
                Clicker = "Robert published!"
            };
            OnClick (this, buttonClickArgs);
        }
    }
}