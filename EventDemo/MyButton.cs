namespace EventDemo {
    public class MyButton {
        public delegate void ClickHandler (object sender, ButtonClickArgs e);

        public event ClickHandler OnClick;

        public void Click () {
            OnClick (this, new ButtonClickArgs () { Clicker = "Robert" });
        }
    }
}