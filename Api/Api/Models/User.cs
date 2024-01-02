namespace Models{
    public class User {
        public string Uuid { get ; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string[] Features { get; set; }
    }
}