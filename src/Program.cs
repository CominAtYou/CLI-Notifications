using Microsoft.Toolkit.Uwp.Notifications;

namespace Program
{
    class Program
    {
        static void Main(string[] args) {
            // Needed especially for .contains() and .indexOf()
            List<string> argsList = args.ToList();
            if (args.Contains("-ToastActivated")) return; // Dismiss the program when it's called from a non-clickable notification being clicked

            if (args.Contains("--help")) Help.display();

            if (args.Length == 0) {
                Console.Error.WriteLine("No arguments provided!");
                Environment.Exit(3);
            }

            Arguments.verify(argsList);

            // Flag if there's a description or not. Validity has been ensured by the check above.
            bool hasDescription = argsList.Contains("--description");
            bool wantsConfirmation = argsList.Contains("--confirmation");
            bool wantsClickableWithoutConfirmation = !wantsConfirmation && argsList.Contains("--clickable");

            ToastContentBuilder notification = new ToastContentBuilder().AddText(Notifications.createTextElement(argsList, "--title"));

            if (hasDescription) notification.AddText(Notifications.createTextElement(argsList, "--description"));

            if (argsList.Contains("--confirmation")) {
                notification.AddButton(new ToastButton()
                    .SetContent("Yes")
                    .AddArgument("action", "positiveSelection")
                );

                notification.AddButton(new ToastButton()
                    .SetContent("No")
                    .AddArgument("action", "negativeSelection")
                );
            }

            ToastNotificationManagerCompat.OnActivated += toastArgs => {
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

            notification.Show();

            if (wantsConfirmation || wantsClickableWithoutConfirmation) while(true) { continue; } // Keep the app from closing until notification is interacted with
        }
    }
}
