namespace Models {
    public class Invoice {
        public int Id { get; set; }
        public string Customer { get; set; }
        public float Amount { get; set; }
        public DateTime Due { get; set; }
    }
}