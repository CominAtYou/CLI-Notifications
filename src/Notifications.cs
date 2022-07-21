using Microsoft.Toolkit.Uwp.Notifications;

namespace Program {
    class Notifications {
        public static string createTextElement(string[] args, string delimiter) {
            if (!delimiter.StartsWith("--")) throw new ArgumentException("Delimiter must start with \"--\"");
            if (Array.IndexOf(args, delimiter) == args.Length - 1) throw new ArgumentException("Delimiter does not have any arguments!");

            string title = "";
            for (int i = Array.IndexOf(args, delimiter) + 1; i < args.Length; i++) { // This is needed because args is space-delimited
                if (args[i].StartsWith("--")) break; // Stop when another argument is reached
                title += " " + args[i];
            }
            return title;
        }

        public static OnActivated onActivated(bool wantsConfirmation) {
            return (ToastNotificationActivatedEventArgsCompat toastArgs) => {
                ToastArguments parsedArgs = ToastArguments.Parse(toastArgs.Argument);
                // Return 0 if the notification is clicked on when confirmation is not wanted, and 2 when confirmation is wanted.
                if (parsedArgs.Count == 0) Environment.Exit(wantsConfirmation ? 2 : 0);

                if (parsedArgs["action"] == "positiveSelection") {
                    Environment.Exit(0);
                }
                else {
                    Environment.Exit(1);
                }
            };
        }
    }
}
