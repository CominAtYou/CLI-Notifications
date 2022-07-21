namespace Program {
    class Help {
        public static void display() {
            Console.WriteLine("CLI-Notifications 1.1.0\n");
            Console.WriteLine("USAGE: CLI-Notifications --title <title> [args]\n");
            Console.WriteLine("Arguments");
            Console.WriteLine("--title: The title of the notification, or the text of the notification if --description is not supplied.\n");
            Console.WriteLine("--description: An optional description for the notification\n");
            Console.WriteLine("--image: Add an inline image to the notification. Takes either a URL to an image on the internet, or a file:// URI of a local image.");
            Console.WriteLine("--avatar: Add a profile picture to the notification. Takes either a file:// URI to a local image, or a URL to an image on the internet.");
            Console.WriteLine("--confirmation: Add yes/no buttons to the notifications. If yes is clicked, the program will exit with code 0. If no is clicked, the program will exit with code 1. If the notification is clicked on, the program will exit with code 2.\n");
            Console.WriteLine("--clickable: Set if you want to know when the notification has been clicked on. The program will exit with code 0 when the notification is clicked on. Only has an effect if --confirmation is not supplied.\n");
            Console.WriteLine("--uninstall: Delete registry entries and the entry in Windows notification settings related to this program. Call the program with this argument when the app utilizing this program is being uninstalled.");
            Environment.Exit(0);
        }
    }
}
