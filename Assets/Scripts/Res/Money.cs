namespace Assets.Scripts.Res {
    public class Money : TypelessResource {
        public Money(int amount = 10000) {
            Amount = amount;
        }

        public new int Amount { get; private set; }

    }
}