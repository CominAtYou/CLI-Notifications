using Microsoft.Toolkit.Uwp.Notifications;
using Program.Args;

namespace Program {
    class Arguments {
        private static List<string> arguments = new List<string>() { "--title", "--description", "--confirmation", "--clickable", "--avatar", "--image" };
        private static Dictionary<String, Func<ToastContentBuilder, string[], ToastContentBuilder>> argOps = new Dictionary<string, Func<ToastContentBuilder, string[], ToastContentBuilder>>() {
            { "--title", Title.addTitle },
            { "--description", Description.addDescription },
            { "--confirmation", Confirmation.addButtons },
            { "--avatar", Avatar.setAvatar },
            { "--image", Image.setImage }
        };

        public static void verify(string[] args) {
            // Ensure the command includes a title.
            if (!args.Contains("--title") || Array.IndexOf(args, "--title") == args.Length - 1) {
                Console.Error.WriteLine("Required arguments are either missing or invalid!");
                Environment.Exit(3);
            }

            if (args.Contains("--description") && Array.IndexOf(args, "--description") == args.Length - 1) {
                Console.Error.WriteLine("Invalid value provided for description parameter!");
                Environment.Exit(3);
            }

            for (int i = 0; i < args.Length; i++) {
                if (args[i].StartsWith("--") && !arguments.Contains(args[i])) {
                    Console.Error.WriteLine("Unknown parameter '{0}'", args[i]);
                    Environment.Exit(3);
                }
            }
        }

        public static ToastContentBuilder apply(ToastContentBuilder builder, string[] args) {
            ToastContentBuilder builderInstance = builder;
            List<string> argsList = args.ToList();

            for (int i = 0; i < args.Length; i++) {
                if (!args[i].StartsWith("--")) continue;
                builderInstance = argOps[args[i]](builderInstance, args);
            }

            return builderInstance;
        }

        public static void runUtilityArguments(string[] args) {
            if (args.Contains("--help")) Help.display();

            if (args[0] == "--uninstall") {
                ToastNotificationManagerCompat.Uninstall();
                Console.WriteLine("Cleaned up notifications and notification resources.");
                Environment.Exit(0);
            }

            if (args.Length == 0) {
                Console.Error.WriteLine("No arguments provided!");
                Environment.Exit(3);
            }
        }
    }
}
